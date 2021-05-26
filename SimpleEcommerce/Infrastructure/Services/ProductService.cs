using MongoDB.Driver;
using SimpleEcommerce.Entities;
using SimpleEcommerce.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;
       
        public ProductService(IDbClientService dbClientService, IConfigurationService configurationService)

        {


           _products = dbClientService.GetCollection<Product>(configurationService.GetAppsettingValueByKey("ProductCollectionName"));

          var x =  _products.Find(x => true);

           
        }

        public Product AddProduct(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public string DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string id)
        {
           return _products.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _products.Find(x => true).ToList();
        }

        public Product UpdateProduct(string id,Product product)
        {
            _products.ReplaceOne(x => x.Id == id, product);
            return product;
        }
    }
}




