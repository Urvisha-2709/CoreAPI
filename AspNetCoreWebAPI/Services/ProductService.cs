using System;
using System.Collections.Generic;
using System.Linq;
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
            Product productToRemove = _productList.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                _productList.Remove(productToRemove);
            }
        }

        public void UpdateProduct(Product product)
        {
            DeleteProduct(product.Id);
            AddProduct(product);
        }
    }
}
