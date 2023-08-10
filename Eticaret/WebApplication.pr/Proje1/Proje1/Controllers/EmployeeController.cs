using DataBase;
using Microsoft.AspNetCore.Mvc;
using Proje1.Model;

namespace Proje1.Controllers
{
    [Route("")]
    public class EmployeeController : Controller
    {
        [HttpGet, Route("")]
        public ViewResult Index()
        {
            EmployeeRepository employeeRepository = new();
            List<Employee> employees = employeeRepository.GetAll();
            return View(employees);
        }
    }
}

