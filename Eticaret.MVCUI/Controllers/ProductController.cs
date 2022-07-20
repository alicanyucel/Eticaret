using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index(int page=1,int category=0)
        {
            int pageSize = 10;//her sayfada 10 tane ürün olacak
            var products = _productService.GetByCategory(category);
            ProductlistViewModel model = new ProductlistViewModel
            {
                //mwvcut gelen sayfa numarası kaçsa ilk sayfayı atla sayfalama yap
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList()

            };
            return View(model);
        }
    }
}
