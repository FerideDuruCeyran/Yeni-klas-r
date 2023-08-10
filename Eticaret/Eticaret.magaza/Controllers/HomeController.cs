using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Magaza.Controllers
{
    [Authorize, Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public async Task<IActionResult> Index()
        {
            Model.Kur? kur = await new Api.Kur().KurCek();
            return View();
        }
    }
}