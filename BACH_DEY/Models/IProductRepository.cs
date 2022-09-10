using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
}
