using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IntranetPL;
using IntranetDL;

namespace IntranetBL
{
    public class BL_VirtualCard
    {
        private DL_VirtualCard objDL = new DL_VirtualCard();

        public BL_VirtualCard()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public int CreateVirtualCard(string strUserName)
        {
            return objDL.CreateVirtualCard(strUserName);
        }

        public string CheckVirtualCard(string strUserName)
        {
            return objDL.CheckVirtualCard(strUserName);
        }

        public int AddNewCard(string strCardNumber, int intBankCode, int intCardType, int intAccountType, int intPriority, int intPerc)
        {
            return objDL.AddNewCard(strCardNumber, intBankCode, intCardType, intAccountType, intPriority, intPerc);
        }
    }

        
}
