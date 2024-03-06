using Back_Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Back_Employees.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"GET, POST, PUT, DELETE, OPTIONS")]
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<Employees> Get()
        {
            gestoEmployees gestoEmployees = new gestoEmployees();
            return gestoEmployees.getEmployees();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public bool Post([FromBody]Employees employees)
        {
            gestoEmployees gestoEmployees = new gestoEmployees();
            bool res = gestoEmployees.insertEmployees(employees);
            return res;
        }

        // PUT: api/Employee/5
        public bool Put(int id, [FromBody] Employees employees)
        {
            gestoEmployees gestoEmployees = new gestoEmployees();
            bool res = gestoEmployees.updateEmployees(id, employees);
            return res;
        }

        // DELETE: api/Employee/5
        public bool Delete(int id)
        {
            gestoEmployees gestoEmployees = new gestoEmployees();
            bool res = gestoEmployees.deleteEmployees(id);
            return res;
        }
    }
}
