using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Zamawianie_biletow.Models;
using Zamawianie_biletow.Services;
using Zamawianie_biletow.Services.Interfaces;


namespace Zamawianie_biletow.Controllers
{
    
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private object dbContext;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Add(Product body)
        {
            if (!ModelState.IsValid)
            {
                return View(body);
            }
            var loggedInUser = User.Identity.Name;
            body.UserLogin = loggedInUser;

            var id = _warehouseService.Save(body);

            TempData["ProductId"] = id;

            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult List()
        {
            var loggedInUser = User.Identity.Name;
            var products = _warehouseService.GetProductsByUserLogin(loggedInUser);
            return View(products);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var products = _warehouseService.Get(id);
            return View(products);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("List");
        }
    }  
}
