using Catalog.Apis.Data;
using Catalog.Apis.Entities;
using MongoDB.Driver;

namespace Catalog.Apis.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context;


        }
        public Task CreateProduct(Product product)
        {
            return _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string Id)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Id, Id);
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filterDefinition);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<IEnumerable<Product>> GetProductByCategoryName(string Categoryname)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Category, Categoryname);
            return await _context.Products.Find(filterDefinition).ToListAsync();
        }

        public async Task<Product> GetProductById(string Id)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Id, Id);
            return await _context.Products.Find(filterDefinition).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _context.Products.Find(filterDefinition).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(x => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context
                .Products
                .ReplaceOneAsync(filter: g => g.Id == product.Id, product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
