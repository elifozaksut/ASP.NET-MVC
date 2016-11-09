using System.Data.SqlClient;

namespace DAL.Utility
{
    public class Helper
    {
        public SqlConnection GetConnection()
        {
            SqlConnection cnn = new SqlConnection("Server=.; Database= BlogDb; Trusted_Connection=True;");
            return cnn;
        }
    }
}