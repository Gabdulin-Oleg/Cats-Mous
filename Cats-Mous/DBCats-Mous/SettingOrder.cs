using Cats_Mous.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Cats_Mous.DBCats_Mous
{
    public static class SettingOrder
    {
       

        public static async Task<string> ServeRequest(Order order, string UrlAddress)
        {
            using (HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri($" http://attest.turkmen-tranzit.com")
            })
            {
                var answer = await client.PostAsJsonAsync($"{client.BaseAddress}{UrlAddress}", order);

                var jsonAnswer = await answer.Content.ReadAsStringAsync();

                return jsonAnswer;
            }
        }


        public static async Task<Order> RegistredOrder(Order order)
        {

            string urlRegisterd= "payment/rest/register.do";
            order.OrderNumber = order.Id.ToString();
            order.ReturnUrl = $"/Home/PaymentСonfirmation?orderNumber={order.Id}";

            IdOrder IdOrder = JsonSerializer.Deserialize<IdOrder>(await ServeRequest(order, urlRegisterd));
            order.errorCode = IdOrder.errorCode;
            order.errorMessage = IdOrder.errorMessage;
            order.orderId = IdOrder.orderId;
            order.formUrl = IdOrder.formUrl;

            return order;

        }
        public static async Task ChekStatusAsync(Order order)
        {
            string urlChecStatus = "payment/rest/getOrderStatus.do";

            Status status = JsonSerializer.Deserialize<Status>(await ServeRequest(order, urlChecStatus));

            order.OrderStatus = status.OrderStatus;

            switch (order.OrderStatus)
            {
                case 0:
                    {
                        Thread.Sleep(60000);
                        order.OrderStatus = 2;
                        await ChekStatusAsync(order);
                        break;
                    }

                case 2:
                    {
                        Operations.UpDate(order);
                        break;
                    }
                case 3:
                    {
                        Operations.Delete(order);
                        break;
                    }
                case 7:
                    {
                        Thread.Sleep(10000);
                        order.OrderStatus = 2;
                        await ChekStatusAsync(order);
                        break;
                    }
            }
        }

    }
}
