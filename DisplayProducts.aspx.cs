using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data; // Access CommandType
using System.Data.SqlClient; // SqlClient Class
using System.Web.Configuration; // to get CS

namespace Beatriz_Mazati_Anderson.Database
{
    public partial class DisplayProducts : System.Web.UI.Page
    {
        // Use all SqlConnection, SqlCommand and SqlDataReader objects
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connects to my connection String
            string CS = WebConfigurationManager.ConnectionStrings["MazatiAnderson"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            // Retrived information from my Stored Procedure created last week
            SqlCommand oCM = new SqlCommand("ShowAllProductsSorted", con);
            oCM.CommandType = CommandType.StoredProcedure;
            // Declare number os cells needed
            SqlDataReader reader;
            TableCell tempCell1, tempCell2, tempCell3, tempCell4, tempCell5, tempCell6, tempCell7, tempCell8,
                tempCell9, tempCell10, tempCell11, tempCell12, tempCell13, tempCell14;
            // Path where my images are located
            string mypath = "../images/small/";

            // Try - contains the code that will actually get the values from my stored procedure and convert them to a string
            try
            {
                con.Open();
                reader = oCM.ExecuteReader();
                while (reader.Read())
                { TableRow tempRow = new TableRow();
                    tempCell1 = new TableCell();
                    tempCell1.Text = reader["ProductID"].ToString();

                    tempCell2 = new TableCell();
                    tempCell2.Text = reader["ProductName"].ToString();

                    tempCell3 = new TableCell();
                    tempCell3.Text = reader["CategoryID"].ToString();

                    tempCell4 = new TableCell();
                    tempCell4.Text = reader["CategoryName "].ToString();

                    tempCell5 = new TableCell();
                    tempCell5.Text = reader["Description"].ToString();

                    tempCell6 = new TableCell();
                    tempCell6.Text = reader["Inventory"].ToString();

                    // converts to decimal, converts to string and format it using currency
                    tempCell7 = new TableCell();
                    decimal Cost = Convert.ToDecimal(reader["Cost"].ToString());
                    tempCell7.Text = String.Format("{0:C2}", Cost);

                    tempCell8 = new TableCell();
                    decimal Price = Convert.ToDecimal(reader["Price"].ToString());
                    tempCell8.Text = String.Format("{0:C2}", Price);

                    tempCell9 = new TableCell();
                    tempCell9.Text = reader["Weight"].ToString();

                    tempCell10 = new TableCell();
                    tempCell10.Text = reader["ProductImage"].ToString();

                    tempCell11 = new TableCell();
                    tempCell11.Text = reader["ProductThumbnail"].ToString();
                    // includes my thumbnail picture and even sets its dimensions
                    tempCell12 = new TableCell();
                    Image mypicture = new Image();
                    mypicture.Width = 150;
                    mypicture.Height = 150;
                    // recognizes where to add the picture and where to locate it
                    var ImagePath = mypath + reader["ProductThumbnail"];
                    mypicture.ImageUrl = ImagePath;

                    // adds the picture
                    tempCell11.Controls.Add(mypicture);

                    tempCell12 = new TableCell();
                    tempCell12.Text = reader["CategoryImage"].ToString();

                    tempCell13 = new TableCell();
                    tempCell13.Text = reader["CategoryThumbnail"].ToString();

                    tempCell14 = new TableCell();
                    tempCell14.Text = reader["Availability"].ToString();

                    // add all table cells separately for better organization - better for me as I am a beginner.
                    tempRow.Cells.Add(tempCell1);
                    tempRow.Cells.Add(tempCell2);
                    tempRow.Cells.Add(tempCell3);
                    tempRow.Cells.Add(tempCell4);
                    tempRow.Cells.Add(tempCell5);
                    tempRow.Cells.Add(tempCell6);
                    tempRow.Cells.Add(tempCell7);
                    tempRow.Cells.Add(tempCell8);
                    tempRow.Cells.Add(tempCell9);
                    tempRow.Cells.Add(tempCell10);
                    tempRow.Cells.Add(tempCell11);
                    tempRow.Cells.Add(tempCell12);
                    tempRow.Cells.Add(tempCell13);
                    tempRow.Cells.Add(tempCell14);
                    
                    // loops until adds all
                    ProductsTable.Rows.Add(tempRow);
                }
                reader.Close();
                oCM = null;
                con.Close();
            }
            catch (Exception err)
            {   // displays error message in case of error
                Message.Text = "Error reading list of products. <br />";
                Message.Text += err.Message + "<br />"; 
                Message.Text += mypath + "<br />";
            }
            finally
            {
                con.Close();
            }
        }
    }
}