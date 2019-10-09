<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Week22.aspx.cs" Inherits="Beatriz_Mazati_Anderson.Pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="">
        <br />

        <!-- "The heading on the page should be "Visitor Signup Page". You  can use an <asp:Label control> 
              to create the heading and modify the properties with the Properties window" -->
        <asp:Label ID="lHeading" runat="server" Text="Visitor Signup Page" Font-Size="X-Large"></asp:Label>
        <br />

        <!-- Insert an image of a zoo animal in the page using the web server image control. -->
        <!-- The image was retrieved from Unsplash and it is free of copy rights.
             Link: https://unsplash.com/photos/Rsri2LZupVg -->
        <asp:Image ID="Image1" runat="server" AlternateText="Image text" 
                   ImageUrl="../images/zooanimal.jpg" Height="450" Width="570" /> 
        <br />

        <!-- Form Contents -->
        <!-- Collect the users name, complete address, phone number, email address, 
            username and password using textboxes(<asp:Textbox>). The state can be a dropdown list. 
            Remember, use ASP web controls!  -->

        <asp:Panel ID="Panel1" runat="server">
            <br />
            <asp:TextBox ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvName" runat="server" ErrorMessage="Please enter Your Name" 
                ControlToValidate="txtName"></asp:RequiredFieldValidator><br /><br />

            <asp:TextBox ID="txtAddress" runat="server" placeholder="Complete Address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvAddress" runat="server" ErrorMessage="Please enter your address" 
                ControlToValidate="txtAddress"></asp:RequiredFieldValidator><br /><br />

            <asp:TextBox ID="txtCity" runat="server" placeholder="City" Style="display: inline;" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvCity" runat="server" ErrorMessage="Please enter your City" 
                ControlToValidate="txtCity"></asp:RequiredFieldValidator>

            <asp:DropDownList ID="dlState" runat="server" Width="150px" Height="26px" Style="display: inline;">
                <asp:ListItem Text="Select a State" Value="0" />
                <asp:ListItem Text="Alabama" Value="AL" />
                <asp:ListItem Text="Alaska" Value="AK" />
                <asp:ListItem Text="Arizona" Value="AZ" />
                <asp:ListItem Text="Arkansas" Value="AR" />
                <asp:ListItem Text="California" Value="CA" />
                <asp:ListItem Text="Colorado" Value="CO" />
                <asp:ListItem Text="Connecticut" Value="CT" />
                <asp:ListItem Text="Delaware" Value="DE" />
                <asp:ListItem Text="Florida" Value="FL" />
                <asp:ListItem Text="Georgia" Value="GA" />
                <asp:ListItem Text="Hawaii" Value="HI" />
                <asp:ListItem Text="Idaho" Value="ID" />
                <asp:ListItem Text="Illinois" Value="IL" />
                <asp:ListItem Text="Indiana" Value="IN" />
                <asp:ListItem Text="Iowa" Value="IA" />
                <asp:ListItem Text="Kansas" Value="KS" />
                <asp:ListItem Text="Kentucky" Value="KY" />
                <asp:ListItem Text="Louisiana" Value="LA" />
                <asp:ListItem Text="Maine" Value="ME" />
                <asp:ListItem Text="Maryland" Value="MD" />
                <asp:ListItem Text="Massachusetts" Value="MA" />
                <asp:ListItem Text="Michigan" Value="MI" />
                <asp:ListItem Text="Minnesota" Value="MN" />
                <asp:ListItem Text="Mississippi" Value="MS" />
                <asp:ListItem Text="Missouri" Value="MO" />
                <asp:ListItem Text="Montana" Value="MT" />
                <asp:ListItem Text="Nebraska" Value="NE" />
                <asp:ListItem Text="Nevada" Value="NV" />
                <asp:ListItem Text="New Hampshire" Value="NH" />
                <asp:ListItem Text="New Jersey" Value="NJ" />
                <asp:ListItem Text="New Mexico" Value="NM" />
                <asp:ListItem Text="New York" Value="NY" />
                <asp:ListItem Text="North Carolina" Value="NC" />
                <asp:ListItem Text="North Dakota" Value="ND" />
                <asp:ListItem Text="Ohio" Value="OH" />
                <asp:ListItem Text="Oklahoma" Value="OK" />
                <asp:ListItem Text="Oregon" Value="OR" />
                <asp:ListItem Text="Pennsylvania" Value="PA" />
                <asp:ListItem Text="Rhode Island" Value="RI" />
                <asp:ListItem Text="South Carolina" Value="SC" />
                <asp:ListItem Text="South Dakota" Value="SD" />
                <asp:ListItem Text="Tennessee" Value="TN" />
                <asp:ListItem Text="Texas" Value="TX" />
                <asp:ListItem Text="UTAH" Value="UT" />
                <asp:ListItem Text="Vermont" Value="VT" />
                <asp:ListItem Text="Virginia" Value="VA" />
                <asp:ListItem Text="Washington" Value="WA" />
                <asp:ListItem Text="West Virginia" Value="WV" />
                <asp:ListItem Text="Wisconsin" Value="WI" />
                <asp:ListItem Text="Wyoming" Value="WY" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rvState" runat="server" ErrorMessage="Please enter your state" ControlToValidate="dlState"></asp:RequiredFieldValidator>

            <!-- The zip code cannot contain alpha characters.  -->
            <asp:TextBox ID="txtZipCode" runat="server" Style="display: inline;" Width="150px" TextMode="Number"
                          placeholder="Zip Code" pattern="[0-9]{5}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvZipCode" runat="server" ErrorMessage="Please enter your Zip Code" 
                ControlToValidate="txtZipCode"></asp:RequiredFieldValidator><br /><br />

            <asp:TextBox ID="txtPhoneNum" runat="server" placeholder="Phone Number" TextMode="Phone"
                pattern="^\d{3}-\d{3}-\d{4}$"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvPhoneNum" runat="server" ErrorMessage="Please enter your Phone Number" 
                ControlToValidate="txtPhoneNum"></asp:RequiredFieldValidator><br /><br />

            <!-- The email is a valid email format. -->
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvEmail" runat="server" ErrorMessage="Please enter your Email" 
                ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="RegularExpressionValidator" ControlToValidate="txtEmail" 
                ValidationExpression="^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$"></asp:RegularExpressionValidator><br /><br />

            <!-- The user name at least 6 characters. -->
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvUsername" runat="server" ErrorMessage="Please enter your username" 
                ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ErrorMessage="Your username must be between 6-8 characters and include a number" ControlToValidate="txtUsername" 
                ValidationExpression="^(?=.*\d).{6,8}$"></asp:RegularExpressionValidator><br /><br />


            <!-- The password is shown as a password with asterisks. It must be 8 letters or more and a mix of upper, 
                lower and special characters and numbers. -->
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvPassword" runat="server" ErrorMessage="Please enter your password" 
                ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="Your password must be must be 8 letters or more and a mix of upper, 
                lower and special characters and numbers" ControlToValidate="txtPassword" 
                ValidationExpression="(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$"></asp:RegularExpressionValidator><br /><br />


            <!--A textbox that identifies the date the user visited the zoo. This must be a date 
                before the current date. -->
            <asp:TextBox ID="txtDate" runat="server" placeholder="Date You Visited the Zoo" TextMode="Date" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvDate" runat="server" ErrorMessage="Please enter the date you last visited the zoo" 
                ControlToValidate="txtDate"></asp:RequiredFieldValidator>
            <!-- Thought about using range validator, but did not know how to set the maximum and minimum ranges -->

            <!-- CheckboxList control should identify the animal exhibits they visited in the zoo. 
                 They can pick from a list of 5 animal exhibits for the <asp:CheckboxList>. -->
            <p>Which animal exhibits did you visit in the zoo?</p>
            <asp:CheckBoxList ID="cblExhibits" runat="server" Width="300px">
                <asp:ListItem Text="Lion" Value="L" />
                <asp:ListItem Text="Seal" Value="S" />
                <asp:ListItem Text="Parrot" Value="P" />
                <asp:ListItem Text="Penguins" Value="PE" />
                <asp:ListItem Text="Elefants" Value="E" />
            </asp:CheckBoxList><br /><br />
            <!-- The validation we have been using did not work for this example -->
           

            <!-- DropdownList control <asp:DropdownList> should provide how they came to the zoo 
                (ie. Bus, car, bike, walk, taxi, Uber).  -->
            <p>How did you get to the zoo?</p>
            <asp:DropDownList ID="ddTransportation" runat="server" style="display:inline;" Width="300px">
                <asp:ListItem Text="Select a Form of Transportation" Value="0" />
                <asp:ListItem Text="Car" Value="C" />
                <asp:ListItem Text="Bus" Value="B" />
                <asp:ListItem Text="By Foot" Value="W" />
                <asp:ListItem Text="Taxi" Value="T" />
                <asp:ListItem Text="Uber" Value="U" />
                <asp:ListItem Text="Bicycle" Value="BI" />
                <asp:ListItem Text="Motorcycle" Value="M" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rvTransportation" runat="server" ErrorMessage="Please enter the 
                type of transportation you used to get to the zoo" ControlToValidate="ddTransportation"></asp:RequiredFieldValidator><br /><br />

            <!-- Radiobuttons control  <asp:RadioButtons> should be used to identify user 
                contact preference: email, phone, regular email.Email should be selected by default. -->
            <p>What is your contact preference?</p>
            <asp:RadioButtonList ID="rbContact" runat="server" Width="300px">
                <asp:ListItem Text="Email" Value="Email" Selected="True" />
                <asp:ListItem Text="Phone" Value="Phone" />
                <asp:ListItem Text="Work Email" Value="Work Email" />
                <asp:ListItem Text="Text Message" Value="Text Message" />
                <asp:ListItem Text="Mail" Value="Mail" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rvContact" runat="server" ErrorMessage="Please enter your contact preference"
                ControlToValidate="rbContact"></asp:RequiredFieldValidator><br /><br />


            <!-- One textbox should allow the user to enter feedback comments across multiple lines 
                 of text about their visit!  Use the Textbox control (<asp:Textbox>) with the TextMode set. -->
            <asp:TextBox runat="server" ID="txtFeedback" TextMode="MultiLine"
                placeholder="Enter feedback comments about your visit in the zoo" Rows="8" Width="350px" /><br />

            <!-- Include a button to submit the form. Use an <asp:button> control. -->
            <asp:Button ID="Button" runat="server" Text="Submit" CssClass="btn btn-primary" /><br />

            <asp:Panel ID="Output" runat="server">
                <asp:Label ID="Results" runat="server"/>
            </asp:Panel>

        </asp:Panel>

         <!-- Use a validation summary control to show all the errors in one location on the page. -->
        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fix the errors displayed"
            DisplayMode="List" />

    </div>
    
</asp:Content>
