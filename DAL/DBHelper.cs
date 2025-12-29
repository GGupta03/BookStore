using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.DAL
{
    public class DBHelper
    {
        private static readonly string cs =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public static DataTable ExecuteSelect(string query)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static int ExecuteDML(string query)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
