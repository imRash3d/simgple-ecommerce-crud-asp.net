using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Dtos;
using SimpleEcommerce.Entities;
using SimpleEcommerce.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
       public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
           
            return await Task.FromResult(this.productService.GetProducts());
            

        }

        // api/product/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            Product product = new Product
            {
                Id = "232131",
                Name = "T shirt"
            };
             
            return await Task.FromResult(product); 
        }

        [HttpPost]
        //
        public async Task<ActionResult<Product>> CreateProduct(ProductDto productDto)
        {
            Product product = new Product
            {
               
                Name = productDto.Name

            };

         
            var result = this.productService.AddProduct(product);
            return await Task.FromResult(result);

        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(string id, ProductDto productDto)
        {
            Product product = new Product { 
            Name= productDto.Name,
            Id= id
            };
            var result = this.productService.UpdateProduct(id, product);

            return await Task.FromResult(result);
        }


    }
}
