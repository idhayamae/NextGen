<%@ Page Title="" Language="VB" MasterPageFile="~/HP.master" AutoEventWireup="false"
    CodeFile="Moderator.aspx.vb" Inherits="Moderator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <hr />
    <table style="margin-left: 10px; width: 98%;">
        <tr style="height: 5px;">
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvQuestions" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" ForeColor="#333333"
                    GridLines="None" PageSize="500" Width="100%" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="QId" HeaderText="QId" InsertVisible="False" ReadOnly="True"
                            SortExpression="QId" ItemStyle-Width="40px" ItemStyle-VerticalAlign="Middle" />
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"
                            ItemStyle-VerticalAlign="Middle" />
                        <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question"
                            ItemStyle-VerticalAlign="Middle" />
                        <asp:BoundField DataField="Askedon" HeaderText="Askedon" SortExpression="Askedon"
                            DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" ItemStyle-Width="150px" ItemStyle-VerticalAlign="Middle" />
                        <asp:TemplateField ItemStyle-VerticalAlign="Middle" SortExpression="Approved" HeaderText="Approved">
                            <ItemTemplate>
                                <asp:Label ID="lblApproved" runat="server" Text='<%#Eval("Approved")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelection" runat="server" /></ItemTemplate>
                        </asp:TemplateField>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=INOLYP1CVVDV01;Initial Catalog=ITIM;User ID=ShownShare;Password=Sh0w&sh@re"
                    SelectCommand="SELECT * FROM [tblShownShare] order by qid desc"></asp:SqlDataSource>
            </td>
        </tr>
        <tr style="height: 10px;">
        </tr>
        <tr>
            <td>
                <center>
                    <asp:Button ID="btndeProvision" runat="server" Text="Approve" Font-Bold="True" Height="35px"
                        Width="100px" Font-Size="Small" />
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
