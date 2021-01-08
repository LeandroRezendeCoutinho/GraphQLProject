using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _ProductService;

        public ProductsController(IProduct productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _ProductService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _ProductService.GetProductById(id);
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            _ProductService.AddProduct(product);
            return product;
        }

        [HttpPost("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            _ProductService.UpdateProduct(id, product);
            return product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ProductService.DeleteProduct(id);
        }
    }
}