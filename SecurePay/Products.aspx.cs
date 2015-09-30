using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using IntranetDL;
using Intranet.Utilities;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("https://vzweb2.verizon.com/");
        try
        {
            /*string strEmpEid = CheckSSO();
            if (!string.IsNullOrEmpty(strEmpEid))
            {
                Int64 EmpEid = Convert.ToInt64(strEmpEid);
                SetUserSession(EmpEid);
            }*/

            if (!Page.IsPostBack)
            {
                Label lblPageHeading = (Label)Master.FindControl("lblPageHeading");
                lblPageHeading.Text = "SecurePay";

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "Home / Products";

                // LoadContents();
            }
        }
        catch (Exception ex)
        {
            if (!ex.Message.ToString().Trim().Equals("Thread was being aborted."))
            {
                Util.WriteToLog("Index_Page_Load", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }
    }
}