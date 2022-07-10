using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.MVCUI.Controllers
{
   public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
           var products= _productService.GetAll();
            ProductlistViewModel model = new ProductlistViewModel
            {
                Products = products
            };
            return View(model);
        }
    }
}
