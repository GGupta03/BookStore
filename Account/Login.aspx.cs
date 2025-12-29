using System;
using System.Configuration;
using System.Data.SqlClient;
using BookStore.Utils;

namespace BookStore.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager
                            .ConnectionStrings["DBCS"]
                            .ConnectionString;

                string hashedPassword =
                    PasswordHelper.HashPassword(txtPassword.Text);

                string query =
                    "SELECT UserId, FullName FROM Users " +
                    "WHERE Email = @Email AND Password = @Password";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            Session["UserId"] = dr["UserId"];
                            Session["UserName"] = dr["FullName"];

                            Response.Redirect("~/Pages/Books.aspx");
                        }
                        else
                        {
                            lblMsg.Text = "Invalid Email or Password";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }
    }
}
