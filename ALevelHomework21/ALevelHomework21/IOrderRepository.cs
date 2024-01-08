using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework21
{
    public interface IOrderRepository
    {
        Task<int> AddOrderAsync(string user, List<OrderItem> items);
        Task<OrderEntity?> GetOrderAsync(int id);
        Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id);
    }
}
