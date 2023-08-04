
using Eticaret.Model;
using Eticaret.Web.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eticaret.Web.Controllers
{
   

    public class HomeController : Controller
    {
        
            private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
     public async Task<IActionResult> Index() 
        {
          List<Product>? urunler = await _productService.GetAllAsync();
            return View(urunler);
        }





    }
}