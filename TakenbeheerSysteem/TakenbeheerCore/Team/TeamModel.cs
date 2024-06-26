﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;

namespace TakenbeheerCore.Team
{
    public class TeamModel
    {
        private int _id;
        public int Id { get { return _id; } }
        
        private string _name;
        public string Name { get { return _name; } }

        private string _address;
        public string Address { get { return _address; } }

        private string _postalCode;
        public string PostalCode { get { return _postalCode; } }

        private List<WorkerEmployee>? _employees;
        public List<WorkerEmployee>? Employees { get { return _employees; } }

        public TeamModel(TeamDTO team)
        {
            _id = team.Id;
            _name = team.Name;
            _address = team.Address;
            _postalCode = team.PostalCode;
            if(team.Employees != null)
            {
                foreach (WorkerEmployeeDTO employee in team.Employees)
                {
                    _employees.Add(new WorkerEmployee(employee));
                }
            }
        }

        //Create and Edit
        public TeamModel(int id, string name, string address, string postalcode) 
        {
            _id = id;
            _name = name;
            _address = address;
            _postalCode = postalcode;
        }
    }
}
