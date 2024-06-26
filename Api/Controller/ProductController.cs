using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product_git.Model;
using Product_git.Service.Interface;

namespace Product_git.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await service.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await service.GetByIdAsync(id);
        }
        [HttpGet("categoryId")]
        public async Task<IEnumerable<Product>> GetByCategoryId(string cid)
        {
            return await service.GetAllCategoryProductAsync(Convert.ToInt32(cid));
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Product product)
        {
            var result = await service.AddAsync(product);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            return await service.UpdateAsync(product);
        }
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await service.DeleteById(id);
        }


    }
}