using Microsoft.AspNetCore.Mvc;

namespace Eticaret.magaza.Controllers
{
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet,Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
