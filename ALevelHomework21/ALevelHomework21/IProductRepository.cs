using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework21
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(string name, double price);
        Task<ProductEntity?> GetProductAsync(int id);
        Task UpdateProductAsync(int id, string name, double price);
        Task DeleteProductAsync(int id);

        Task<IEnumerable<ProductEntity>> GetProductsPagedAsync(int page, int pageSize, string? nameFilter, double? minPriceFilter, double? maxPriceFilter, bool orderByDesc);
    }
}
