using Catalog.Apis.Entities;
using MongoDB.Driver;

namespace Catalog.Apis.Shared
{
    public static class CatalogContextSeed
    {
        // add data where table empty
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfigureProducts());
            }

        }

        private static IEnumerable<Product> GetPreconfigureProducts()
        {

            return new List<Product>()
            {
                new Product{ Id = "215",
                Name = "Adil",
                Category = "fr",
                Summary = "hju",
                Description = "hhhh",
                ImageFile = "hhhh",
                Price = 415M },
                new Product{ Id = "215",
                Name = "Adil",
                Category = "fr",
                Summary = "hju",
                Description = "hhhh",
                ImageFile = "hhhh",
                Price = 415M }
            }.ToArray();

        }
    }
}
