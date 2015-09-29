<%@ Page Title="" Language="C#" MasterPageFile="~/HP.master" AutoEventWireup="true"
    CodeFile="EnterFeedback.aspx.cs" Inherits="EnterFeedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divider">
    </div>
    <div style="padding-left: 10px;">
        <ajaxToolkit:ToolkitScriptManager ID="smSample" runat="server" EnableHistory="true">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="updCreatePool" runat="server">
            <ContentTemplate>
                <table border="1">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 8px">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            <b>Your Full Name</b>
                        </td>
                        <td>
                            <asp:TextBox ForeColor="Black" ID="txtName" runat="server" Style="width: 380px" class="text"
                                Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 8px">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Email Address</b>
                        </td>
                        <td>
                            <asp:TextBox ForeColor="Black" ID="txtEmail" runat="server" Style="width: 380px"
                                class="text" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 8px">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Message</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtMessage" Style="margin-bottom: 10px; width: 380px;
                                height: 140px" TextMode="MultiLine"></asp:TextBox>
                            <div class="btnWrapper">
                                <div class="fl">
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_OnClick"
                                        class="button small" Text="Cancel" />
                                </div>
                                <div class="fr">
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_OnClick" class="button small"
                                        Text="Submit" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateeProgress1" runat="server">
            <ProgressTemplate>
                <asp:Panel ID="pnlLoading" runat="server" Style="position: absolute; z-index: 1;
                    left: 50%; top: 50%">
                    <asp:Image ID="imgLoading" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading..." />
                </asp:Panel>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
