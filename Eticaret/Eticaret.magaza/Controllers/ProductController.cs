﻿using Microsoft.AspNetCore.Mvc;
using Eticaret.Model;
using Eticaret.Magaza.Services;
using Microsoft.AspNetCore.Authorization;

namespace Eticaret.Magaza.Controllers
{
    [Authorize, Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Index()
        {
            List<Product>? products = await _productService.GetAllAsync();
            return View(products);
        }

        [HttpGet, Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _productService.GetAsync(id);
            return View(product);
        }

        [HttpPost, Route("edit")]
        public async Task<IActionResult> Update(Product model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                Guid guid = Guid.NewGuid();
                string gorselAdi = Convert.ToBase64String(guid.ToByteArray());
                gorselAdi = gorselAdi.Replace("+", "");
                gorselAdi = gorselAdi.Replace("=", "");
                gorselAdi = gorselAdi.Replace("\\", "");
                gorselAdi += "." + image.FileName.Split('.')[1];

                string gorselYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", gorselAdi);

                using (FileStream fs = new FileStream(gorselYolu, FileMode.Create))
                {
                    await image.CopyToAsync(fs);
                    model.ImageName = gorselAdi;
                }
            }

            await _productService.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("new")]
        public async Task<IActionResult> New()
        {
            Kur? kur = await new Api.Kur().KurCek();
            ViewBag.Kur = kur.Data.TRY.Value;
            return View();
        }

        [HttpPost, Route("new")]
        public async Task<IActionResult> New(Product model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                Guid guid = Guid.NewGuid();
                string gorselAdi = Convert.ToBase64String(guid.ToByteArray());
                gorselAdi = gorselAdi.Replace("+", "");
                gorselAdi = gorselAdi.Replace("=", "");
                gorselAdi += "." + image.FileName.Split('.')[1];

                string gorselYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", gorselAdi);

                using (FileStream fs = new FileStream(gorselYolu, FileMode.Create))
                {
                    await image.CopyToAsync(fs);
                    model.ImageName = gorselAdi;
                }
            }

            await _productService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Json(true);
        }
    }
}
