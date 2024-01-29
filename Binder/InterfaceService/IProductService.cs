﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceService
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

    }
}
