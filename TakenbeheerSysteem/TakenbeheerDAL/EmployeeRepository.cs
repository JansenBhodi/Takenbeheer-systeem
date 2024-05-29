using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using MySqlConnector;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.Logging;

namespace TakenbeheerDAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConn _conn = new DbConn();
        private ILogger _logger;
        public EmployeeRepository(ILogger logger)
        {
            _logger = logger;
        }

		public List<WorkerEmployeeDTO> GetEmployeesByTaskId(int taskId)
		{
			_conn.ConnString.Open();

			SqlCommand command = _conn.ConnString.CreateCommand();
			command.CommandText = "SELECT * FROM Employee e " +
                                  "INNER JOIN TaskEmployeeConnector t ON e.Id = t.EmployeeId " +
								  "WHERE t.TaskId = @taskid";
			command.Parameters.AddWithValue("@taskid", taskId);

			List<WorkerEmployeeDTO> result = new List<WorkerEmployeeDTO>();

			try
			{
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						WorkerEmployeeDTO entry = new WorkerEmployeeDTO(
							reader.GetInt32("Id"),
							reader.GetInt32("TeamID"),
							reader.GetInt32("Role"),
							reader.GetString("Name"),
							reader.GetString("Email"));
						result.Add(entry);
					}
				}
			}
			catch (Exception)
			{
				result = null;

			}
			finally
			{
				_conn.ConnString.Close();
			}

			return result;
		}

		public List<WorkerEmployeeDTO> GetEmployees(int teamId)
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Employee " +
                                  "WHERE TeamID = @teamid";
            command.Parameters.AddWithValue("@teamid", teamId);

            List<WorkerEmployeeDTO> result = new List<WorkerEmployeeDTO>();

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WorkerEmployeeDTO entry = new WorkerEmployeeDTO(
                            reader.GetInt32("Id"),
                            reader.GetInt32("TeamID"),
                            reader.GetInt32("Role"),
                            reader.GetString("Name"),
                            reader.GetString("Email"));
                        result.Add(entry);
                    }
                }
            }
            catch (Exception)
            {
                result = null;
                
            }
            finally
            {
                _conn.ConnString.Close();
            }

            return result;
        }

        public WorkerEmployeeDTO? GetEmployee(int employeeId)
        {
            _conn.ConnString.Open();
            WorkerEmployeeDTO result = null;

            SqlCommand employeecmd = _conn.ConnString.CreateCommand();
            employeecmd.CommandText = "SELECT * FROM Employee " +
                                  "WHERE ID = @employeeid";
            employeecmd.Parameters.AddWithValue("@employeeid", employeeId);

            try
            {
                using (SqlDataReader employeeReader = employeecmd.ExecuteReader())
                {
                    while (employeeReader.Read())
                    {
                        result = new WorkerEmployeeDTO(
                            employeeReader.GetInt32("Id"),
                            employeeReader.GetInt32("TeamID"),
                            employeeReader.GetInt32("Role"),
                            employeeReader.GetString("Name"),
                            employeeReader.GetString("Email"),
                            employeeReader.GetString("Address"),
                            employeeReader.GetString("PostalCode"));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            _conn.ConnString.Close();
            return result;
        }

        public bool UpdateEmployee(WorkerEmployeeDTO employee)
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "UPDATE Employee " +
                                  "SET Name = @name, Role = @role, Email = @email, Address = @address, PostalCode = @postalcode " +
                                  "WHERE ID = @id";
            command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@role", employee.Role);
            command.Parameters.AddWithValue("@address", employee.Address);
            command.Parameters.AddWithValue("@email", employee.Email);
            command.Parameters.AddWithValue("@postalcode", employee.PostalCode);
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
                                  "(TeamId, Name, Role, Email, Password, Address, PostalCode) " +
                                  "VALUES (@teamid, @name, @role, @email, @password, @adddress, @postalcode)";
            command.Parameters.AddWithValue("@teamid", employee.TeamId);
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@role", employee.Role);
            command.Parameters.AddWithValue("@email", employee.Email);
            command.Parameters.AddWithValue("@password", employee.Password);
            command.Parameters.AddWithValue("@adddress", employee.Address);
            command.Parameters.AddWithValue("@postalcode", employee.PostalCode);

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

        public bool DecoupleTasksByEmployeeId(int employeeId)
        {
            _conn.ConnString.Open();

            SqlCommand cmd = _conn.ConnString.CreateCommand();
            cmd.CommandText = "DELETE FROM EmployeeTaskConnector " +
                              "WHERE EmployeeId = @id";
            cmd.Parameters.AddWithValue("@id", employeeId);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                _conn.ConnString.Close();
                return false;
            }
            finally
            {
                _conn.ConnString.Close();
            }
            return true;
        }

        public int[]? ValidateLogin(string email, string password)
        {
            int[] result = new int[2];

            using (SqlCommand cmd = _conn.ConnString.CreateCommand())
            {
                _conn.ConnString.Open();
                cmd.CommandText = "SELECT Id, Email, Role FROM Employee " +
                                  "WHERE Email = @email AND Password = @password";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int validator = 0;
                        while(reader.Read())
                        {
                            if(email == reader.GetString("Email"))
                            {
                                result[0] = reader.GetInt32("Id");
                                result[1] = reader.GetInt32("Role");
                                validator++;
                            }
                        }
                        if(validator == 0)
                        {
                            _conn.ConnString.Close();
                            _logger.Log(LogLevel.Information, "Login failed, login details were incorrect");
                            return null;
                        }

                    }
                }
                catch (Exception)
                {
                    _conn.ConnString.Close();
                    return null;
                }
            }
            _conn.ConnString.Close();
            return result;
        }
    }
}
