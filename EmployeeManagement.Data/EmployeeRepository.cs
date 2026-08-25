using Dapper;
using EmployeeManagementPayrollSystemUI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conn")
                ?? throw new InvalidOperationException(
                    "Connection string 'conn' was not found.");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            using var connection = CreateConnection();

            return connection.Query<Employee>(
                "dbo.GetAllEmployees",
                commandType: CommandType.StoredProcedure
            );
        }

        public void Create(Employee employee)
        {
            using var connection = CreateConnection();
            connection.Execute(
                "dbo.CreateNewEmployee",
                new
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Email = employee.Email,
                    Salary = employee.Salary
                },
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateEmployee(Employee employee)
        {
            using var connection = CreateConnection();
            connection.Execute(
                "dbo.UpdateEmployee",
                new
                {
                    id = employee.Id,
                    firstName = employee.FirstName,
                    lastName = employee.LastName,
                    age = employee.Age,
                    email = employee.Email,
                    salary = employee.Salary
                },
                commandType: CommandType.StoredProcedure);
        }

        public Employee? GetEmployee(int id)
        {
            using var connection = CreateConnection();

            return connection.QuerySingleOrDefault<Employee>(
                "dbo.GetEmployeeById",
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public int DeactivateEmployee(int id)
        {
            using var connection = CreateConnection();
            return connection.Execute(
                "dbo.DeactivateEmployee",
                new
                {
                    id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}