using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntranetDL;
using Intranet.Utilities;

public partial class Org : BasePage
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

                if (strCorpGroup.ToUpper() == "HR")
                {
                    lblPageHeading.Text = "Human Resources";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / HR";
                }
                else if (strCorpGroup.ToUpper() == "FINANCE")
                {
                    lblPageHeading.Text = "Finance";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Finance";
                }
                else if (strCorpGroup.ToUpper() == "ITINFRA")
                {
                    lblPageHeading.Text = "IT Infrastructure";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / IT Infrastructure";
                }
                else if (strCorpGroup.ToUpper() == "GRE")
                {
                    lblPageHeading.Text = "Global Real Estate";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Global Real Estate";
                }
                else if (strCorpGroup.ToUpper() == "BUSOPS")
                {
                    lblPageHeading.Text = "Business Operations";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Business Operations";
                }
                else if (strCorpGroup.ToUpper() == "SUPPLYCHAIN")
                {
                    lblPageHeading.Text = "Supply Chain Services";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Supply Chain Services";
                }
                else if (strCorpGroup.ToUpper() == "LEGAL")
                {
                    lblPageHeading.Text = "Legal and Compliance";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Legal and Compliance";
                }
                else if (strCorpGroup.ToUpper() == "CSECURITY")
                {
                    lblPageHeading.Text = "Cyber Security";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Cyber Security";
                }
                else if (strCorpGroup.ToUpper() == "PSECURITY")
                {
                    lblPageHeading.Text = "Physical Security";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Physical Security";
                }
                else if (strCorpGroup.ToUpper() == "CORPCOMM")
                {
                    lblPageHeading.Text = "Corporate Communications";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Corporate Communications";
                }
                else if (strCorpGroup.ToUpper() == "ERG")
                {
                    lblPageHeading.Text = "ERG";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / ERG";
                }
		else if (strCorpGroup.ToUpper() == "VLSS")
                {
                    lblPageHeading.Text = "Verizon Lean Six Sigma";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / Verizon Lean Six Sigma";
                }
                else if (strCorpGroup.ToUpper() == "CC")
                {
                    lblPageHeading.Text = "Employee Resource Groups ";
                    lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / ERG";
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
                Util.WriteToLog("Org_Page_Load", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }
    }

    private void LoadContents(string strCorpGroup)
    {
        string tabsListName = "HP_INT_ORG_" + strCorpGroup + "_TABSLIST";
        string tabsContentName = "HP_INT_ORG_" + strCorpGroup + "_TABSCONTENT";

        string contentFromDB = string.Empty;
        DL_Content objDL = new DL_Content();


        //Center Tabs List
        contentFromDB = objDL.GetContentByName(tabsListName);
        if (contentFromDB != string.Empty)
        {
            divTabsList.InnerHtml = contentFromDB;
            contentFromDB = string.Empty;
        }

        //Center Tabs content
        contentFromDB = objDL.GetContentByName(tabsContentName);
        if (contentFromDB != string.Empty)
        {
            divTabsContent.InnerHtml = contentFromDB;
            contentFromDB = string.Empty;
        }

    }
}