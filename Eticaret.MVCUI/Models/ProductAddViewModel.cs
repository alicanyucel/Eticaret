using Eticaret.Entities.Concrete;
using System.Collections.Generic;

namespace Eticaret.MVCUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}
