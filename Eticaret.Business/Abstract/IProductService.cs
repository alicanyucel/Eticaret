using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Abstract
{
   public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryid);
        void Add(Product product);
        void Delete(int productid);
        void Update(Product product);
    }
}
