using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IOrderData
    {
        Task<int> CreateOrder(OrderModel orderModel);
        Task<int> UpdateOrderName(int orderId , string orderName);
        Task<int> DeleteOrder(int orderId);
        Task<OrderModel> GetOrderById(int orderId);
    }
}