using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Configuration Code
            // ---------------------------------------------------------------------------
            // Configuration code

            var config = new ConfigurationBuilder()
                
                .SetBasePath(Directory.GetCurrentDirectory())
                
                .AddJsonFile("appsettings.json")
                
                .Build();
            
            string connString = config.GetConnectionString("DefaultConnection");
            // Console.WriteLine(connString);

            // ---------------------------------------------------------------------------
            #endregion
            
            IDbConnection connection = new MySqlConnection(connString);
            
            #region Departments

            

            
            DapperDepartmentRepository repo = new DapperDepartmentRepository(connection);

            Console.WriteLine("Hello user, here are the current departments:");
            Console.WriteLine("Please press enter . . .");
            Console.ReadLine();

            IEnumerable<Department> departments = repo.GetAllDepartments();

            Print(departments);
            

            Console.WriteLine("Do you want to add a department?");

            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department?");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }

            Console.WriteLine("Have a great day.");

            #endregion

            #region Products
            DapperProductRepository productRepository = new DapperProductRepository(connection);

            //Product productToUpdate = productRepository.GetProduct(940);
            //productRepository.UpdateProduct(productToUpdate);
            //productToUpdate.Name = "UPDATED!!!";
            //productToUpdate.Price = 12.99;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.OnSale = false;
            //productToUpdate.StockLevel = 1000;

            //productRepository.UpdateProduct(productToUpdate);

            productRepository.DeleteProduct(942);

            IEnumerable<Product> products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }

            #endregion
        }
        private static void Print(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }
        }
    }
}
