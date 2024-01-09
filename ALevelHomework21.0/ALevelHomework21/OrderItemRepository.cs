using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALevelHomework21
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderItemRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddOrderItemAsync(int orderId, int productId, int count)
        {
            var orderItem = new OrderItemEntity
            {
                OrderId = orderId,
                ProductId = productId,
                Count = count
            };

            var result = await _dbContext.OrderItems.AddAsync(orderItem);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<OrderItemEntity?> GetOrderItemAsync(int id)
        {
            return await _dbContext.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateOrderItemAsync(int id, int count)
        {
            var existingOrderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrderItem != null)
            {
                existingOrderItem.Count = count;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var orderItemToDelete = await _dbContext.OrderItems.FirstOrDefaultAsync(o => o.Id == id);

            if (orderItemToDelete != null)
            {
                _dbContext.OrderItems.Remove(orderItemToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
