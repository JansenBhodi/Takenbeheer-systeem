using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Team;

namespace TakenbeheerDAL
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DbConn _conn = new DbConn();

        public TeamRepository()
        {

        }

        public TeamDTO? GetTeamByEmployeeId(int employeeId)
        {
            _conn.ConnString.Open();
            TeamDTO result = null;
            SqlCommand cmd = _conn.ConnString.CreateCommand();
            cmd.CommandText = "SELECT t.Id, t.Name, t.Address, t.PostalCode FROM Team t " +
                              "INNER JOIN Employee e ON t.Id = e.TeamID " +
                              "WHERE e.Id = @employeeid";
            cmd.Parameters.AddWithValue("@employeeid", employeeId);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new TeamDTO(
                            reader.GetInt32("Id"),
                            reader.GetString("Name"),
                            reader.GetString("Address"),
                            reader.GetString("PostalCode"));
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
}
