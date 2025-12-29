using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Pages
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DBCS"]
                        .ConnectionString;

            string query = @"
                SELECT OrderId, OrderDate, TotalAmount
                FROM Orders
                WHERE UserId = @UserId
                ORDER BY OrderDate DESC";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                con.Open();

                gvOrders.DataSource = cmd.ExecuteReader();
                gvOrders.DataBind();
            }
        }
    }
}
