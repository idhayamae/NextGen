<%@ Page Title="" Language="VB" MasterPageFile="~/HP.master" AutoEventWireup="false"
    CodeFile="ShownShare.aspx.vb" Inherits="ShownShare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript">
        function Count(text, long) {
            var maxlength = new Number(long); // Change number to your max length.
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                alert(" Only " + long + " chars");
            }
        }
        function Disable_Control_C() {
            var keystroke = String.fromCharCode(event.keyCode).toLowerCase();

            if (event.ctrlKey && (keystroke == 'c' || keystroke == 'v')) {
                alert("Cntrl key Option disabled");
                event.returnValue = false; // disable Ctrl+C
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <hr />
    <table border="1" style="margin-left: 10px; width: 100%;">
        <tr>
            <td>
                <object id="playerId" classid='clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921' width="500px"
                    height="300px" events='True'>
                    <param name='AutoPlay' value='true' />
                    <param name='ShowDisplay' value='True' />
                    <param name='Src' value='rtsp://114.9.185.232:1935/live/verizon' />
                    <param name="Volume" value="80">
                </object>
            </td>
            <td>
                <table>
                    <tr>
                        <td colspan="2">
                            <h1>
                                Ask the Leaders
                            </h1>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtQuestion" runat="server" MaxLength="300" TextMode="MultiLine"
                                Height="83px" Width="370px" onKeyUp="Count(this,299)" onblur="Count(this,299)"
                                onChange="Count(this,299)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="ChkAnonymous" runat="server" Text=" Click here: If you like to submit this question as anonymous"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 70px;">
                            Your Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="300" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="True" Height="35px"
                                Width="96px" Font-Size="Small" />
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="2">
                            <a target="_blank" href="SSQuestions.aspx" title="Click Here to view Questions">Click
                                here to view the questions</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 20px;">
        </tr>
    </table>    
    <table border="1" style="margin-left: 10px; width: 925px;">
        <tr>
            <td>
                <iframe id="frame1" src="Questionsframe.aspx" frameborder="1" style="width: 910px;
                    height: 500px"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
