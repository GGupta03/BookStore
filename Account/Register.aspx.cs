using BookStore.Utils;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BookStore.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager
                            .ConnectionStrings["DBCS"]
                            .ConnectionString;

                string hashedPassword =
                    PasswordHelper.HashPassword(txtPassword.Text);

                string query =
                    "INSERT INTO Users (FullName, Email, Password) " +
                    "VALUES (@FullName, @Email, @Password)";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMsg.Text = "Registration Successful";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
