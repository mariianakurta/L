using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework21
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddProductAsync(string name, double price)
        {
            var product = new ProductEntity()
            {
                Name = name,
                Price = price
            };

            var result = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateProductAsync(int id, string name, double price)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);

            if (existingProduct != null)
            {
                existingProduct.Name = name;
                existingProduct.Price = price;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);

            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsPagedAsync(int page, int pageSize, string? nameFilter, double? minPriceFilter, double? maxPriceFilter, bool orderByDesc)
        {
            IQueryable<ProductEntity> query = _dbContext.Products;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(p => p.Name.Contains(nameFilter));
            }

            if (minPriceFilter.HasValue)
            {
                query = query.Where(p => p.Price >= minPriceFilter.Value);
            }

            if (maxPriceFilter.HasValue)
            {
                query = query.Where(p => p.Price <= maxPriceFilter.Value);
            }

            if (orderByDesc)
            {
                query = query.OrderByDescending(p => p.Price);
            }
            else
            {
                query = query.OrderBy(p => p.Price);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
