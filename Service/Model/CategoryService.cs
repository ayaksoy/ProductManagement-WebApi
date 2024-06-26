using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_git.Data;
using Product_git.Model;
using Product_git.Service.Interface;

namespace Product_git.Service.Model
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Task<string> AddAsync(Category category)
        {
            var result = "";
            if (category != null)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                result = "Category Added Successfully";
            }
            else
                result = "Category Not Added";
            return Task.FromResult(result);
        }

        public Task<string> DeleteById(int id)
        {
            var result = "";
            var category = db.Categories.FirstOrDefault(x => x.Id == id && x.IsDelete != true);
            if (category != null)
            {
                category.IsDelete = true;
                db.SaveChanges();
                result = "Category deleted successfully";
            }
            else
                result = "Category not found";
            return Task.FromResult(result);

        }

        public Task<List<Category>> GetAllAsync()
        {
            var categoryList = db.Categories.Where(x => x.IsDelete == false).ToListAsync();
            return categoryList;
        }

        public Task<Category> GetByIdAsync(int id)
        {
            var category = db.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete != true);

            return category;
        }

        public Task<string> UpdateAsync(Category category)
        {
            var updateCategory = db.Categories.FirstOrDefault(x => x.Id == category.Id && !x.IsDelete);
            var result = "";
            if (updateCategory != null)
            {
                updateCategory.Name = category.Name;
                updateCategory.Description = category.Description;
                updateCategory.IsStatus = category.IsStatus;
                db.SaveChanges();
                result = "Category Updated Successfully";
            }
            else
                result = "Category Not Updated";
            return Task.FromResult(result);

        }
    }
}