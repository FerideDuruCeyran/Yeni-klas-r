
using Microsoft.AspNetCore.Mvc;


namespace Eticaret.magaza.Controllers
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