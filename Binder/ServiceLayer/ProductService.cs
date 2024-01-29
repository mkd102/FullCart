using InterfaceDAL;
using InterfaceService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        private IDAL<Product> _idal;
        public ProductService(IDAL<Product> idal) {
        this._idal = idal;
        } 
        public Product AddProduct(Product product)
        {
            return this._idal.Add(product);
        }

        public void DeleteProduct(Product product)
        {
             this._idal.Delete(product);
        }

        public List<Product> GetProducts()
        {
            return this._idal.GetAll();
        }

        public void UpdateProduct(Product product)
        {
             this._idal.Update(product);
        }
    }
}
