using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Models;
using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.MVCUI.ViewComponents
{

    public class CategoryListViewComponent : ViewComponent
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
