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
    public partial class DeleteProducts : System.Web.UI.Page
    {
        // Pulls connection string from Web.config file
        string mazatiAndersonCS = WebConfigurationManager.ConnectionStrings["MazatiAnderson"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Use the same process to display the records in the table and dropdown list but store it in 
             * separate functions. It's easier to have different functions for displaying and deleting data. 
             * (You can make it one, but you have to use different connection, command and reader objects 
             * which can get messy for beginners.)*/

            if (!Page.IsPostBack) // if the user has not been there before
            {
                try
                {   // connects to my CS, opens it and gives it SQL commands
                    SqlConnection oC = new SqlConnection(mazatiAndersonCS);
                    oC.Open();
                    SqlCommand oCM = new SqlCommand();
                    oCM.Connection = oC;
                    oCM.CommandType = System.Data.CommandType.Text;
                    oCM.CommandText = "SELECT ProductID, ProductName FROM Products ORDER BY ProductID";
                    SqlDataReader reader = oCM.ExecuteReader();
                    while (reader.Read())
                    {  // passes the new items - text and value - to string
                        ListItem newItem = new ListItem();
                        newItem.Text = reader["ProductName"].ToString();
                        newItem.Value = reader["ProductID"].ToString();
                        ddlProdID.Items.Add(newItem);
                    }

                    reader.Close();
                    oCM = null;
                    oC.Close();

                }
                catch (Exception err)
                {
                    // displays message to the user
                    this.results.Text = "Records not available! <br/>"
                        + "Error: " + err.Message;
                }
            }
            else // if the user has been there before
            {
                try
                {
                    // Connection object - connects to my connection string
                    SqlConnection oC = new SqlConnection(mazatiAndersonCS);
                    oC.Open();
                    // Command object
                    SqlCommand oCM = new SqlCommand();
                    oCM.Connection = oC;
                    // uses a stored procedure from last week`s assignment
                    oCM.CommandType = System.Data.CommandType.StoredProcedure;
                    oCM.CommandText = "DeleteProducts";
                    // this is the name of the parameter I have used for last week`s assignment
                    oCM.Parameters.Add("@pProductID", SqlDbType.Int);
                    oCM.Parameters["@pProductID"].Value =
                        ddlProdID.SelectedItem.Value.ToString();
                    int myReturn = oCM.ExecuteNonQuery();

                    // displays a message to the user informing the product was successfully deleted
                    results.Text = "Record Deleted: " + ddlProdID.SelectedItem.Text.ToString();
                    oCM = null;
                    oC.Close();
                }
                catch (Exception err)
                {
                    // informs the error in case an exception is detected
                    this.results.Text = "Record not deleted. <br/> "
                        + "Text: " + ddlProdID.SelectedItem.Text.ToString() + " <br/> "
                        + "Value: " + ddlProdID.SelectedItem.Value.ToString() + " <br /> "
                        + "Error: " + err.Message;
                }
            }
        }
    }
}
