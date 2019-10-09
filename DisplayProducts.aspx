<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayProducts.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Database.DisplayProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Display Products</h1>

    <asp:Table ID="ProductsTable" runat="server" BorderColor="#000000" BorderStyle="Solid" BorderWidth="2px"
        GridLines="Both" CellPadding="10" HorizontalAlign="Center" Width="1124px">

       

        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ProductID</asp:TableHeaderCell>
            <asp:TableHeaderCell>ProductName</asp:TableHeaderCell>
            <asp:TableHeaderCell>CategoryID</asp:TableHeaderCell>
            <asp:TableHeaderCell>CategoryName</asp:TableHeaderCell>
            <asp:TableHeaderCell>Description</asp:TableHeaderCell>
            <asp:TableHeaderCell>Inventory</asp:TableHeaderCell>
            <asp:TableHeaderCell>Cost</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>Weight</asp:TableHeaderCell>
            <asp:TableHeaderCell>ProductImage</asp:TableHeaderCell>
            <asp:TableHeaderCell>ProductThumbnail</asp:TableHeaderCell>
            <asp:TableHeaderCell>CategoryImage</asp:TableHeaderCell>
            <asp:TableHeaderCell>CategoryThumbnail</asp:TableHeaderCell>
            <asp:TableHeaderCell>Availability</asp:TableHeaderCell>
        </asp:TableHeaderRow>

    </asp:Table>

    <asp:Label ID="Message" runat="server" Text=""></asp:Label>

</asp:Content>
