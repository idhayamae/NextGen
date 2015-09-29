using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Intranet.Utilities;
using IntranetBL;

public partial class EnterFeedback : System.Web.UI.Page
{
    string strEmpEid = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strEmpEid = BasePage.CheckSSO();
            if (!string.IsNullOrEmpty(strEmpEid))
            {
                Int64 EmpEid = Convert.ToInt64(strEmpEid);
                BasePage.SetUserSession(EmpEid);
            }


            if (!Page.IsPostBack)
            {
                Label lblPageHeading = (Label)Master.FindControl("lblPageHeading");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");

                lblPageHeading.Text = "Enter Feedback";
                lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Enter Feedback";

                if (UserSession.VZID == null || UserSession.VZID == string.Empty)
                {
                    txtName.Enabled = true;
                    txtEmail.Enabled = true;
                }
                else
                {
                    txtName.Text = UserSession.EmpName;
                    txtEmail.Text = UserSession.Email;

                    txtName.Enabled = false;
                    txtEmail.Enabled = false;
                }
            }



        }
        catch (Exception ex)
        {
            if (!ex.Message.ToString().Trim().Equals("Thread was being aborted."))
            {
                Util.WriteToLog("Feedback_Page_Load", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (txtMessage.Text.Trim() == string.Empty)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Pleae enter the message!!";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtName.Text.Trim() == string.Empty || txtEmail.Text.Trim() == string.Empty || txtMessage.Text.Trim() == string.Empty)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Pleae enter Name,Email Address and Message!!";
                lblMessage.ForeColor = Color.Red;
            }            
            else
            {
                int res = 0;
                BL_Employee objBL = new BL_Employee();

                if (!string.IsNullOrEmpty(UserSession.VZID) && UserSession.VZID != "0")
                    res = objBL.SendFeedbackMail(Convert.ToInt64(UserSession.EmpEID), UserSession.EmpName, UserSession.Email, txtMessage.Text.Trim());
                else
                    res = objBL.SendFeedbackMail(0, txtName.Text, txtEmail.Text, txtMessage.Text.Trim());


                lblMessage.Visible = true;

                if (res > 0)
                {
                    txtMessage.Text = string.Empty;
                    lblMessage.Text = "Thanks for your feedback!!";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "There is a problem with your request. Please try after some time!!";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            if (!ex.Message.ToString().Trim().Equals("Thread was being aborted."))
            {
                Util.WriteToLog("Feedback_btnSubmit_OnClick", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }
    }

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        try
        {
            txtMessage.Text = string.Empty;
            lblMessage.Text = string.Empty;
            lblMessage.Visible = false;
        }
        catch (Exception ex)
        {
            if (!ex.Message.ToString().Trim().Equals("Thread was being aborted."))
            {
                Util.WriteToLog("Feedback_btnSubmit_OnClick", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }

    }
}