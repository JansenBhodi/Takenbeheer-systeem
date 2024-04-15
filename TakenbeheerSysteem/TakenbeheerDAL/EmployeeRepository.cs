using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using TakenbeheerDAL.Task;

namespace TakenbeheerDAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConn _conn = new DbConn();

        public EmployeeRepository()
        {

        }

        public List<WorkerEmployeeDTO> GetEmployees(int teamId)
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Employee " +
                                  "WHERE TeamID = @teamid";
            command.Parameters.AddWithValue("@teamid", teamId);

            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            List<WorkerEmployeeDTO> result = new List<WorkerEmployeeDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WorkerEmployeeDTO employee = new WorkerEmployeeDTO();
                employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                employee.Name = dt.Rows[i]["Name"].ToString();
                result.Add(employee);
            }

            _conn.ConnString.Close();
            return result;
        }

        public WorkerEmployeeDTO GetEmployee(int employeeId)
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Employee " +
                                  "WHERE ID = @employeeid";
            command.Parameters.AddWithValue("@employeeid", employeeId);

            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            WorkerEmployeeDTO result = new WorkerEmployeeDTO();
            for (int i = 0;i < dt.Rows.Count; i++)
            {
                result.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                result.Name = dt.Rows[i]["Name"].ToString();
            }

            _conn.ConnString.Close();
            return result;
        }

        public bool UpdateEmployee(WorkerEmployeeDTO employee)
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "UPDATE Employee " +
                                  "SET Name = @employeename " +
                                  "WHERE ID = @employeeid";
            command.Parameters.AddWithValue("@employeeid", employee.Id);
            command.Parameters.AddWithValue("@employeename", employee.Name);
            try
            {
                command.ExecuteNonQuery();
                _conn.ConnString.Close();
                return true;
            }
            catch (Exception)
            {
                _conn.ConnString.Close();
                return false;
            }
        }

        public bool CreateEmployee(WorkerEmployeeDTO employee)
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "INSERT INTO Employee " +
                                  "(ID, Name) " +
                                  "VALUES (@employeeid, @employeename)";
            command.Parameters.AddWithValue("@employeeid", employee.Id);
            command.Parameters.AddWithValue("@employeename", employee.Name);

            try
            {
                command.ExecuteNonQuery();
                _conn.ConnString.Close();
                return true;
            }
            catch (Exception)
            {
                _conn.ConnString.Close();
                return false;
            }
        }

        public bool DeleteEmployee(int employeeId) 
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "DELETE FROM Employee " +
                                  "WHERE ID = @employeeid";
            command.Parameters.AddWithValue("@employeeid", employeeId);
            try
            {
                command.ExecuteNonQuery();
                _conn.ConnString.Close();
                return true;
            }
            catch (Exception)
            {
                _conn.ConnString.Close();
                return false;
            }
        }
    }
}
