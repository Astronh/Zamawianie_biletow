using Microsoft.AspNetCore.Identity;
using Zamawianie_biletow.Models;

namespace Zamawianie_biletow.Services.Interfaces
{
    public interface IWarehouseService
    {
        int Save(Product product);
        //List<Product> GetAll(); //Nie usuwać
        Product Get(int id);
        List<Product> GetProductsByUserLogin(string loggedInUser);
    }
}
