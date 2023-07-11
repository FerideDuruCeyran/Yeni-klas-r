using Microsoft.AspNetCore.Mvc;
using Eticaret.Model;

namespace Eticaret.Magaza.Controllers
{
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        [HttpGet, Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public IActionResult Login(Login login)
        {
            if (login.Email == "oguzhankrg4@gmail.com" && login.Password == "123")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya parola hatalı";
                return View();
            }
        }

        [HttpGet, Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, Route("register")]
        public IActionResult Register(Register register)
        {
            return RedirectToAction("Login");
        }
    }
}
