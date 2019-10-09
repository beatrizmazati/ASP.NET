using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient; // uses SqlClient Class
using System.Web.Configuration; // Gets Connection String

namespace Beatriz_Mazati_Anderson.Database
{
    public partial class UpdateProducts : System.Web.UI.Page
    {
        // Pulls connection string from Web.config file
        // Step 3: Above the Page_Load event handler, create a variable to store the connection string
        string mazatiAndersonCS = WebConfigurationManager.ConnectionStrings["MazatiAnderson"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Code from delete products that could be reused! Thank you for the tip!
            if (!Page.IsPostBack) // if the user has not been there before
            {
                try
                {   // connects to my CS, opens it and gives it SQL commands - Creates Data Objects
                    // So create your connection, command and data reader objects. This goes inside the first 'try' block above. 
                    // Renamed my variables by adding 1 as suggested for me to not get confused
                    SqlConnection oC1 = new SqlConnection(mazatiAndersonCS);
                    oC1.Open();
                    SqlCommand oCM1 = new SqlCommand();
                    oCM1.Connection = oC1;
                    oCM1.CommandType = System.Data.CommandType.Text;
                    oCM1.CommandText = "SELECT ProductID, ProductName FROM Products ORDER BY ProductID";
                    SqlDataReader reader1 = oCM1.ExecuteReader();

                    // displays the list data
                    // Use the while clause to loop through each record returned: while (reader1.Read())

                    while (reader1.Read())
                    {  // passes the new items - text and value - to string
                        ListItem newItem = new ListItem();
                        // Set the ProductName to the dropdown list text property and the ProductID to the value property. 
                        newItem.Text = reader1["ProductName"].ToString();
                        newItem.Value = reader1["ProductID"].ToString();
                        ddlProdID.Items.Add(newItem);
                    } // end while clause

                    reader1.Close();
                    oCM1 = null;
                    oC1.Close();

                } // end try
                // Use exception handling to intercept any errors and provide a message if there is an error.
                catch (Exception err)
                {
                    // displays message to the user
                    this.results1.Text = "Records not available! <br/>"
                        + "Error: " + err.Message;
                } // end catch
            } // end if statement
        } // end Page_Load

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            // Step 5. Write the Code to Populate the Form Fields
            // Inside the Button Click event handler, create your connection, command and data reader objects. 

            try
            {  
                
                SqlConnection oC2 = new SqlConnection(mazatiAndersonCS);
                oC2.Open();
                SqlCommand oCM2 = new SqlCommand();
                oCM2.Connection = oC2;
                oCM2.CommandType = System.Data.CommandType.Text;

                /* Note that the SQL command will be different. You need to retrieve just the one record back, 
                 where the ProductID matches the ProductID which is the value of the item selected in the dropdown list. */

                oCM2.CommandText = "SELECT * FROM Products WHERE ProductID = "
                                    + ddlProdID.SelectedItem.Value; // choses the ProductID the user selected from the dropdown list
                                                                    // only updates one record

                SqlDataReader reader2 = oCM2.ExecuteReader();

                // Assign the values to text boxes - complete this for each of the fields in the table.

                while (reader2.Read()) // use a while loop to go through all products - otherwise it would just go through row
                {
                    ProdID.Text = reader2["ProductID"].ToString();
                    ProdName.Text = reader2["ProductName"].ToString();
                    CatID.Text = reader2["CategoryID"].ToString();
                    CatName.Text = reader2["CategoryName"].ToString();
                    Desc.Text = reader2["Description"].ToString();
                    Invent.Text = reader2["Inventory"].ToString();
                    Cost.Text = reader2["Cost"].ToString();
                    Price.Text = reader2["Price"].ToString();
                    Weight.Text = reader2["Weight"].ToString();
                    ProdImage.Text = reader2["ProductImage"].ToString();
                    ProdThumb.Text = reader2["ProductThumbnail"].ToString();
                    CatImg.Text = reader2["CategoryImage"].ToString();
                    CatThumb.Text = reader2["CategoryThumbnail"].ToString();
                    Availability.Text = reader2["Availability"].ToString();

                } // end while

                reader2.Close();
                oCM2 = null;
                oC2.Close();

            } // end try

            catch (Exception err)
            {
                this.results1.Text = "Records not available: <br/>"
                    + "Error: " + err.Message;
            } // end catch

        } // end UpdateButton_Clic

        protected void UpdateButton2_Click(object sender, EventArgs e)
        {
            // Step 6 - Create the data objects.
            try
            {
                SqlConnection oC3 = new SqlConnection(mazatiAndersonCS);
                oC3.Open();
                SqlCommand oCM3 = new SqlCommand();
                oCM3.Connection = oC3;
                oCM3.CommandType = System.Data.CommandType.StoredProcedure;

                oCM3.CommandText = "UpdateProducts";

                // step 7 - Create the parameter objects - used the code from the step 6.7 from homework to get started

                oCM3.Parameters.Add("@ProductID", SqlDbType.Int);
                oCM3.Parameters.Add("@ProductName", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@CategoryID", SqlDbType.Int);
                oCM3.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@Description", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@Inventory", SqlDbType.Int);
                oCM3.Parameters.Add("@Cost", SqlDbType.Float);
                oCM3.Parameters.Add("@Price", SqlDbType.Float);
                oCM3.Parameters.Add("@Weight", SqlDbType.Float);
                oCM3.Parameters.Add("@ProductImage", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@ProductThumbnail", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@CategoryImage", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@CategoryThumbnail", SqlDbType.NVarChar);
                oCM3.Parameters.Add("@Availability", SqlDbType.NVarChar);

                /* To make it simpler for you, just assign the values to text boxes. 
                Complete this for each of the fields in the table. Of course you need to do this for all of the columns in the table, including the ID field.) */
                oCM3.Parameters["@ProductID"].Value = ProdID.Text;
                oCM3.Parameters["@ProductName"].Value = ProdName.Text;
                oCM3.Parameters["@CategoryID"].Value = CatID.Text;
                oCM3.Parameters["@CategoryName"].Value = CatName.Text;
                oCM3.Parameters["@Description"].Value = Desc.Text;
                oCM3.Parameters["@Inventory"].Value = Invent.Text;
                oCM3.Parameters["@Cost"].Value = Cost.Text;
                oCM3.Parameters["@Price"].Value = Price.Text;
                oCM3.Parameters["@Weight"].Value = Weight.Text;
                oCM3.Parameters["@ProductImage"].Value = ProdImage.Text;
                oCM3.Parameters["@ProductThumbnail"].Value = ProdThumb.Text;
                oCM3.Parameters["@CategoryImage"].Value = CatImg.Text;
                oCM3.Parameters["@CategoryThumbnail"].Value = CatThumb.Text;
                oCM3.Parameters["@Availability"].Value = Availability.Text;

                /* Add the code to run the command. Remember that you use ExecuteNonQuery 
                 * because we are not using a SELECT command. An integer is returned letting us know how many records were affected. */
                int myReturn = oCM3.ExecuteNonQuery();
                this.results2.Text = myReturn + " record updated: <br/>";

              
                oCM3 = null;
                oC3.Close(); 
            } // end try

            // Complete closing your objects and creating the Catch block as you have in the other blocks.
            catch (Exception err)
            {
                this.results2.Text = "Records not updated: <br/>" + "Error: " + err.Message;
            }
            } // end UpdateButton2_Click
    } // end class UpdateProducts
} // end namespace