Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Intranet.Utilities

Partial Class ShownShare
    Inherits BasePage
    Dim conStr As String = "Data Source=INOLYP1CVVDV01;Initial Catalog=ITIM;User ID=ShownShare;Password=Sh0w&sh@re"

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If Len(txtQuestion.Text.Trim()) < 1 Then
            lblStatus.Text = "Type your question, then click Submit"
            Exit Sub
        End If
        Dim con As New SqlConnection(conStr)
        con.Open()
        Dim strQuery As String
        Dim strQuestion As String
        strQuestion = txtQuestion.Text.Trim().ToString().Replace("'", "''")
        'strQuery = "insert into tblShownShare values('" & txtName.Text.Trim() & "','" & strQuestion & "',getdate())"
        strQuery = "insert into tblShownShare(username,question,askedon) values('" & txtName.Text.Trim() & "','" & strQuestion & "',getdate())"
        Dim cmd As New SqlCommand(strQuery, con)
        cmd.ExecuteNonQuery()
        lblStatus.Text = "Your query was submitted and it will be answered."
        txtQuestion.Text = ""
        ChkAnonymous.Checked = False
        txtName.Text = UserSession.EmpName
    End Sub

    Protected Sub ChkAnonymous_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChkAnonymous.CheckedChanged
        If IsPostBack Then
            If ChkAnonymous.Checked Then
                txtName.Text = "Anonymous"
            Else
                txtName.Text = UserSession.EmpName
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim strEmpEid As String = CheckSSO()
        If Not String.IsNullOrEmpty(strEmpEid) Then
            Dim EmpEid As Int64 = Convert.ToInt64(strEmpEid)
            SetUserSession(EmpEid)
        End If
        If Not IsPostBack Then
            txtName.Text = UserSession.EmpName
            lblStatus.Text = ""
        End If
    End Sub
End Class
