using Microsoft.EntityFrameworkCore;
using SmartStocker.Abscrations;
using SmartStocker.Models;

namespace SmartStocker.Services
{
    public class ProductService(AppDbContext context) : ICrud<Product>
    {
        public async Task<List<Product>> GetT(int id = 0)
        {

            if (id != 0)
            {
                return await context.Products.Where(i => i.Id == id).ToListAsync();
            }
            if (id == 0)
            {
                return await context.Products.ToListAsync();
            }
            throw new Exception("Id value was invalid");
        }

        public Task<Product> DeleteT(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> SetT(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateT(int id)
        {
            throw new NotImplementedException();
        }
    }
}
