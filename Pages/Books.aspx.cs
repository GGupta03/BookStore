using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Pages
{
    public partial class Books : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadBooks();
            }
        }
        protected void gvBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DBCS"]
                        .ConnectionString;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBooks.Rows[index];
            int bookId = Convert.ToInt32(row.Cells[0].Text);

            if (e.CommandName == "AddToCart")
            {
                string query =
                    "INSERT INTO Cart (UserId, BookId, Quantity) VALUES (@UserId, @BookId, 1)";

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            if (e.CommandName == "AddToWishlist")
            {
                string query =
                    "INSERT INTO Wishlist (UserId, BookId) VALUES (@UserId, @BookId)";

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void LoadBooks()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DBCS"]
                        .ConnectionString;

            string query = "SELECT BookId, Title, Author, Price FROM Books";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                gvBooks.DataSource = cmd.ExecuteReader();
                gvBooks.DataBind();
            }
        }


    }
}