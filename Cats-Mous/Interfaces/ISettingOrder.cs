using Cats_Mous.Models;
using System.Threading.Tasks;

namespace Cats_Mous.Interdaces
{
    public interface ISettingOrder
    {
        Task ChekStatusAsync(Order order);
        Task<IdOrder> RegistredOrder(Order order);
        Task<string> ServeRequest(FormRegistrationIdOrder idOrder, string UrlAddress);
        Task<string> ServeRequest(RequestStatusOrder requestStatus, string UrlAddress);
    }
}