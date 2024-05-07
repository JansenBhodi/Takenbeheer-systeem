using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Task;

namespace TakenbeheerCore.Employee
{
    public class WorkerEmployee
    {
        #region parameters

        private int _id;
        public int Id { get { return _id; } }

        private int _teamId;
        public int TeamId { get { return _teamId; } }

        private string _role;
        public string Role { get { return _role; } }

        private string _name;
        public string Name { get { return _name; } }

        private string _email;
        public string Email { get { return _email; } }

        private string _password;
        public string Password { get { return _password; } }

        private string _address;
        public string Address { get { return _address; } }

        private string _postalCode;
        public string PostalCode { get { return _postalCode; } }

        private List<Worktask>? _tasks;
        public List<Worktask>? Tasks { get { return _tasks; } }
        #endregion

        //From DTO
        public WorkerEmployee(WorkerEmployeeDTO entry)
        {
            _id = entry.Id;
            _teamId = entry.TeamId;
            _name = entry.Name;
            _email = entry.Email;
            _password = entry.Password;
            _address = entry.Address;
            _postalCode = entry.PostalCode;
            if(entry.Tasks != null)
            {
                foreach (TaskDTO task in entry.Tasks)
                {
                    Tasks.Add(new Worktask(task));
                }
            }
        }

        //Adding employee to team
        public WorkerEmployee(int teamId, string name, string email, string password, string address, string postalCode)
        {
            _teamId = teamId;
            _name = name;
            _email = email;
            _password = password;
            _address = address;
            _postalCode = postalCode;
        }

        //updating employee in team
        public WorkerEmployee(int id, string role, string name, string email, string password, string address, string postalCode)
        {
            _id = id;
            _role = role;
            _name = name;
            _email = email;
            _password = password;
            _address = address;
            _postalCode = postalCode;
        }
    }
}
