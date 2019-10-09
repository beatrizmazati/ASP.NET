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
    public partial class InsertProducts : System.Web.UI.Page
    {
        // Step 1 gets the connection string from the project`s Web.config file
        string mazatiAndersonCS = WebConfigurationManager.ConnectionStrings["MazatiAnderson"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* In each page, manually insert the data. Use the stored procedure you created last week! 
             * You'll need to pass the values as parameters. */
            try
            {

                    SqlConnection oC = new SqlConnection(mazatiAndersonCS);
                    oC.Open();
                    SqlCommand oCM = new SqlCommand();
                    oCM.Connection = oC;
                    oCM.CommandType = System.Data.CommandType.StoredProcedure;

                    // stored procedure from last week
                    oCM.CommandText = "InsertProductsParam"; 

                    // Commands the paramater and SQL statement
                    oCM.Parameters.Add("@ProductID", SqlDbType.Int);
                    oCM.Parameters.Add("@ProductName", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@CategoryID", SqlDbType.Int);
                    oCM.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@Description", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@Inventory", SqlDbType.Int);
                    oCM.Parameters.Add("@Cost", SqlDbType.Float);
                    oCM.Parameters.Add("@Price", SqlDbType.Float);
                    oCM.Parameters.Add("@Weight", SqlDbType.Float);
                    oCM.Parameters.Add("@ProductImage", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@ProductThumbnail", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@CategoryImage", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@CategoryThumbnail", SqlDbType.NVarChar);
                    oCM.Parameters.Add("@Availability", SqlDbType.NVarChar);

                    // Assigns the values with the asp ID`s
           
                    oCM.Parameters["@ProductID"].Value = ProdID.Text;
                    oCM.Parameters["@ProductName"].Value = ProdName.Text;
                    oCM.Parameters["@CategoryID"].Value = CatID.Text;
                    oCM.Parameters["@CategoryName"].Value = CatName.Text;
                    oCM.Parameters["@Description"].Value = Desc.Text;
                    oCM.Parameters["@Inventory"].Value = Invent.Text;
                    oCM.Parameters["@Cost"].Value = Cost.Text;
                    oCM.Parameters["@Price"].Value = Price.Text;
                    oCM.Parameters["@Weight"].Value = Weight.Text;
                    oCM.Parameters["@ProductImage"].Value = ProdImage.Text;
                    oCM.Parameters["@ProductThumbnail"].Value = ProdThumb.Text;
                    oCM.Parameters["@CategoryImage"].Value = CatImg.Text;
                    oCM.Parameters["@CategoryThumbnail"].Value = CatThumb.Text;
                    oCM.Parameters["@Availability"].Value = Availability.Text;

                    // Output results returned
                    int myReturn = oCM.ExecuteNonQuery();

                /*When the data is inserted, display 
                 * a message showing that the data is inserted.*/

                this.results.Text = "Record Inserted" + "<br /><br />Rows affected:  " + myReturn.ToString();
                    oCM = null;
                    oC.Close();
                }
                // displays error message
                catch (Exception err)
                {
                    this.results.Text = "Record not available: <br/>" + "Error message: " + err.Message;
                }


           







        }
    }
}