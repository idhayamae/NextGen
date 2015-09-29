using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class RedirectPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strVZID = "";
        string strApplSSLURL = "";
        strVZID = Request.ServerVariables["http_vzid"] + "";
        //strVZID = "v718927";
        string strLink = "";
        if (strVZID.Trim() != "")
        {
            strLink = GetLink(strVZID);
        }
        if (strLink.Trim() != "")
            Response.Redirect(strLink);
        else
        {
            strApplSSLURL = System.Configuration.ConfigurationSettings.AppSettings["links"];
            Response.Redirect(strApplSSLURL);
        }
        /*if (!IsPostBack)
        {
            Session.Abandon();
        }*/
    }
    public string GetLink(string strVZID)
    {
        string strLink = "";


        string strConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        using (SqlConnection myConnection = new SqlConnection(strConnectionString))
        {
            try
            {
                using (SqlCommand myCommand = new SqlCommand("USP_GET_LINKS", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@PI_VZID", strVZID);

                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        strLink = reader.GetValue(0).ToString();
                    }


                }
            }
            catch (Exception ex)
            {
                strLink = "";
            }
            finally
            {
                myConnection.Close();
            }
            // result will be 1 in case of success 
            return strLink;
        }

    }
}