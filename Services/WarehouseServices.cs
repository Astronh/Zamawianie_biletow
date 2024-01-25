using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Zamawianie_biletow.Models;
using Zamawianie_biletow.Services.Interfaces;

namespace Zamawianie_biletow.Services
{
    public class WarehouseServices : IWarehouseService
    {
        private readonly DbTicket _context;

        public WarehouseServices(DbTicket context)
        {
            _context = context;
        }

        public Product Get(int id)
        {
            var product = _context.Products.Find(id);

            return product;
        }

        //public List<Product> GetAll() //Nie usuwać
        //{
        //    var products = _context.Products.ToList();

        //    return products;
        //}

        public int Save(Product product)
        {
            _context.Products.Add(product);

            if (_context.SaveChanges() > 0)
            {
                System.Console.WriteLine("SUKCES");
            }
            return product.Id;
        }

        public List<Product> GetProductsByUserLogin(string loggedInUser)
        {
            return _context.Products.Where(p => p.UserLogin == loggedInUser).ToList();
        }
    }
}
