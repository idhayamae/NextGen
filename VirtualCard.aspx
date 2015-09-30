<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HP.master" CodeFile="VirtualCard.aspx.cs" Inherits="VirtualCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="Popup_1/Js/function.js"></script>
    <link rel="stylesheet" type="text/css" href="Popup_1/Css/styles.css" /> 

        <script type="text/javascript">
            function enableordisable() {
                if (document.getElementById('ContentPlaceHolder1_chkAgree').checked == true) {
                    document.getElementById('ContentPlaceHolder1_btnAgree').disabled = false;
                }
                else {
                    document.getElementById('ContentPlaceHolder1_btnAgree').disabled = true;
                }
            }

            function makeVisible() {
                if (document.getElementById('ContentPlaceHolder1_chkAgree').checked == true) {
                    document.getElementById('ContentPlaceHolder1_btnAgree').disabled = false;
                }
                else {
                    document.getElementById('ContentPlaceHolder1_btnAgree').disabled = true;
                }
            }
            </script>
    <div class="selectlocation l_popup">
            <div class="close_l_popup">
            </div>
        </div>   

        <script type="text/javascript">
           
           
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">	
    <div class="divider">
    </div>
    <div id="divSliderContent" runat="server">
    </div>
    <section class="text_container">
		<div class="grid_8 eq_hgt">
			<section class="tabset_top">			
                <div id="divCenterTabsList" runat="server"></div>	
			    <section class="tab_content_main">
			        <div id="divCenterTabsContent" runat="server">

                        <asp:RadioButtonList ID="rdoList" runat="server" Enabled="false">
                            <asp:ListItem Value="New Virtual card" Selected="true"></asp:ListItem>
                            <asp:ListItem Value="Configure Existing Virtual Card"></asp:ListItem>
                        </asp:RadioButtonList>
                        <div id="divAgree" runat="server" visible ="false" >
                            Virtual Card is a feature enabled for all customers who can attach all their Credit / Debit cards for making the payment in  secure way and without providing the details for each & every transaction.

                            By providing this feature to the customers, Verizon ensures to strengthen the security and not sharing the customer card details to any Third party. By agreeing to this terms & conditions, you are allowing Verizon to process for product purchase / payment services using your cards.
                            <Br />
                            <asp:CheckBox ID="chkAgree" runat="server" onchange="enableordisable();"  /> I agree to the above terms and conditions.

                            <BR />
                            <asp:Button id="btnAgree" runat="server" Text="I Agree" OnClick="btnAgree_Click" Enabled="false"/>
                        </div>
			        </div>            
                    <div>
                        <hr />
                        <div><asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text ="Add New Card"/></div>
                        <div runat="server" id="divAddCard" visible="false" >
                            <table>
                                <tr>
                                    <td>
                                        Card Number :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCardNumber" runat="server" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Bank :
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdoBankList" runat="server" TextAlign ="Left" >
                                            <asp:ListItem Text="HDFC" Selected="true" Value ="1"></asp:ListItem>
                                            <asp:ListItem Text="CITIBANK" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Card Type :
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdoCardType" runat="server" >
                                                <asp:ListItem Text="MAESTRO" Selected="true" Value ="1"></asp:ListItem>
                                                <asp:ListItem Text="VISA" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="AMEX" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        Account Type :
                                    </td>
                                    <td>
                                         <asp:RadioButtonList ID="rdoAccountType" runat="server" OnSelectedIndexChanged="rdoAccountType_SelectedIndexChanged1">
                                                    <asp:ListItem Text="CREDIT" Selected="true" Value ="1"></asp:ListItem>
                                                    <asp:ListItem Text="DEBIT" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Card Priority :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPriority" runat="server" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Share Percentage :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPercentage" runat ="server" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        AutoPay :
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdoAutoPay" runat="server">
                                                    <asp:ListItem Text="YES" Selected="true" Value ="1"></asp:ListItem>
                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>

                            <div id="divConfirmation" runat ="server" >
                            For the Credit card, you can also use the feature of paying the Due amount from your Debit card / Savings Account. For this, there is service charge as 1% of your transaction. <br />
                            <asp:CheckBox ID="chkConfirm" runat="server" /> I agree to the above terms and conditions.
                            </div>

                            <br /><br />
                            <asp:Button id="btnSubmit" runat="server" text="Submit" OnClick="btnSubmit_Click"/>
                        </div>
                    </div>
			    </section>
			</section>
		</div>
		<!--Main Column-->
   </section>
</asp:Content>
