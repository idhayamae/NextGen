using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Set logged user session
        SetUserSession(Convert.ToInt64(TextBox1.Text));
        if (UserSession.EmpEID != null)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
