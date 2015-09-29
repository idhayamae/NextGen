using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotAuthorised : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strEmpEid = CheckSSO();
            if (!string.IsNullOrEmpty(strEmpEid))
            {
                Int64 EmpEid = Convert.ToInt64(strEmpEid);
                SetUserSession(EmpEid);
            }

            if (Request.QueryString.Get("e") != null)
            {
                lblError.Visible = true;
                lblNotAuthorised.Visible = false;
            }
            else
            {
                lblError.Visible = false;
                lblNotAuthorised.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
}