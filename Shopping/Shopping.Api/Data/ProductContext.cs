using MongoDB.Driver;
using Shopping.Api.Models;

namespace Shopping.Api.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        private void SeedData(IMongoCollection<Product> productCollection)
        {
            var productsDatabase = productCollection.Find(x => true).Any();
            if (productsDatabase)
                return;

            productCollection.InsertMany(InitialProducts);
        }

        public static readonly List<Product> InitialProducts = new()
        {
            new Product
            {
                Name = "IPhone X",
                Description =
                    "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                ImageFile = "product-1.png",
                Price = 999.00M,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "Samsung 10",
                Description =
                    "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                ImageFile = "product-2.png",
                Price = 899.00M,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "Huawei Plus",
                Description =
                    "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                ImageFile = "product-3.png",
                Price = 699.00M,
                Category = "White Appliances"
            },
            new Product
            {
                Name = "Xiaomi Mi 9",
                Description =
                    "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                ImageFile = "product-4.png",
                Price = 499.00M,
                Category = "White Appliances"
            },
            new Product
            {
                Name = "HTC U11+ Plus",
                Description =
                    "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                ImageFile = "product-5.png",
                Price = 399.00M,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "LG G7 ThinQ New8",
                Description =
                    "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                ImageFile = "product-6.png",
                Price = 299.00M,
                Category = "Home Kitchen"
            }
        };
    }
}
