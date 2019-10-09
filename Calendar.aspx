<%@ Page Theme="Theme1" Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Pages.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Calendar</h1>
            <!-- Insert a calendar in the Calendar.aspx page. Configure the calendar to use the MyCalendarSkin skin. -->
            <asp:Calendar ID="MyCalendar" runat="server" SkinID="MyCalendarSkin" SelectionMode="Day" OnSelectionChanged="Selection_Change" 
              
        OnDayRender="MyCalendar_DayRender" DayNameFormat="Full"> 
                <DayStyle Height="70px" Width= "100px" />
  
            </asp:Calendar>

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblhours" runat="server" Text=""></asp:Label>
            
        </div>
    </form>
</body>
</html>
