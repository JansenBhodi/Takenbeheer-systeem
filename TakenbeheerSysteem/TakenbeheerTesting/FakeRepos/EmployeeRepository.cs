using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;

namespace TakenbeheerTesting.FakeRepos
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public List<WorkerEmployeeDTO>? GetEmployees(int teamId)
        {
            if(teamId == 1)
            {
                return null;
            }
            if(teamId > 1)
            {
                return new List<WorkerEmployeeDTO>
                {
                    new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Bobby Carlson",
                        "Bobby@hotmail.com",
                        "Sorenstreet 28",
                        "4535 RK"),
                    new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Charly Main",
                        "Charly@gmail.com",
                        "Sorenstreet 18",
                        "4535 RK"),
                    new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Emilia Whitehouse",
                        "Emilia@hotmail.com",
                        "Sorenstreet 31",
                        "4535 RK")};
            }
            else
            {
                throw new Exception();
            }
        }

        public WorkerEmployeeDTO GetEmployee(int employeeId)
        {
            if (employeeId == 1)
            {
                return null;
            }
            if (employeeId > 1)
            {
                return new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Charly Main",
                        "Charly@gmail.com",
                        "Sorenstreet 18",
                        "4535 RK");
            }
            else
            {
                throw new Exception();
            }
        }
        public bool UpdateEmployee(WorkerEmployeeDTO employee)
        {
            if(employee.Id < 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateEmployee(WorkerEmployeeDTO employee)
        {
            return true;
        }
        public bool DeleteEmployee(int employeeId)
        {
            return true;
        }
        public bool DecoupleTasksByEmployeeId(int employeeId)
        {
            return true;
        }
        public int[] ValidateLogin(string email, string password)
        {
            return new int[]
            {
                1,
                2
            };
        }
        public List<WorkerEmployeeDTO> GetEmployeesByTaskId(int taskId)
        {
            return new List<WorkerEmployeeDTO>
                {
                    new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Bobby Carlson",
                        "Bobby@hotmail.com",
                        "Sorenstreet 28",
                        "4535 RK"),
                    new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Charly Main",
                        "Charly@gmail.com",
                        "Sorenstreet 18",
                        "4535 RK"),
                    new WorkerEmployeeDTO(
                        1,
                        1,
                        1,
                        "Emilia Whitehouse",
                        "Emilia@hotmail.com",
                        "Sorenstreet 31",
                        "4535 RK")};
        }
    }
}
