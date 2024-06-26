﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Employee
{
    public interface IEmployeeRepository
    {
        public List<WorkerEmployeeDTO>? GetEmployees(int teamId);
        public WorkerEmployeeDTO GetEmployee(int employeeId);
        public bool UpdateEmployee(WorkerEmployeeDTO employee);
        public bool CreateEmployee(WorkerEmployeeDTO employee);
        public bool DeleteEmployee(int employeeId);
        public bool DecoupleTasksByEmployeeId(int employeeId);
        public int[] ValidateLogin(string email, string password);
        public List<WorkerEmployeeDTO> GetEmployeesByTaskId(int taskId);

        public bool ConnectTaskWithEmployee(int empId, int taskId);
    }
}
