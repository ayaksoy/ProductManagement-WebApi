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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Task<string> AddAsync(Product product)
        {
            var result = "";
            if (product != null)
            {
                db.Products.Add(product);
                db.SaveChanges();
                result = "product Added Successfully";
            }
            else
                result = "product Not Added";
            return Task.FromResult(result);
        }

        public Task<string> DeleteById(int id)
        {
            var result = "";
            var product = db.Products.FirstOrDefault(x => x.Id == id && x.IsDelete != true);
            if (product != null)
            {
                product.IsDelete = true;
                db.SaveChanges();
                result = "product deleted successfully";
            }
            else
                result = "product not found";
            return Task.FromResult(result);

        }

        public Task<List<Product>> GetAllAsync()
        {
            var product = db.Products.Where(x => x.IsDelete == false).ToListAsync();
            return product;
        }

        public Task<List<Product>> GetAllCategoryProductAsync(int CategoryId)
        {
            var productList = db.Products.Where(x => !x.IsDelete && x.CategoryId == CategoryId).ToListAsync();
            return productList;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var productList = db.Products.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete != true);

            return productList;
        }

        public Task<string> UpdateAsync(Product product)
        {
            var updateProduct = db.Products.FirstOrDefault(x => x.Id == product.Id && !x.IsDelete);
            var result = "";
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Description = product.Description;
                updateProduct.IsStatus = product.IsStatus;
                updateProduct.Stock = product.Stock;
                updateProduct.Price = product.Price;
                updateProduct.CategoryId = product.CategoryId;

                db.SaveChanges();
                result = "product Updated Successfully";
            }
            else
                result = "product Not Updated";
            return Task.FromResult(result);

        }
    }
}