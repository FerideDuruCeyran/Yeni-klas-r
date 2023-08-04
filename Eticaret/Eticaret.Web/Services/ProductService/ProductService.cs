using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Web.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly MainDatabaseContext _context;

        public ProductService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetAsync(int id)
        {
            // SELECT * FROM Product WHERE Id = 1
            Product? product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            return product;
        }

        public async Task<List<Product>?> GetAllAsync()
        {
            // SELECT * FROM Product
            List<Product>? products = await _context.Product.Where(m => m.Status != 0).ToListAsync();
            return products;
        }

        public async Task<int> CreateAsync(Product model)
        {
            /*
             Id: 0
             Name: 'Laptop'
             Price: 50990.90
             */

            // INSERT INTO Product VALUES(..., ..., ...)
            await _context.Product.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<bool> UpdateAsync(Product model)
        {
            // SELECT * FROM Product WHER Id = 5
            Product? product = await _context.Product.SingleOrDefaultAsync(m => m.Id == model.Id);

            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.ImageName = model.ImageName;

                // UPDATE Product SET Name = 'Laptop', Price = 55000 WHERE Id = 5
                _context.Update(product);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // SELECT * FROM Product WHER Id = 5
            Product? product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);

            if (product != null)
            {
                product.Status = 0;

                // UPDATE Product SET Name = 'Laptop', Price = 55000 WHERE Id = 5
                _context.Update(product);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
