using Cats_Mous.Interdaces;
using Cats_Mous.Models;
using Cats_Mous.Repository;
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
    public class SettingOrder : ISettingOrder
    {
        private IRepository operationDB;

        public SettingOrder()
        {
            operationDB = new Operations();
        }
        public async Task<string> ServeRequest(FormRegistrationIdOrder idOrder, string UrlAddress)
        {
            using (HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri($" http://attest.turkmen-tranzit.com")
            })
            {
                var answer = await client.PostAsJsonAsync($"{client.BaseAddress}{UrlAddress}", idOrder);

                var jsonAnswer = await answer.Content.ReadAsStringAsync();

                return jsonAnswer;
            }
        }
        public async Task<string> ServeRequest(RequestStatusOrder requestStatus, string UrlAddress)
        {
            using (HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri($" http://attest.turkmen-tranzit.com")
            })
            {
                var answer = await client.PostAsJsonAsync($"{client.BaseAddress}{UrlAddress}", requestStatus);

                var jsonAnswer = await answer.Content.ReadAsStringAsync();

                return jsonAnswer;
            }
        }


        public async Task<IdOrder> RegistredOrder(Order order)
        {
            string urlRegisterd = "payment/rest/register.do";

            operationDB.Creat(order);
            order.orderNumber = order.Id.ToString();
            FormRegistrationIdOrder registrationIdOrder = new FormRegistrationIdOrder(order);

            IdOrder idOrder = JsonSerializer.Deserialize<IdOrder>(await ServeRequest(registrationIdOrder, urlRegisterd));
            order.orderId = idOrder.orderId;
            operationDB.UpDate(order);

            return idOrder;

        }
        public async Task ChekStatusAsync(Order order)
        {
            string urlChecStatus = "payment/rest/getOrderStatus.do";
            RequestStatusOrder requestStatus = new RequestStatusOrder(order);
            StatusOrder status = JsonSerializer.Deserialize<StatusOrder>(await ServeRequest(requestStatus, urlChecStatus));

            order.OrderStatus = status.orderStatus;

            switch (order.OrderStatus)
            {
                case (int?)EnumOrderStatus.RegisteredButNotPaid:
                    {
                        Thread.Sleep(60000);                        
                        await ChekStatusAsync(order);
                        break;
                    }

                case (int?)EnumOrderStatus.SuccessfullyPaid:
                    {
                        operationDB.UpDate(order);
                        break;
                    }
                case (int?)EnumOrderStatus.AuthorizationCanceled:
                    {
                        operationDB.Delete(order);
                        break;
                    }
                case (int?)EnumOrderStatus.OrderIsBeingProcessed:
                    {
                        Thread.Sleep(10000);                       
                        await ChekStatusAsync(order);
                        break;
                    }
            }
        }

    }
}
