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

        public bool EditTeamById(TeamDTO inputData)
        {
            _conn.ConnString.Open();
            SqlCommand cmd = _conn.ConnString.CreateCommand();
            cmd.CommandText = "UPDATE Team " +
                              "SET Name = @name, Address = @address, PostalCode = @postalcode " +
                              "WHERE Id = @id";
            cmd.Parameters.AddWithValue("@name", inputData.Name);
            cmd.Parameters.AddWithValue("@address", inputData.Address);
            cmd.Parameters.AddWithValue("@postalcode", inputData.PostalCode);
            cmd.Parameters.AddWithValue("@id", inputData.Id);

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

        public bool DeleteTeamById(int teamId) 
        {
            _conn.ConnString.Open();
            SqlCommand cmd = _conn.ConnString.CreateCommand();
            cmd.CommandText = "DELETE FROM Team " +
                              "WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", teamId);

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

        public bool CreateTeam(TeamDTO inputData, int employeeId)
        {
            _conn.ConnString.Open();
            SqlCommand cmd = _conn.ConnString.CreateCommand();
            cmd.CommandText = "INSERT INTO Team " +
                              "(Name, Address, PostalCode) " +
                              "VALUES (@name, @address, @postalcode)";
            cmd.Parameters.AddWithValue("@name", inputData.Name);
            cmd.Parameters.AddWithValue("@address", inputData.Address);
            cmd.Parameters.AddWithValue("@postalcode", inputData.PostalCode);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                _conn.ConnString.Close();
                return false;
            }

            cmd.CommandText = "UPDATE Employee e " +
                              "SET e.TeamId = (SELECT t.Id FROM Team t WHERE t.Name = @name) " +
                              "WHERE e.Id = @id";
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

            return true;
        }
    }
}