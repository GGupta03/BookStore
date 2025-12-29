<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Cart.aspx.cs"
    Inherits="BookStore.Pages.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Cart</h2>

    <asp:GridView 
        ID="gvCart" 
        runat="server" 
        AutoGenerateColumns="False"
        BorderWidth="1"
        CellPadding="5">

        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Book Title" />
            <asp:BoundField DataField="Price" HeaderText="Price (₹)" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>

    </asp:GridView>

    <br />

    <asp:Button 
        ID="btnPlaceOrder" 
        runat="server" 
        Text="Place Order" 
        OnClick="PlaceOrder_Click" />

    <br /><br />

    <asp:Label 
        ID="lblMsg" 
        runat="server" />

</asp:Content>
