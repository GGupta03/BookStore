using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Pages
{
    public partial class Wishlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
                LoadWishlist();
        }

        private void LoadWishlist()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DBCS"]
                        .ConnectionString;

            string query = @"
                SELECT b.Title, b.Author, b.Price
                FROM Wishlist w
                JOIN Books b ON w.BookId = b.BookId
                WHERE w.UserId = @UserId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                con.Open();
                gvWishlist.DataSource = cmd.ExecuteReader();
                gvWishlist.DataBind();
            }
        }
    }
}
