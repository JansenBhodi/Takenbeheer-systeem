using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TakenbeheerCore.Task;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using TakenbeheerCore.Employee;

namespace TakenbeheerDAL
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbConn _conn = new DbConn();
        private readonly ILogger _logger;
        public TaskRepository(ILogger logger)
        {
            _logger = logger;
        }

        public TaskDTO? GetTaskById(int id)
        {
            TaskDTO result = null;
            using(SqlCommand cmd = _conn.ConnString.CreateCommand())
            {
                try
                {
                    _conn.ConnString.Open();
                }
                catch (Exception)
                {

                    return null;
                }

                cmd.CommandText = "SELECT * FROM Task " +
                                  "WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                try
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							result = new TaskDTO(
								reader.GetInt32("Id"),
								reader.GetString("Title"),
								reader.GetString("Description"),
								reader.GetInt32("Progress"),
								DateOnly.FromDateTime(reader.GetDateTime("Deadline")),
								reader.GetBoolean("IsVisible"));
						}
					}
				}
                catch (Exception)
                {
                    _conn.ConnString.Close();
                    return null;
                }
                finally
                {
                    _conn.ConnString.Close();
                }
                return result;
            }
        }

        public List<TaskDTO>? GetTasksByTeamExcludingEmployee(int teamId, int employeeId) 
        {
            List<TaskDTO>? result = new List<TaskDTO>();

            using(SqlCommand cmd = _conn.ConnString.CreateCommand())
            {
                try
                {
                    _conn.ConnString.Open();
                }
                catch (Exception ex)
                {
                    return null;
                    throw;
                }

                cmd.CommandText = "SELECT t.* FROM Task t " +
                                  "WHERE t.TeamId = @teamid " +
                                  "AND t.id NOT IN ( " +
                                  "SELECT c.TaskId FROM TaskEmployeeConnector c " +
                                  "WHERE c.EmployeeId = @employeeid)";
                cmd.Parameters.AddWithValue("@teamid", teamId);
                cmd.Parameters.AddWithValue("@employeeid", employeeId);

                try
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskDTO input = new TaskDTO(
								reader.GetInt32("Id"),
								reader.GetString("Title"),
								reader.GetString("Description"),
								reader.GetInt32("Progress"),
								DateOnly.FromDateTime(reader.GetDateTime("Deadline")),
								reader.GetBoolean("IsVisible"));
                            result.Add(input);
                        }
                    }
                }
                catch (Exception)
                {
                    _conn.ConnString.Close();
                    return null;
                    throw;
                }
                finally
                {
                    _conn.ConnString.Close();
                }
            }

            return result;
        }

        public List<TaskDTO>? ReturnAllTasks(int empId)
        {
            List<TaskDTO> result = new List<TaskDTO>();
            using(SqlCommand command = _conn.ConnString.CreateCommand())
            {
                try
                {
                    _conn.ConnString.Open();
                }
                catch (Exception)
                {

                    return null;
                }

                command.CommandText = "SELECT * FROM Task " +
                                      "WHERE TeamId = (SELECT TeamId FROM Employee " +
                                      "WHERE Id = @id)";
                command.Parameters.AddWithValue("@id", empId);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        dt.Load(reader);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TaskDTO task = new TaskDTO(
                                Convert.ToInt32(dt.Rows[i]["Id"]),
                                dt.Rows[i]["Title"].ToString(),
                                dt.Rows[i]["Description"].ToString(),
                                Convert.ToInt32(dt.Rows[i]["Progress"]),
                                DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["Deadline"])),
                                Convert.ToBoolean(dt.Rows[i]["IsVisible"]));
                            result.Add(task);
                            _logger.LogInformation("Succesfully added task to list.");
                        }
                    }
                    catch (Exception)
                    {
                        _conn.ConnString.Close();
                        return null;
                    }
                    finally
                    {
                        _conn.ConnString.Close();
                    }
                }

            }

            return result;
        }

        public List<TaskDTO>? GetTasksByEmployee(int empId)
        {
            List<TaskDTO>? result = new List<TaskDTO>();

            using (SqlCommand cmd = _conn.ConnString.CreateCommand())
            {

                try
                {
                    _conn.ConnString.Open();
                }
                catch(Exception)
                {
                    return null;
                }

                cmd.CommandText = "SELECT * FROM Task t " +
                                  "INNER JOIN TaskEmployeeConnector c ON t.Id = c.TaskId " +
                                  "WHERE c.EmployeeId = @id";
                cmd.Parameters.AddWithValue("@id", empId);


				try
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							TaskDTO entry = new TaskDTO(
								reader.GetInt32("Id"),
								reader.GetString("Title"),
								reader.GetString("Description"),
								reader.GetInt32("Progress"),
								DateOnly.FromDateTime(reader.GetDateTime("Deadline")),
								reader.GetBoolean("IsVisible"));
							result.Add(entry);
						}
					}
				}
				catch (Exception)
				{
					_conn.ConnString.Close();
					result = null;

				}
				finally
				{
					_conn.ConnString.Close();
				}
			}

            return result;
        }
    }
}
