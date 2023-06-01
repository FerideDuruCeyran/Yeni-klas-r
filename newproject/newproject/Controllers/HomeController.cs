using Microsoft.AspNetCore.Mvc;
using newproject.Models;
using newproject.NewFolder;
using System.Data;
using System.Diagnostics;

namespace newproject.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            hesap hesap = new hesap();
            float bolson = hesap.bol(8, 2);
            int topson = hesap.top(7, 9);
            int carpson = hesap.car(6, 3);
            
           return View();
        }

    }
}