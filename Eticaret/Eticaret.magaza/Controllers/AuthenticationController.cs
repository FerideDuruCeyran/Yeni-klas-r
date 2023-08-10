using Microsoft.AspNetCore.Mvc;
using Eticaret.Model;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using Eticaret.Magaza.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Eticaret.Magaza.Controllers
{
    [AllowAnonymous, Route("auth")]
    public class AuthenticationController : Controller
    {
        IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(Login login)
        {
            // Garbage Collector (Çöp Toplayıcı)
            using (HttpClient client = new())
            {
                int id = await _userService.LoginAsync(login);

                if (id > 0)
                {
                    StringContent content = new(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("https://localhost:7042/security/create-token", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        List<Claim> claims = new()
                        {
                            new Claim("token", responseBody),
                        };

                        ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        Response.Cookies.Append("ETICARET", responseBody);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity),
                            new AuthenticationProperties() { }
                            );

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ViewBag.HataliGiris = true;
                    return View();
                }
            }
        }

        [HttpGet, Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Authentication");
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
