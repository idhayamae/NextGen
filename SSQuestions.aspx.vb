Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Intranet.Utilities

Partial Class SSQuestions
    Inherits BasePage
    Dim constr = "Data Source=INOLYP1CVVDV01;Initial Catalog=ITIM;User ID=ShownShare;Password=Sh0w&sh@re"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim strEmpEid As String = CheckSSO()
        If Not String.IsNullOrEmpty(strEmpEid) Then
            Dim EmpEid As Int64 = Convert.ToInt64(strEmpEid)
            SetUserSession(EmpEid)
        End If

        If Not IsPostBack Then
            'Dim Loggedin As String
            'Loggedin = UserSession.VZID
            ''Loggedin = "V718927"
            'Using connection As New SqlConnection(constr)
            '    connection.Open()
            '    Dim cmdUser As New SqlCommand("select Role from Shownsharerole where Vzid='" & Loggedin & "' and Role='Viewer'", connection)
            '    Using reader As SqlDataReader = cmdUser.ExecuteReader()
            '        If reader.HasRows Then

            '        Else
            '            Response.Redirect("ShownShare.aspx")
            '        End If
            '    End Using
            'End Using
        End If
    End Sub
End Class