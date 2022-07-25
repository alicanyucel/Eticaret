using Eticaret.Business.Abstract;
using Eticaret.Entities.Concrete;
using Eticaret.MVCUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.MVCUI.Controllers
{
    public class AdminController : Controller
    {
      
         private IProductService _productservice;
        public AdminController(IProductService productService)
        {
            _productservice = productService;
        }
        public IActionResult Index()
        {
            var productListViewModel = new ProductlistViewModel()
            {
                Products = _productservice.GetAll()
            };
            return View(productListViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if(!ModelState.IsValid)
            {
                _productservice.Add(product);
                TempData.Add("message", "eklendi");
            }
           
            return View();
        }
    }
}
