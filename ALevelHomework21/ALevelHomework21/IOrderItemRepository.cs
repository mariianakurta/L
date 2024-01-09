using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework21
{
    public interface IOrderItemRepository
    {
        Task<int> AddOrderItemAsync(int orderId, int productId, int count);
        Task<OrderItemEntity?> GetOrderItemAsync(int id);
        Task UpdateOrderItemAsync(int id, int count);
        Task DeleteOrderItemAsync(int id);
    }
}
