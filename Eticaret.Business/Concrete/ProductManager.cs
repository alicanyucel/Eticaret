using Eticaret.Business.Abstract;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFramework;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;
        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }
        public void Add(Product product)
        {
            _productdal.Add(product);
        }

        public void Delete(int productid)
        {
            _productdal.Delete(new Product { ProductId=productid});
        }

        public List<Product> GetAll()
        {
            return _productdal.GetList();
        }

        public List<Product> GetByCategory(int categoryid)
        {
            return _productdal.GetList(p => p.CategoryId == categoryid);
        }

        public void Update(Product product)
        {
            _productdal.Update(product);
        }
    }
}