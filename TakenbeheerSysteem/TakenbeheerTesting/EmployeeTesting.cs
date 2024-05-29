using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using TakenbeheerTesting.FakeRepos;

namespace TakenbeheerTesting
{
    public class EmployeeTesting
    {
        private EmployeeService _service = new EmployeeService(new EmployeeRepository());
        private EmployeeService _exceptionService = new EmployeeService(new EmployeeExceptionRepository());
    }
}
