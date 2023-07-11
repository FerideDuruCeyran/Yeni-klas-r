using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eticaret.Magaza.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}