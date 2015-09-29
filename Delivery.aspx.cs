using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IntranetDL;
using Intranet.Utilities;

public partial class Delivery : BasePage
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


            int OID = 0;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["OID"].ToString() != "")
                    OID = Convert.ToInt32(Request.QueryString["OID"]);

                if (OID > 0)
                {
                    LoadContents(OID);
                }

            }
        }

        catch (Exception ex)
        {
            if (!ex.Message.ToString().Trim().Equals("Thread was being aborted."))
            {
                Util.WriteToLog("Delivery_Page_Load", ex.Message.ToString(), UserSession.EmpID);
                Response.Redirect(FindLink.ToNotAuthorised("Error"), true);
            }
        }
    }

    private void LoadContents(int OID)
    {
        Label lblPageHeading = (Label)Master.FindControl("lblPageHeading");
        Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");


        DL_Content objDL = new DL_Content();
        DataSet ds = new DataSet();

        string Org = string.Empty;
        string OrgNickName = string.Empty;

        ds = objDL.GetDetailsByOrgID(OID);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Org = ds.Tables[0].Rows[0]["OrgName"].ToString();
            OrgNickName = ds.Tables[0].Rows[0]["NickName"].ToString().ToUpper();

            lblPageHeading.Text = Org;
            lblBreadCrumb.Text = "<a href='index.aspx'> Home </a> / " + Org;

            string topContent = "HP_INT_DELIVERY_" + OrgNickName + "_TOPCONTENT";

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

            //Prepare tab headings
            DataSet dsSDHList = new DataSet();
            dsSDHList = objDLCotent.GetSDHByOrgID(OID);

            string tabsList = string.Empty;
            string tabsContent = string.Empty;

            if (dsSDHList != null && dsSDHList.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsSDHList.Tables[0].Rows.Count; i++)
                {
                    //prepare tabs list
                    if (i == 0)
                        tabsList += "<li class='new_st'><a class='active_tab' href='#" + dsSDHList.Tables[0].Rows[i]["SDHID"].ToString() + "_tab'><span class='news_icon1'>" + dsSDHList.Tables[0].Rows[i]["NickName"].ToString() + "'s Org</span></a></li>";
                    else
                        tabsList += "<li class='new_st'><a href='#" + dsSDHList.Tables[0].Rows[i]["SDHID"].ToString() + "_tab'><span class='news_icon1'>" + dsSDHList.Tables[0].Rows[i]["NickName"].ToString() + "'s Org</span></a></li>";

                    //prepare content
                    tabsContent += "<section class='gt_content' id='" + dsSDHList.Tables[0].Rows[i]["SDHID"].ToString() + "_tab'>";

                    contentFromDB = objDLCotent.GetContentByName("HP_INT_DELIVERY_" + dsSDHList.Tables[0].Rows[i]["NickName"].ToString() + "_CONTENT");
                    if (contentFromDB != string.Empty)
                    {
                        tabsContent += contentFromDB;
                        tabsContent += "</section>";
                        contentFromDB = string.Empty;
                    }
                    else
                    {
                        //tabsContent += dsSDHList.Tables[0].Rows[i]["SDHName"].ToString() + " Content Not updated!!";
                        tabsContent += "<br/<br/><h2>Page Under Construction</h2><br/><br/>";
                        tabsContent += "</section>";
                    }

                }

                divTabsList.InnerHtml = tabsList;
                divTabsContent.InnerHtml = tabsContent;
            }

        }
    }
}