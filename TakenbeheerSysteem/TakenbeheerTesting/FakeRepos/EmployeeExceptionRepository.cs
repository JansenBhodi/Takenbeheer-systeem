using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;

namespace TakenbeheerTesting.FakeRepos
{
    public class EmployeeExceptionRepository : IEmployeeRepository
    {
        public List<WorkerEmployeeDTO> GetEmployees(int teamId)
        {
            if (teamId < 1)
            {
                throw new Exception("TeamId is invalid.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }

        public WorkerEmployeeDTO GetEmployee(int employeeId)
        {
            if (employeeId < 1)
            {
                throw new Exception("EmployeeID is invalid.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
        public bool UpdateEmployee(WorkerEmployeeDTO employee)
        {

            if (employee.Id < 1)
            {
                throw new Exception("employee has invalid data.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
        public bool CreateEmployee(WorkerEmployeeDTO employee)
        {
            if (employee.Id < 1)
            {
                throw new Exception("employee has invalid data.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
        public bool DeleteEmployee(int employeeId)
        {
            if (employeeId < 1)
            {
                throw new Exception("EmployeeID is invalid.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
        public bool DecoupleTasksByEmployeeId(int employeeId)
        {
            if (employeeId < 1)
            {
                throw new Exception("EmployeeID is invalid.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
        public int[] ValidateLogin(string email, string password)
        {
            if (email == "")
            {
                throw new Exception("login input does not conform to expected values.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
        public List<WorkerEmployeeDTO> GetEmployeesByTaskId(int taskId)
        {
            if (taskId < 1)
            {
                throw new Exception("TaskId is invalid.");
            }
            else
            {
                throw new Exception("Database encountered an error.");
            }
        }
    }
}
