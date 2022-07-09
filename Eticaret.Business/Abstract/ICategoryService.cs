using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> Getall();
    }
}
