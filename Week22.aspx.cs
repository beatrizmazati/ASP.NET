using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Beatriz_Mazati_Anderson.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Reference: https://www.youtube.com/watch?v=xhtiKYi2LS8


            if (Page.IsPostBack && Page.IsValid)
            {
                // Did not understand  the video`s for loop - will need to review it for next week.
                Output.Visible = true;
                string results =
                    "Name: " + txtName.Text + "<br />" +
                    "Address: " + txtAddress.Text + "<br />" +
                    "City: " + txtCity.Text + "<br />" +
                    "State: " + dlState.SelectedItem.Value.ToString() + "<br />" +
                    "Zip Code: " + txtZipCode.Text + "<br />" +
                    "Email: " + txtEmail.Text + "<br />" +
                    "Phone: " + txtPhoneNum.Text + "<br />" +
                    "Username: " + txtUsername.Text + "<br />" +
                    "Password: " + txtPassword.Text + "<br />" +
                    "Date zoo was visited: " + txtDate.Text + "<br />" +
                    "How do you get to the zoo? " + ddTransportation.SelectedItem.Text.ToString() + "<br />" +
                    "Contact Preference: " + rbContact.SelectedItem.Value.ToString() + "<br />" +
                    "Feedback: " + txtFeedback.Text + "<br />";

                Results.Text = results;

            }

        }
    }
}

