using SimpleEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Contracts
{
  public  interface IProductService
    {
       List<Product> GetProducts();

        Product GetProduct(string id);

        Product AddProduct(Product product);

        string DeleteProduct(string id);
        Product UpdateProduct(string id, Product product);
    }
}
