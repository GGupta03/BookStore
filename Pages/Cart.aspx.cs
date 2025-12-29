using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Pages
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DBCS"]
                        .ConnectionString;

            string query = @"
                SELECT b.Title, b.Price, c.Quantity
                FROM Cart c
                INNER JOIN Books b ON c.BookId = b.BookId
                WHERE c.UserId = @UserId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                con.Open();

                gvCart.DataSource = cmd.ExecuteReader();
                gvCart.DataBind();
            }
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DBCS"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    string orderQuery = @"
                INSERT INTO Orders (UserId, OrderDate, TotalAmount)
                OUTPUT INSERTED.OrderId
                VALUES (@UserId, GETDATE(), 0)";

                    SqlCommand orderCmd = new SqlCommand(orderQuery, con, tx);
                    orderCmd.Parameters.AddWithValue("@UserId", Session["UserId"]);

                    int orderId = (int)orderCmd.ExecuteScalar();

                    string itemsQuery = @"
                INSERT INTO OrderItems (OrderId, BookId, Quantity, Price)
                SELECT @OrderId, c.BookId, c.Quantity, b.Price
                FROM Cart c
                JOIN Books b ON c.BookId = b.BookId
                WHERE c.UserId = @UserId";

                    SqlCommand itemsCmd = new SqlCommand(itemsQuery, con, tx);
                    itemsCmd.Parameters.AddWithValue("@OrderId", orderId);
                    itemsCmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                    itemsCmd.ExecuteNonQuery();

                    string totalQuery = @"
                UPDATE Orders
                SET TotalAmount =
                (
                    SELECT SUM(b.Price * c.Quantity)
                    FROM Cart c
                    JOIN Books b ON c.BookId = b.BookId
                    WHERE c.UserId = @UserId
                )
                WHERE OrderId = @OrderId";

                    SqlCommand totalCmd = new SqlCommand(totalQuery, con, tx);
                    totalCmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                    totalCmd.Parameters.AddWithValue("@OrderId", orderId);
                    totalCmd.ExecuteNonQuery();

                    string clearCartQuery =
                        "DELETE FROM Cart WHERE UserId = @UserId";

                    SqlCommand clearCmd = new SqlCommand(clearCartQuery, con, tx);
                    clearCmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                    clearCmd.ExecuteNonQuery();

                    tx.Commit();

                    Response.Redirect("~/Pages/Orders.aspx");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    lblMsg.Text = "Order failed: " + ex.Message;
                }
            }
        }

    }
}
