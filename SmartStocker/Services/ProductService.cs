using Microsoft.EntityFrameworkCore;
using SmartStocker.Abscrations;
using SmartStocker.Models.DTOs;
using SmartStocker.Models.Entities;

namespace SmartStocker.Services
{
    public class ProductService(AppDbContext context) : ICrud<Product>
    {
        public async Task<List<Product>> GetT()
        {
            return await context.Products.Where(i => i.Inactive == true).ToListAsync();
        }

        public async Task<Product?> GetTById(int id)
        {
            return await context.Products.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetTInative()
        {
            return await context.Products.Where(i => i.Inactive == false).ToListAsync();
        }

        public async Task<Product> DeleteT(int id)
        {
            var section = await GetTById(id);
            if (section == null) throw new Exception("Section was null");
            if (!section.Inactive) throw new Exception("Section was already null");

            section.Inactive = false;
            var effectedRows = context.SaveChanges();

            if (effectedRows == 0) throw new Exception("Section was not updated");
            return section;
        }

        public async Task<Product> CreateT(Product product)
        {
            context.Products.Add(product);
            var affectedRows = await context.SaveChangesAsync();
            if (affectedRows == 0) throw new Exception("Exam was not created");
            return product;
        }

        public async Task<Product> UpdateT(Product model)
        {
            var section = await GetTById(model.Id);
            if (section == null) throw new Exception("Section was null");
            if (!section.Inactive) throw new Exception("Section was already null");

            section = model;
            var effectedRows = context.SaveChanges();

            if (effectedRows == 0) throw new Exception("Section was not updated");
            return section;
        }
    }
}
