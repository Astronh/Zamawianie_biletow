using Microsoft.AspNetCore.Mvc;
using Zamawianie_biletow.Services.Interfaces;

namespace Zamawianie_biletow.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public ProductController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }   

        public IActionResult Index()
        {
            return View();
        }

    }
}
