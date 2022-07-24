using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Eticaret.MVCUI.Controllers
{
   public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var products = _productService.GetByCategory(category);
            ProductlistViewModel model = new ProductlistViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
            };
            return View(model);
        }
        // sesionlarda object tutamazssınız desarlize ve serialize etmek lazmm
        /*public string Session()
        {
            HttpContext.Session.SetString("city","Ankara");
            HttpContext.Session.SetInt32("age",32);

            HttpContext.Session.GetString("city");
            HttpContext.Session.GetInt32("age");
        } */
       

    }
}
