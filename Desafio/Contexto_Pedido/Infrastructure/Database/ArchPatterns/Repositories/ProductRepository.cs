
using Domain.ArchPatterns.Repositories;
using Domain.Entities.Product;
using Domain.Validations;
using Infrastructure.Database.EntityFramework;

namespace Infrastructure.Database.ArchPatterns.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);
        }

        public Task<List<Product>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> ReadByIdAsync(int productId)
        {
            var findedProduct = await _dataContext.Products.FindAsync(productId);

            return findedProduct;
        }

        public Task UpdateAsync(Product data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int dataId)
        {
            throw new NotImplementedException();
        }
    }
}
