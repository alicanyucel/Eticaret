using Eticaret.Entities.Concrete;
using System.Collections.Generic;

namespace Eticaret.MVCUI.Models
{
    public class ProductlistViewModel
    {
        public List<Product> Products { get;  set; }
        public int PageCount { get;  set; }
        public int CurrentPage { get; set; }
        public int CurrentCategory { get;  set; }
        public int PageSize { get;  set; }
    }
}
