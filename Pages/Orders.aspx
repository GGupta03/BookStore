<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Orders.aspx.cs"
    Inherits="BookStore.Pages.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Order History</h2>

    <asp:GridView 
        ID="gvOrders" 
        runat="server" 
        AutoGenerateColumns="False"
        BorderWidth="1"
        CellPadding="5">

        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order ID" />
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" 
                            DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount (₹)" />
        </Columns>

    </asp:GridView>

</asp:Content>
