using Microsoft.Extensions.DependencyInjection;
using AspNetCoreWebAPI.Services;

namespace AspNetCoreWebAPI.Models
{
    public class Product
    {
        public Product(string name, double price, double id) 
        {
            this.Name = name;
                this.Price = price; 
                this.Id =  id;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Id { get; set; }
    }
}