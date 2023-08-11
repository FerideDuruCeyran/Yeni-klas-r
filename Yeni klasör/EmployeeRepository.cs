using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Proje1.Model;

namespace DataBase
{
    public class EmployeeRepository : DatabaseConnection
    {
        public List<Employee> GetAll()
        {
            using SqlConnection conn = GetConnection;
            // SELECT * FROM Employee
            List<Employee> employees = conn.GetAll<Employee>().ToList();
            return employees;
        }

        public Employee Get(int id)
        {
            using SqlConnection conn = GetConnection;
            // SELECT * FROM Employee WHERE Id = 5
            Employee employee = conn.Get<Employee>(id);
            return employee;
        }
    }
}
