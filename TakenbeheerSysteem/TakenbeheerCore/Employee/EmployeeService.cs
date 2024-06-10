using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Employee
{
    public class EmployeeService
    {
        private IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _employeeRepo = repo;
        }

        public List<WorkerEmployee> GetEmployees(int teamId)
        {
            List<WorkerEmployee> result = new List<WorkerEmployee>();

            List<WorkerEmployeeDTO> dbEntries = _employeeRepo.GetEmployees(teamId);

            foreach (WorkerEmployeeDTO dbEntry in dbEntries)
            {
                result.Add(new WorkerEmployee(dbEntry));
            }

            return result;
        }

        public bool ConnectEmployeeWithTask(int empId, int taskId)
        {
            bool result = false;
            try
            {
                result = _employeeRepo.ConnectTaskWithEmployee(empId, taskId);
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }

        public List<WorkerEmployee> GetEmployeesByTaskId(int taskId)
		{
			List<WorkerEmployee> result = new List<WorkerEmployee>();

			List<WorkerEmployeeDTO> dbEntries = _employeeRepo.GetEmployeesByTaskId(taskId);

			foreach (WorkerEmployeeDTO dbEntry in dbEntries)
			{
				result.Add(new WorkerEmployee(dbEntry));
			}

			return result;
		}

        public WorkerEmployee GetEmployee(int employeeId)
        {
            WorkerEmployee employee;
            try
            {
                employee = new WorkerEmployee(_employeeRepo.GetEmployee(employeeId));
            }
            catch (Exception)
            {
                
                throw;
            }
            
            return employee;
        }

        public bool UpdateEmployee(WorkerEmployee employee)
        {
            WorkerEmployeeDTO input = new WorkerEmployeeDTO(employee);

            try
            {
                return _employeeRepo.UpdateEmployee(input);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                return _employeeRepo.DeleteEmployee(employeeId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DecoupleTasksForEmployee(int employeeId)
        {
            try
            {
                return _employeeRepo.DecoupleTasksByEmployeeId(employeeId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateEmployee(WorkerEmployee employee)
        {
            WorkerEmployeeDTO employeeDTO = new WorkerEmployeeDTO(employee);

            try
            {
                return _employeeRepo.CreateEmployee(employeeDTO);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int[]? AttemptLogin(string email, string password)
        {
            int[]? result = null;
            try
            {
                result = _employeeRepo.ValidateLogin(email, password);
            }
            catch (Exception)
            {

                return null;
            }

            return result;
        }
    }
}
