using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

       public static List<Employee> employee = new List<Employee>()
        {
            new Employee(){ ID=1,Name="aaa",Age=50,Salary=2000 },
            new Employee(){ID=2,Name="bbb",Age=60,Salary=3000},
            new Employee(){ID=3,Name="ccc",Age=70,Salary=4000},
            new Employee(){ID=4,Name="ddd",Age=80,Salary=5000}
        };

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
           
          return employee;
        }

        [HttpGet("{Id}")]
        public IEnumerable<Employee> Get(int Id)
        {
            var emp = employee.Where(X => X.ID == Id).Select(X => X);
            return emp;
        }
        
        [HttpPost]
        public bool Post([FromBody] Employee emp)
        {
            employee.Add(emp);
            
            return true;
        }

        [HttpPut]
        public bool Put([FromBody] Employee emp)
        {
            return true;
        }

        [HttpDelete("{Id}")]
        public bool Delete( int Id)
        {

            var emp = employee.Where(X => X.ID == Id).Select(X => X).ToList();
           // var em = emp.Select(X => X).FirstOrDefault<Employee>();
            foreach (Employee e in emp)
            {
                var emp1 = employee.Remove(e);
            }
                return true;
        }
    }

    internal interface IEnumerbale<T>
    {
    }
}
