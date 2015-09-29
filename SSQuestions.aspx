<%@ Page Title="" Language="VB" MasterPageFile="~/HP.master" AutoEventWireup="false"
    CodeFile="SSQuestions.aspx.vb" Inherits="SSQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <hr />
    <meta http-equiv="Page-Enter" content="RevealTrans(Duration=4,Transition=7)" />
    <meta http-equiv="refresh" content="30" />
    <table style="margin-left: 10px; width: 98%;">
        <tr style="height: 5px;">
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="DB" runat="server" ConnectionString="Data Source=INOLYP1CVVDV01;Initial Catalog=ITIM;User ID=ShownShare;Password=Sh0w&sh@re"
                    SelectCommand="select row_number() over(order by askedon asc) as QuestionNo,* from [dbo].[tblShownShare] where approved = 'Yes' order by askedon desc">
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" CellSpacing="5" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="DB" ForeColor="#333333"
                    GridLines="None" PageSize="500" Width="100%" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="QuestionNo" HeaderText="QuestionNo" SortExpression="QuestionNo"
                            ItemStyle-Width="90px" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
                        <asp:BoundField DataField="askedon" HeaderText="Asked at" SortExpression="askedon"
                            DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" ItemStyle-Width="140px"/>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                    <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" Font-Size="Small" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
