using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Models;
using System;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Eticaret.MVCUI.ViewComponent
{
    public class CategoryListViewComponent:ViewComponent
    {

        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public  ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.Getall()
            };
            return View(model);
        }
    }
}
