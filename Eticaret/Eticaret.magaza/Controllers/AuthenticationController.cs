using Microsoft.AspNetCore.Mvc;
using Eticaret.Model;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;

namespace Eticaret.Magaza.Controllers
{
    [AllowAnonymous,Route("auth")]
    public class AuthenticationController : Controller
    {
        [HttpGet, Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(Login login)
        {
            //(Garbage Collector=Çöp Toplayıcı)
                using(HttpClient client = new())
            {
                StringContent content=new(JsonConvert.SerializeObject(login),
                 Encoding.UTF8,"application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:7042/security/create-token", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody=await response.Content.ReadAsStringAsync();
                }
            }
                return View();
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
