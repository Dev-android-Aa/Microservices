using Catalog.Apis.Entities;

namespace Catalog.Apis.Repository
{
    public interface IProductRepository
    {
        //CRUD 

        Task CreateProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string Id);


        //+ byNAME + BY cAT
        Task<Product> GetProductById(string Id);
        Task<IEnumerable<Product>> GetProductByName(String name);
        Task<IEnumerable<Product>> GetProductByCategoryName(String Categoryname);


    }
}
