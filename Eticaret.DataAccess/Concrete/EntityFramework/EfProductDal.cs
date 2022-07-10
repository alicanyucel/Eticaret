using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortWindContext>, IProductDal
    {
       
    }
}
