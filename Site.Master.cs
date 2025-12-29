using System;
using System.Web.UI;

namespace BookStore
{
    public partial class SiteMaster : MasterPage
    {
        private readonly string[] pages =
        {
            "~/Pages/Books.aspx",
            "~/Pages/Cart.aspx",
            "~/Pages/Wishlist.aspx",
            "~/Pages/Orders.aspx"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogout.Visible = Session["UserId"] != null;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Account/Login.aspx");
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            Navigate(1);
        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            Navigate(-1);
        }

        private void Navigate(int step)
        {
            string currentPage = Request.AppRelativeCurrentExecutionFilePath;

            int index = Array.IndexOf(pages, currentPage);
            int targetIndex = index + step;

            if (targetIndex >= 0 && targetIndex < pages.Length)
            {
                Response.Redirect(pages[targetIndex]);
            }
        }
    }
}
