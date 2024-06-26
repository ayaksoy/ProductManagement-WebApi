using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product_git.Data;
using Product_git.Model;
using Product_git.Service.Interface;

namespace Product_git.Service.Model
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db){
            this.db = db;
        }
        public Task<string> AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}