using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Intranet.Utilities;
using System.Collections.Generic;
using IntranetPL;

namespace IntranetDL
{
    public class DL_VirtualCard
    {
        private string strConnection = ConfigurationManager.AppSettings["ConnectionString"].ToString();

        public DL_VirtualCard()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public string CheckVirtualCard(string strUserName)
        {
            string result = "";
            using (SqlConnection myConnection = new SqlConnection(strConnection))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ValidateVirtualCard", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(strUserName))
                        myCommand.Parameters.AddWithValue("@uname", strUserName);


                    myConnection.Open();
                    SqlDataReader objRead = myCommand.ExecuteReader();
                    if (objRead.HasRows)
                    {
                        if (objRead.Read())
                        {
                            result = objRead[0].ToString();
                        }
                    }
                }
                myConnection.Close();
            }
            return result;  
        }
	public int CreateVirtualCard(string strUserName)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(strConnection))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_CreateVirtualCard", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(strUserName))
                        myCommand.Parameters.AddWithValue("@strUserId", strUserName);


                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result;
        }

    public int AddNewCard(string strCardNumber, int intBankCode, int intCardType, int intAccountType, int intPriority, int intPerc)
    {
        int result = 0;
        using (SqlConnection myConnection = new SqlConnection(strConnection))
        {
            using (SqlCommand myCommand = new SqlCommand("usp_AddNewCard", myConnection))
            {
                myCommand.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(strCardNumber))
                    myCommand.Parameters.AddWithValue("@strCard", strCardNumber);

                if (!string.IsNullOrEmpty(strCardNumber))
                    myCommand.Parameters.AddWithValue("@intBank", intBankCode);

                if (!string.IsNullOrEmpty(strCardNumber))
                    myCommand.Parameters.AddWithValue("@intCard", intCardType);

                if (!string.IsNullOrEmpty(strCardNumber))
                    myCommand.Parameters.AddWithValue("@intAccount", intAccountType);

                if (!string.IsNullOrEmpty(strCardNumber))
                    myCommand.Parameters.AddWithValue("@intPriority", intPriority);

                if (!string.IsNullOrEmpty(strCardNumber))
                    myCommand.Parameters.AddWithValue("@intPerc", intPerc);


                myConnection.Open();
                result = myCommand.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        return result;
    }








    }
}
