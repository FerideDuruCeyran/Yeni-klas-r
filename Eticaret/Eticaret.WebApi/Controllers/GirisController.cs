using Eticaret.Model;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.WebApi.Controllers
{
    [ApiController]
    [Route("giris")]
    public class GirisController : Controller
    {
        [HttpPost]
        [Route("kullanici")]
        public IActionResult Index(Login login)
        {
            return Ok(new {mesaj="giriş başarılı", eposta=login.Email});
        }
    }
}
