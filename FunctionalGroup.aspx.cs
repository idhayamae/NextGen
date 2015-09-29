using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntranetDL;
using Intranet.Utilities;

public partial class FunctionalGroup : BasePage
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

            if (!Page.IsPostBack)
            {
                string strCorpGroup = "";
                strCorpGroup = Request.QueryString["strCorpGroup"] + "";


                Label lblPageHeading = (Label)Master.FindControl("lblPageHeading");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");

                if (strCorpGroup.ToUpper() == "BUSOPS")
                {
                    lblPageHeading.Text = "Business Operations";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Business Operations";
                }
                else
                {
                    lblPageHeading.Text = "Support Group Name";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Support Group Name";
                }

                LoadContents(strCorpGroup.ToUpper());
            }
        }

        catch (Exception ex)
        {
            if (!ex.Message.ToString().Trim().Equals("Thread was being aborted."))
            {
                Util.WriteToLog("FunctionalGroup_Page_Load", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }
    }

    private void LoadContents(string strCorpGroup)
    {
        string topContent = "HP_INT_ORG_" + strCorpGroup + "_TOPCONTENT";
        string tabsListName = "HP_INT_ORG_" + strCorpGroup + "_TABSLIST";
        string tabsContentName = "HP_INT_ORG_" + strCorpGroup + "_TABSCONTENT";


        string contentFromDB = string.Empty;
        DL_Content objDLCotent = new DL_Content();

        //top content
        contentFromDB = objDLCotent.GetContentByName(topContent);
        if (contentFromDB != string.Empty)
        {
            divTopContentContainer.Visible = true;
            divTopCotent.InnerHtml = contentFromDB;
            contentFromDB = string.Empty;
        }
        else
        {
            divTopContentContainer.Visible = false;
        }

        //Center Tabs List
        contentFromDB = objDLCotent.GetContentByName(tabsListName);
        if (contentFromDB != string.Empty)
        {
            divTabsList.InnerHtml = contentFromDB;
            contentFromDB = string.Empty;
        }

        //Center Tabs content
        contentFromDB = objDLCotent.GetContentByName(tabsContentName);
        if (contentFromDB != string.Empty)
        {
            divTabsContent.InnerHtml = contentFromDB;
            contentFromDB = string.Empty;
        }

    }
}