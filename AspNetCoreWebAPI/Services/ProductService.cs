using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AspNetCoreWebAPI.Models;

namespace AspNetCoreWebAPI.Services
{
    public class ProductService
    {
        List<Product> _productList;
        public ProductService()
        {
            _productList = new List<Product>();
        }

        public List<Product> GetProducts()
        {
            return _productList;
        }

        public void AddProduct(Product product)
        {
            _productList.Add(product);
        }

        public void DeleteProduct(double id)
        {
        _productList.Remove();
        }
        public void UpdateProduct(Product product)
        {
        _productList.Add(product);
        }
    }
}