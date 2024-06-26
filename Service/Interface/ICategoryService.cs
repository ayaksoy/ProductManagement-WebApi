using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product_git.Model;

namespace Product_git.Service.Interface
{
    public interface ICategoryService
    {
        public Task<string> AddAsync(Category category);
        public Task<Category> GetByIdAsync(int id);
        public List<Category> GetAllAsync();
        public Task<string> UpdateAsync(Category category);
        public Task<string> DeleteById(int id);

    }
}