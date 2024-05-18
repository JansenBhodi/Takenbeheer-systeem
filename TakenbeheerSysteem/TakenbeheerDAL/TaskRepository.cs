using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TakenbeheerCore.Task;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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

        //test functionality, won't be used in real app
        public List<TaskDTO> ReturnAllTasks()
        {
            _conn.ConnString.Open();

            SqlCommand command = _conn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Worktask";

            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            List<TaskDTO> result = new List<TaskDTO>();
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

            _conn.ConnString.Close();
            return result;
        }

        public List<TaskDTO> GetTasksByEmployee(int empId)
        {
            List<TaskDTO> result = new List<TaskDTO>();
            _conn.ConnString.Open();

            try
            {

            }
            catch (Exception)
            {
				_conn.ConnString.Close();
				return result;
            }
            finally
            {
                _conn.ConnString.Close();
            }

            return result;
        }
    }
}
