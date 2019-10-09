<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertProducts.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Database.InsertProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Create the pages to display your data and store them in the Database folder: InsertProducts.aspx and uses the Master Page -->
    <h1><strong style="font-size: xx-large">Insert a Product</strong></h1>
    <hr />
    <!-- Create a form with all the form fields that will be used to insert the data in the database. -->
    <p>Start with product ID that is larger than 3131</p>
    <div>
        <asp:TextBox ID="ProdID" runat="server" placeholder="ProductID"></asp:TextBox> 
        <asp:TextBox ID="ProdName" runat="server" placeholder="ProductName"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="CatID" runat="server" placeholder="CategoryID"></asp:TextBox>
        <asp:TextBox ID="CatName" runat="server" placeholder="CategoryName"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="Desc" runat="server" placeholder="Description" Height="106px" 
            Width="340px" TextMode="MultiLine"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="Invent" runat="server" placeholder="Inventory"></asp:TextBox>
        <asp:TextBox ID="Cost" runat="server" placeholder="Cost"></asp:TextBox>
        <asp:TextBox ID="Price" runat="server" placeholder="Price"></asp:TextBox>
        <asp:TextBox ID="Weight" runat="server" placeholder="Weight"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="ProdImage" runat="server" placeholder="ProductImage"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="ProdThumb" runat="server" placeholder="Product Thumbnail"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="CatImg" runat="server" placeholder="CategoryImage"></asp:TextBox>
        <asp:TextBox ID="CatThumb" runat="server" placeholder="CategoryThumbnail"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="Availability" runat="server" placeholder="Availability"></asp:TextBox>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Insert Product" />
        <hr /><br />
    </div>
    <div>
        <!-- allows the error message or success message to be displayed below the form. -->
        <asp:Label ID="results" runat="server" Text="" ></asp:Label>
    </div>


</asp:Content>