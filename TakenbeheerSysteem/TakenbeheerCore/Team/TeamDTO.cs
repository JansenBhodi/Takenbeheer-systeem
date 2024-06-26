﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;

namespace TakenbeheerCore.Team
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public List<WorkerEmployeeDTO>? Employees { get; set; }

        //Overview employee page
        public TeamDTO(int id, string name, string address, string postalCode)
        {
            Id = id;
            Name = name;
            Address = address;
            PostalCode = postalCode;
        }

        //When updating team to database
        public TeamDTO(TeamModel team)
        {

            Id = team.Id;
            Name = team.Name;
            Address = team.Address;
            PostalCode = team.PostalCode;
            if(team.Employees != null)
            {
                foreach (WorkerEmployee employee in team.Employees)
                {
                    Employees.Add(new WorkerEmployeeDTO(employee));
                }
            }
        }
    }
}
