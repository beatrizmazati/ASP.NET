<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProducts.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Database.UpdateProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Update Products</h1>
    <br /><hr />
    <!-- Step 2:  First, add a dropdown list. Add a heading above the dropdownlist and directions to the
        user to select a product.   -->
        <div>
      <p>Choose a Product first; then make the update.</p>
            <!-- Used code from DeleteProducts.aspx for the drop down list! -->
      <asp:DropDownList ID="ddlProdID" runat="server" AutoPostBack="False"></asp:DropDownList>
        <br /><br />
            <asp:Button ID="UpdateButton" runat="server" Text="Choose a Product" OnClick="UpdateButton_Click" /> <br /><br />
        <!-- In the page, manually delete the data rows: this time I have included a button instead 
            of a just using AutoPostBack - it is good to vary! -->
    </div>

    <div>
        <br /><br />
        <asp:Label ID="results1" runat="server" Text=""></asp:Label>
        <br />
        <hr />
     </div>

    <!-- Used code from InsertProducts.aspx plus a nice label to make the form look better! -->

    <div>
        <h1>Update a Product</h1>
        <br />
        <!-- We don`t need a placeholder in here because the user will see the information directly from the database -->
        <label>Product ID: </label>
        <asp:TextBox ID="ProdID" runat="server"></asp:TextBox> 
        <label> Product Name: </label>
        <asp:TextBox ID="ProdName" runat="server"></asp:TextBox>
        <br /><br />
        <label>Category ID: </label>
        <asp:TextBox ID="CatID" runat="server"></asp:TextBox>
        <label> Category Name: </label>
        <asp:TextBox ID="CatName" runat="server"></asp:TextBox>
        <br /><br />
        <label>Description: </label><br />
        <asp:TextBox ID="Desc" runat="server" Height="106px" 
            Width="340px" TextMode="MultiLine"></asp:TextBox>
        <br /><br />
        <label>Inventory: </label>
        <asp:TextBox ID="Invent" runat="server"></asp:TextBox>
        <label> Cost: </label>
        <asp:TextBox ID="Cost" runat="server"></asp:TextBox>
        <label> Price: </label>
        <asp:TextBox ID="Price" runat="server"></asp:TextBox>
        <label> Weight: </label>
        <asp:TextBox ID="Weight" runat="server"></asp:TextBox>
        <br /><br />
        <label>Product Image: </label>
        <asp:TextBox ID="ProdImage" runat="server"></asp:TextBox>
        <br /><br />
        <label>Product Thumbnail: </label>
        <asp:TextBox ID="ProdThumb" runat="server"></asp:TextBox>
        <br /><br />
        <label>Category Image: </label>
        <asp:TextBox ID="CatImg" runat="server"></asp:TextBox>
        <label> Category Thumbnail: </label>
        <asp:TextBox ID="CatThumb" runat="server"></asp:TextBox>
        <br /><br />
        <label>Availability: </label>
        <asp:TextBox ID="Availability" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="Button2" runat="server" Text="Update Product" OnClick="UpdateButton2_Click" />
        <hr /><br />
    </div>
    <div>
        <asp:Label ID="results2" runat="server" Text="" ></asp:Label>
    </div>
</asp:Content>
