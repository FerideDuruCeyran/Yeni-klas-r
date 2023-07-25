﻿using Microsoft.AspNetCore.Mvc;
using Eticaret.Model;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;
using Eticaret.magaza.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Eticaret.Magaza.Controllers
{
    [AllowAnonymous,Route("auth")]
    public class AuthenticationController : Controller
    {
        IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService= userService;
        }
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
                int ıd= await _userService.LoginAsync(login);
                if (ıd > 0)
                {
                    StringContent content = new(JsonConvert.SerializeObject(login),
                Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("https://localhost:7042/security/create-token", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Response.Cookies.Append("ETICARET", responseBody);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal());
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
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
