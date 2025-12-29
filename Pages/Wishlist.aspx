<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Wishlist.aspx.cs"
    Inherits="BookStore.Pages.Wishlist" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Wishlist</h2>

    <asp:GridView
        ID="gvWishlist"
        runat="server"
        AutoGenerateColumns="False">

        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Book Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>

    </asp:GridView>

</asp:Content>
