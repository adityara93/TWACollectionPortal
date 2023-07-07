Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL

Public Class Index
    Inherits System.Web.UI.Page

   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not (Me.IsPostBack)) Then
            If Session("User") IsNot Nothing Then
                Me.Response.Redirect("~/Contents/Home.aspx", True)
                Me.Response.End()
            End If

            lblAlert.Text = ""
        End If
    End Sub


    Private Sub Login()


        Try
            If String.IsNullOrEmpty(Me.txtUserlogin.Text.Trim) And String.IsNullOrEmpty(Me.txtUserpassword.Text.Trim) Then
                Throw New Exception("User login or Password is empty!")
            End If

            If IsAuthenticate(Me.txtUserlogin.Text.Trim, Me.txtUserpassword.Text.Trim) Then
                'If CType(Session("User"), Entities.Account).accessid = "S01" Then
                Me.Response.Redirect("~/Contents/Home.aspx", True)
                'Else
                '    Me.Response.Redirect("~/Contents/ResendBRIVA.aspx", True)
                'End If
                Me.Response.End()
            Else
                Throw New Exception("Login Failed.")
            End If
        Catch ex As Exception
            Me.lblAlert.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function IsAuthenticate(ByVal strUserName As String, ByVal strPassword As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim objOutputModel As New WSFinance.OutputModel
            Dim oServ As FinanceService = New FinanceService
            Dim objEmployee As New WSFinance.Employee

            Dim user = DataAccess.AccountAccess.GetUserLogin(strUserName.Trim, strPassword.Trim)
            'Entities.Account
            If user.ErrorCode = "0" Then
                Me.Session("User") = user
                result = True
            Else
                Throw New Exception(user.ErrorDescription)
            End If


            'objOutputModel = CType(oServ.TPIPusatLogon(strUserName, strPassword), WSFinance.OutputModel)
            ''objOutputModel.ErrorCode = "0"



            'If objOutputModel.ErrorCode = "0" Then
            '    objEmployee = CType(objOutputModel.Result, WSFinance.Employee)
            '    'CType(Session("User"),Entities.Account).uid = strUserName.Trim.ToUpper
            '    'Me.Session("Username") = objEmployee.EmployeeName

            '    'Dim params As New Entities.Account
            '    'params.AuthUID = CType(Session("User"),Entities.Account).uid.ToString

            '    Dim user = DataAccess.AccountAccess.GetEmployeeSession(strUserName.Trim.ToUpper)
            '    'Entities.Account
            '    If user.ErrorCode = "0" Then
            '        Me.Session("User") = user
            '    Else
            '        Throw New InvalidOperationException(user.ErrorDescription)
            '    End If

            '    result = True
            'Else
            '    Throw New Exception("Login Failed. Get Error: " & objOutputModel.ErrorDescription)
            'End If
        Catch ex As Exception
            Throw
        End Try
        Return result
    End Function

    Private Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click
        Login()
        'LoginTest()
    End Sub
End Class