using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using Dapper;
using AspNetCoreWebAPI.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreWebAPI.Services;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AspNetCoreWebAPI.Services
{
    public class ProductService
    {
    
        private readonly IDbConnection _connection;
        private object env;

        public IConfigurationRoot Configuration { get; }

        public ProductService(IOptions<ConnectionString> connectionString)
        {
            _connection = new MySqlConnection(connectionString.Value.ProjectConnection);
        }

        public List<Product> GetProducts()
        {
            string query = "SELECT * FROM Product";
            return _connection.Query<Product>(query).ToList();
        }

        public void AddProduct(Product product)
        {
            string query = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            _connection.Execute(query, product);
        }

        public void DeleteProduct(Int32 id)
        {
            string query = "DELETE FROM Product WHERE Id = @Id";
            _connection.Execute(query, new { Id = id });
        }

        public void UpdateProduct(Product product)
        {
            string query = "UPDATE Product SET Name = @Name, Price = @Price WHERE Id = @Id";
            _connection.Execute(query, product);
        }
    }
}