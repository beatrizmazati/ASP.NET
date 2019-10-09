using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Beatriz_Mazati_Anderson.Pages
{
    public partial class Calendar : System.Web.UI.Page
    {
        /* When the user clicks a date they plan to visit the restaurant, provide them with date they 
           selected and the restaurant hours.
           Mon, Tues, Wed, Thurs 11-10pm
           Friday 11-11:30 pm
           Sat, Sun 12-8pm */

        string[] openHours = new string[] { "Open from 12 PM to 8 PM","Open from 11 AM to 10 PM",
            "Open from 11 AM to 10 PM", "Open from 11 AM to 10 PM", "Open from 11 AM to 10 PM",
            "Open from 11 AM to 11:30 PM", "open from 12 PM to 8 PM" };

        protected void Selection_Change(object sender, EventArgs e)
        {
            try {

                Label1.Text = MyCalendar.SelectedDate.ToShortDateString();
                lblhours.Text = openHours[(int)MyCalendar.SelectedDate.DayOfWeek];

                // Closed for holidays
                // helpful source: https://www.codeproject.com/Tips/1168428/US-Federal-Holidays-Csharp 

                DateTime date = MyCalendar.SelectedDate;
                int nthWeekDay = (int)(Math.Ceiling((double)date.Day / 7.0d));
                DayOfWeek dayName = date.DayOfWeek;
                bool isThursday = dayName == DayOfWeek.Thursday;
                bool isFriday = dayName == DayOfWeek.Friday;
                bool isMonday = dayName == DayOfWeek.Monday;
                bool isWeekend = dayName == DayOfWeek.Saturday || dayName == DayOfWeek.Sunday;

                // New Years Day (Jan 1, or preceding Friday/following Monday if weekend)
                if ((date.Month == 12 && date.Day == 31) ||
                    (date.Month == 1 && date.Day == 1 && !isWeekend) ||
                    (date.Month == 1 && date.Day == 2 && isMonday))
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // MLK day (3rd monday in January)
                if (date.Month == 1 && isMonday && nthWeekDay == 3)
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // President’s Day (3rd Monday in February)
                if (date.Month == 2 && isMonday && nthWeekDay == 3)
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // Memorial Day (Last Monday in May)
                if (date.Month == 5 && isMonday && date.AddDays(7).Month == 6)
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // Independence Day (July 4, or preceding Friday/following Monday if weekend)
                if ((date.Month == 7 && date.Day == 3 && isFriday) ||
                    (date.Month == 7 && date.Day == 4 && !isWeekend) ||
                    (date.Month == 7 && date.Day == 5 && isMonday))
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // Labor Day (first Monday in September)
                if (date.Month == 9 && isMonday && nthWeekDay == 1)
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // Thanksgiving Day (December 25, or preceding Friday/following Monday if weekend)
                if (date.Month == 11 && isThursday && nthWeekDay == 4)
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // Christmas Day (December 25, or preceding Friday/following Monday if it is a weekend)
                if ((date.Month == 12 && date.Day == 24 && isFriday) ||
                    (date.Month == 12 && date.Day == 25 && !isWeekend) ||
                    (date.Month == 12 && date.Day == 26 && isMonday))
                    lblhours.Text = "The selected day is a holiday, we are closed";

                // If they visit on the 2rd, 16th, or 29th, tell them the restaurant is closed that day. 
                // As the assignment did not specify which month, I applied these rules for every 2nd, 16th and 29th of each month.
                // 2nd is closed
                if (date.Day == 2)
                    lblhours.Text = "We will be closed that day! Sorry for the inconvenience!";

                // 16th is closed
                if (date.Day == 16)
                    lblhours.Text = "We will be closed that day! Sorry for the inconvenience!";

                // 29th is closed
                if (date.Day == 29)
                    lblhours.Text = "We will be closed that day! Sorry for the inconvenience!";

            }
            catch (Exception err)
            {
                lblhours.Text = "<b>Message:</b> " + err.Message;
                lblhours.Text += "<br /><br />";
                lblhours.Text += "<b>Source:</b> " + err.Source;
                lblhours.Text += "<br /><br />";
                lblhours.Text += "<b>Stack Trace:</b> " + err.StackTrace;
            }
        } 

        
        protected void MyCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                // GLOBAL DESIGN SETTINGS
                MyCalendar.ShowGridLines = true;
                MyCalendar.SelectedDayStyle.BackColor = System.Drawing.Color.MidnightBlue;
                MyCalendar.SelectedDayStyle.ForeColor = System.Drawing.Color.White;

                /* Insert content for at least 12 major holidays. (You can
                pick them or search for major holidays) You can include a foot picture or other fun picture for the holiday.*/

                if (e.Day.Date.Day == 18 && e.Day.Date.Month == 2)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />President`s Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Holiday";

                    // Image source: https://unsplash.com/photos/iQOzInmMxEY

                    myImage.ImageUrl = "../Images/holiday1.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 1 && e.Day.Date.Month == 1)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />New Year’s Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Holiday";

                    // Image source: https://unsplash.com/photos/HxeBUWUiA1A

                    myImage.ImageUrl = "../Images/newyear.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 21 && e.Day.Date.Month == 1)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Martin Luther King Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Holiday";

                    // Image source: https://unsplash.com/photos/bxXmh31O89I 

                    myImage.ImageUrl = "../Images/martin.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 27 && e.Day.Date.Month == 5)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Memorial Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Holiday";

                    // Image source: https://unsplash.com/photos/nCkDiXGGBp0

                    myImage.ImageUrl = "../Images/memorial.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 4 && e.Day.Date.Month == 7)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Independence Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Holiday";

                    // Image source: https://unsplash.com/photos/sjS4pYowbKw

                    myImage.ImageUrl = "../Images/independence.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }


                if (e.Day.Date.Day == 2 && e.Day.Date.Month == 9)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Labor Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Labor Day";

                    // Image source: https://unsplash.com/photos/lQL-CpBxuD8

                    myImage.ImageUrl = "../Images/labor.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 14 && e.Day.Date.Month == 10)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Columbus Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Columbus Day";

                    // Image source: https://unsplash.com/photos/Esq0ovRY-Zs

                    myImage.ImageUrl = "../Images/colombus.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 11 && e.Day.Date.Month == 11)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Veterans Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Veterans Day";

                    // Image source: https://unsplash.com/photos/4GN3kBR7IMY

                    myImage.ImageUrl = "../Images/veterans.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 28 && e.Day.Date.Month == 11)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Thanksgiving Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Thanksgiving Day";

                    // Image source: https://unsplash.com/photos/p2OQW69vXP4

                    myImage.ImageUrl = "../Images/thanks.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }


                if (e.Day.Date.Day == 25 && e.Day.Date.Month == 12)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Christmas Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Christmas Day";

                    // Image source: https://unsplash.com/photos/ty_JgMRfUKQ

                    myImage.ImageUrl = "../Images/christmas.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }


                if (e.Day.Date.Day == 14 && e.Day.Date.Month == 2)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Valentine's Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Valentine's Day";

                    // Image source: https://unsplash.com/photos/5g8exOobDjg

                    myImage.ImageUrl = "../Images/valentine.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                if (e.Day.Date.Day == 17 && e.Day.Date.Month == 3)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />St. Patrick's Day";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "St. Patrick's Day";

                    // Image source: https://unsplash.com/photos/j8bW-jBWF8g

                    myImage.ImageUrl = "../Images/patrick.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }


                if (e.Day.Date.Day == 21 && e.Day.Date.Month == 4)
                {

                    e.Cell.BackColor = System.Drawing.Color.LightPink;
                    Label lbl = new Label();
                    lbl.Text = "<br />Easter";
                    e.Cell.Controls.Add(lbl);
                    Image myImage = new Image();
                    myImage.AlternateText = "Easter";

                    // Image source: https://unsplash.com/photos/-KKLWDAgj2Q

                    myImage.ImageUrl = "../Images/easter.jpg";
                    myImage.Height = 38;
                    myImage.Width = 48;
                    e.Cell.Controls.Add(myImage);

                }

                // Display text, links, images, literal text with HTML inside at least five individual days in the current month. 

                // 1
                if (e.Day.Date.Day == 25 && e.Day.Date.Month == 2)
                {
                    HyperLink myLink = new HyperLink();
                    myLink.NavigateUrl = "https://unsplash.com/photos/NbXjZomyNEM";
                    myLink.Text = "<br/>Chicken special";
                    myLink.Target = "_blank";
                    e.Cell.Controls.Add(myLink);

                }

                // 2
                if (e.Day.Date.Day == 10 && e.Day.Date.Month == 2)
                {

                    // Image source: https://unsplash.com/photos/IGfIGP5ONV0

                    Image myImage = new Image();
                    myImage.AlternateText = "<br/> Salad";
                    myImage.ImageUrl = "../Images/salad.jpg";
                    myImage.Height = 40;
                    myImage.Width = 40;
                    e.Cell.Controls.Add(myImage);
                    Label lbl = new Label();
                    lbl.Text = "<br />Salad Day";
                    e.Cell.Controls.Add(lbl);
                }

                // 3
                if (e.Day.Date.Day == 15 && e.Day.Date.Month == 2)
                {
                    e.Cell.Controls.Add(new LiteralControl("<br />Free dessert Day!"));
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                }

                // 4
                if (e.Day.Date.Day == 3 && e.Day.Date.Month == 2)
                {
                    e.Cell.ForeColor = System.Drawing.Color.Purple;
                    Label lbl = new Label();
                    lbl.Text = "<br/>Taco Sunday";
                    e.Cell.Controls.Add(lbl);
                }

                // 5
                if (e.Day.Date.Day == 23 && e.Day.Date.Month == 2)
                {
                    e.Cell.ForeColor = System.Drawing.Color.Purple;
                    Label lbl = new Label();
                    lbl.Text = "<br/>Bring your dog Day";
                    e.Cell.Controls.Add(lbl);
                }

                // The client also wants to indicate that there is a special on appetizers on the 12th this month, with 40% off. 

                if (e.Day.Date.Day == 12 && e.Day.Date.Month == 2)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightSkyBlue;
                    Label lbl = new Label();
                    lbl.Text = "<br/> Appetizers are 40% off!";
                    e.Cell.Controls.Add(lbl);

                }

                // They want to indicate the days that are closed by turning the background color to a different color
                // for the 2nd
                if (e.Day.Date.Day == 2)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightSteelBlue;
                }

                // for the 16th
                if (e.Day.Date.Day == 16)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightSteelBlue;
                }

                // for the 29th 
                if (e.Day.Date.Day == 29)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightSteelBlue;
                }


                /*The client wants to show images indicating what food discounts are available every Wednesday.
                  (You can pick the dish/drink that's on sale on each week). You pick the images to go with the text.*/

                if (e.Day.Date.Day >= 1 && e.Day.Date.Day <= 7 && e.Day.Date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    // Image source: https://unsplash.com/photos/35-cRGN99cU

                    Image myImage = new Image();
                    myImage.AlternateText = "<br/>drink";
                    myImage.ImageUrl = "../Images/drink.jpg";
                    myImage.Height = 45;
                    myImage.Width = 45;
                    e.Cell.Controls.Add(myImage);
                    Label lbl = new Label();
                    lbl.Text = "<br />Drink Discount";
                    e.Cell.Controls.Add(lbl);
                }

                if (e.Day.Date.Day >= 8 && e.Day.Date.Day <= 14 && e.Day.Date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    // Image source: https://unsplash.com/photos/VLLCoZJn8tE

                    Image myImage = new Image();
                    myImage.AlternateText = "<br/>fish";
                    myImage.ImageUrl = "../Images/fish.jpg";
                    myImage.Height = 45;
                    myImage.Width = 45;
                    e.Cell.Controls.Add(myImage);
                    Label lbl = new Label();
                    lbl.Text = "<br />Fish Discount";
                    e.Cell.Controls.Add(lbl);
                }

                if (e.Day.Date.Day >= 15 && e.Day.Date.Day <= 21 && e.Day.Date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    // image source: https://unsplash.com/photos/12eHC6FxPyg

                    Image myImage = new Image();
                    myImage.AlternateText = "<br/> Pasta";
                    myImage.ImageUrl = "../Images/pasta.jpg";
                    myImage.Height = 45;
                    myImage.Width = 45;
                    e.Cell.Controls.Add(myImage);
                    Label lbl = new Label();
                    lbl.Text = "<br />Pasta Discount";
                    e.Cell.Controls.Add(lbl);
                }

                if (e.Day.Date.Day > 21 && e.Day.Date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    // image source: https://unsplash.com/photos/s-Z-h0fEiBM

                    Image myImage = new Image();
                    myImage.AlternateText = "<br/> Steak";
                    myImage.ImageUrl = "../Images/steak.jpg";
                    myImage.Height = 45;
                    myImage.Width = 45;
                    e.Cell.Controls.Add(myImage);
                    Label lbl = new Label();
                    lbl.Text = "<br />Steak";
                    e.Cell.Controls.Add(lbl);
                }


            } catch (Exception err)
   
            {
                lblhours.Text = "<b>Message:</b> " + err.Message;
                lblhours.Text += "<br /><br />";
                lblhours.Text += "<b>Source:</b> " + err.Source;
                lblhours.Text += "<br /><br />";
                lblhours.Text += "<b>Stack Trace:</b> " + err.StackTrace;
            }

         }


    }
}