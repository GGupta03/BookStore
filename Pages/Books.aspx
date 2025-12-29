<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Books.aspx.cs"
    Inherits="BookStore.Pages.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Available Books</h2>

    <a href="Cart.aspx">View Cart</a> |
    <a href="Wishlist.aspx">View Wishlist</a>

    <br /><br />

    <asp:GridView
        ID="gvBooks"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="gvBooks_RowCommand">

        <Columns>
            <asp:BoundField DataField="BookId" HeaderText="ID" />

            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="Price" HeaderText="Price" />

            <asp:ButtonField
                Text="Add to Cart"
                CommandName="AddToCart"
                ButtonType="Button" />

            <asp:ButtonField
                Text="Wishlist"
                CommandName="AddToWishlist"
                ButtonType="Button" />
        </Columns>
    </asp:GridView>

</asp:Content>
