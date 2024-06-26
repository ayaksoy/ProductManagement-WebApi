using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product_git.Model;
using Product_git.Service.Interface;

namespace Product_git.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await service.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Category> GetById(int id)
        {
            return await service.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<string> Post([FromBody] Category category)
        {
            var result = await service.AddAsync(category);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Category category)
        {
            category.Id = id;
            return await service.UpdateAsync(category);
        }
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await service.DeleteById(id);
        }


    }
}