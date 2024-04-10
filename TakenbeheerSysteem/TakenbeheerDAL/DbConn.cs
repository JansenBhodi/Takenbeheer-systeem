using MySqlConnector;
using System.Data.SqlClient;

namespace TakenbeheerDAL
{
    public class DbConn
    {
        public SqlConnection ConnString = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=TaskManagerSystem; Integrated Security=True");
    }
}
