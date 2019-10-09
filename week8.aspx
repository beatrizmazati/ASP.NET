<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="week8.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Database.week8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Chart Control</h1>
    <hr />
    <p>
        <!--Create my first SqlDataSourceControl to link to my database and set SQL commands. Manually set some of the commands.
            Create a columns chart, showing the 3 most expensive products that is sold on the site. -->
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MazatiAnderson %>" 
            SelectCommand="SELECT TOP 3 [ProductName], [Price] FROM [Products] ORDER BY [Price] DESC">

     </asp:SqlDataSource>   
    </p>
    <p>
        &nbsp;</p>
    <p>
        <!-- Drag and Drop chart - name it properly and also customize its look.-->
        <!-- add tittle and customizes axisY and axisX -->

        <asp:Chart ID="TopExpensive" runat="server" DataSourceID="SqlDataSource1" Height="452px" Width="430px" 
            AlternateText="Top 3: Most Expensive Products" BackColor="MistyRose" BackGradientStyle="TopBottom" 
            BackHatchStyle="OutlinedDiamond" BackImageAlignment="Center" BackSecondaryColor="WhiteSmoke" 
            BorderlineColor="LightCoral" BorderlineDashStyle="Solid" BorderlineWidth="2" Palette="Pastel">
           
            <Titles>
              <asp:Title Font="Times New Roman, 18pt, style=Bold, Italic" Name="Title1" Text="Top 3: Most Expensive Products"></asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="SeriesEx" XValueMember="ProductName" YValueMembers="Price">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartAreaEx">
                
                     <AxisY Title="Price" TitleFont="Times New Roman, 18pt, style=Bold, Italic" ></AxisY>
                     <AxisX Title="Product" IsLabelAutoFit="True" TitleFont="Times New Roman, 18pt, style=Bold, Italic"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <BorderSkin BackColor="Gainsboro" BackHatchStyle="DashedVertical" BorderColor="DarkGray" />
        </asp:Chart>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <!-- Create a chart that shows the 3 products that make the most profit. (Difference in cost and price). 
             Show the names of the product and the profit for that product.  

             Repeat the previous procedure creating the SqlDataSource and manually adding commands. This cool command subtracts cost from price
             and creates a column with the result - the column is displayed as the profit per product -->

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MazatiAnderson %>" 
            SelectCommand="SELECT TOP 3 ProductName, (Price - Cost) FROM [Products] ORDER BY (Price - Cost) DESC"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <!-- Creates chart and follows the past procedure as well, by customizing it, naming it etc etc. -->
        <asp:Chart ID="TopProfit" runat="server" DataSourceID="SqlDataSource2" Height="452px" Width="430px" AlternateText="Top 3: Most Profitable Products"
            BackColor="PapayaWhip" BackGradientStyle="TopBottom" BackHatchStyle="SolidDiamond" BorderlineColor="LightGray" BorderlineDashStyle="DashDot" 
            BorderlineWidth="3" Palette="Chocolate">
            <Titles>
              <asp:Title Font="Times New Roman, 18pt, style=Bold, Italic" Name="Title1" Text="Top 3: Most Profitable"></asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="SeriesPro" XValueMember="ProductName" YValueMembers="Column1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartAreaPro">
                    <AxisY Title="Profit per Product (US Dollar)" TitleFont="Times New Roman, 18pt, style=Bold, Italic" ></AxisY>
                    <AxisX Title="Product Name" IsLabelAutoFit="True" TitleFont="Times New Roman, 18pt, style=Bold, Italic"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <BorderSkin BackGradientStyle="TopBottom" BackHatchStyle="Plaid" BackImageTransparentColor="Snow" BorderColor="LightCoral" 
                BorderDashStyle="Solid" PageColor="PeachPuff" />
        </asp:Chart>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <!-- Links to my data source and filters the products by weight. It displays my products in descending order, just like the previous
             commands, so I can display the heaviest products. This could be useful when considering shipping costs. -->

        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MazatiAnderson %>" 
            SelectCommand="SELECT TOP 5 [ProductName], [Weight] FROM [Products] ORDER BY [Weight] DESC"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
       <!-- Creates and customize chart just like the following two graphs - but this graph is the one of my choice! --> 
        <asp:Chart ID="TopHeavy" runat="server" DataSourceID="SqlDataSource3" Height="452px" Width="430px" BackColor="Thistle" BackGradientStyle="DiagonalLeft" 
            BackHatchStyle="HorizontalBrick" BackImageTransparentColor="White" BackSecondaryColor="LightCoral" BorderlineColor="DarkRed" BorderlineWidth="2" 
            Palette="Pastel">
            <Titles>
              <asp:Title Font="Times New Roman, 18pt, style=Bold, Italic" Name="Title1" Text="Top 5: Heaviest Products"></asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="SeriesHe" XValueMember="ProductName" YValueMembers="Weight">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartAreaHe">
                    <AxisY Title="Heaviest Products (lb)" TitleFont="Times New Roman, 18pt, style=Bold, Italic" ></AxisY>
                    <AxisX Title="Product Name" IsLabelAutoFit="True" TitleFont="Times New Roman, 18pt, style=Bold, Italic"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <BorderSkin BackColor="LightCoral" BackGradientStyle="TopBottom" BackHatchStyle="SmallGrid" BorderColor="LightGray" />
        </asp:Chart>
        
    </p>
    
</asp:Content>
