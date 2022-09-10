using BACH_DEY.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.Models
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public SqlProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public Product Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            var product = _context.products.Where(x => x.ID == id).First();
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        public Product GetProduct(int id)
        {
            return _context.products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.products;
        }

        public Product Update(Product product)
        {
            var data = _context.products.Attach(product);
            data.State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }

}
