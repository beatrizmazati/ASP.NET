<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteProducts.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Database.DeleteProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <!--Create the pages to display your data and store them in the Database folder: DeleteProducts.aspx
        Make sure to use the master page! -->

    <h1>Delete Product</h1>
    <br /><hr />

    <div>
        <!-- Although you can use a submit button use AutoPostback. Set the property to true for the dropdownlist control.  -->
        <!-- I added a DropDownList control to allow the user to select the record they want to delete. -->
      <asp:DropDownList ID="ddlProdID" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br /><br />
        <!-- In the page, manually delete the data rows: As I have already set AutoPostBack as the assignment required,
            there is no need for a button -->
    </div>

    <div>
        <br /><br />
        <asp:Label ID="results" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <span style="color: #666666"><em><span style="font-size: large">Return to the List to ensure that the item has been deleted:</span></em></span><span style="font-size: large"><br />
        </span>
        <a href="DisplayProducts.aspx"><span style="font-size: large">DisplayProducts.aspx</span></a></div>
</asp:Content>
