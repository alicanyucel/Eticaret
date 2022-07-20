using Eticaret.Entities.Concrete;
using System.Collections.Generic;

namespace Eticaret.MVCUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get;  set; }
    }
}
