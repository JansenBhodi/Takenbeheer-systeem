using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Task;

namespace TakenbeheerCore.Employee
{
    public class WorkerEmployeeDTO
    {
        #region parameters
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public List<TaskDTO>? Tasks { get; set; }


        #endregion

        //Employee data for detail page
        public WorkerEmployeeDTO(int id, int teamId, string role, string name, string email, string address, string postalCode)
        {
            Id = id; 
            TeamId = teamId; 
            Role = role; 
            Name = name; 
            Email = email; 
            Address = address; 
            PostalCode = postalCode; 
        }

        //Login check
        public WorkerEmployeeDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        //Employee data for task detail
        public WorkerEmployeeDTO(int id, int teamId, string role, string name)
        {
            Id = id;
            TeamId = teamId;
            Role = role;
            Name = name;
        }

        //Employee for team detail
        public WorkerEmployeeDTO(int id, int teamid, string role, string name, string email)
        {
            Id = id;
            TeamId = teamid;
            Role = role;
            Name = name;
            Email = email;
        }

        //Update/Create employee in existing team
        public WorkerEmployeeDTO(WorkerEmployee employee)
        {
            if (employee.Id != 0)
            {
                Id = employee.Id;
                Role = employee.Role;
            }
            else
            {
                Role = "Worker";
            }
            Name = employee.Name;
            Email = employee.Email;
            Password = employee.Password;
            Address = employee.Address;
            PostalCode = employee.PostalCode;
        }
    }
}
