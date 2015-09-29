Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Intranet.Utilities

Partial Class Moderator
    Inherits BasePage
    Dim conStr As String = "Data Source=INOLYP1CVVDV01;Initial Catalog=ITIM;User ID=ShownShare;Password=Sh0w&sh@re"



    Protected Sub btndeProvision_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btndeProvision.Click
        Dim Chk As New CheckBox
        Dim D As GridViewRow

        For Each D In gvQuestions.Rows
            Chk = D.FindControl("chkSelection")
            If Chk.Checked = True Then
                Dim Qid As Integer
                Qid = D.Cells(0).Text.Trim()
                Dim con As New SqlConnection(conStr)
                con.Open()
                Dim strQuery As String
                strQuery = "update  tblShownShare set Approved='Yes' where Qid = " & Qid
                Dim cmd As New SqlCommand(strQuery, con)
                cmd.ExecuteNonQuery()


            End If
        Next
        Response.Redirect("moderator.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim strEmpEid As String = CheckSSO()
        If Not String.IsNullOrEmpty(strEmpEid) Then
            Dim EmpEid As Int64 = Convert.ToInt64(strEmpEid)
            SetUserSession(EmpEid)
        End If

        If Not IsPostBack Then
            Dim Loggedin As String
            Loggedin = UserSession.VZID

            Using connection As New SqlConnection(conStr)
                connection.Open()
                Dim cmdUser As New SqlCommand("select Role from Shownsharerole where Vzid='" & Loggedin & "' and Role='Moderator'", connection)
                Using reader As SqlDataReader = cmdUser.ExecuteReader()
                    If reader.HasRows Then

                    Else
                        Response.Redirect("ShownShare.aspx")
                    End If
                End Using
            End Using
        End If
    End Sub

    Protected Sub gvQuestions_RowDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuestions.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblApproved As Label = CType(e.Row.FindControl("lblApproved"), Label)
            Dim chkSelection As CheckBox = CType(e.Row.FindControl("chkSelection"), CheckBox)
            If lblApproved.Text.ToUpper() = "YES" Then
                chkSelection.Enabled = False
                e.Row.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

End Class
