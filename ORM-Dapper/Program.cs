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
            
            DapperDepartmentRepository repo = new DapperDepartmentRepository(connection);

            Console.WriteLine("Hello user, here are the current departments:");

            IEnumerable<Department> departments = repo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }
        }
    }
}
