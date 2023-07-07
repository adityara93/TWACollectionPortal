Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL


Public Class ChangePassword
    Inherits System.Web.UI.Page


    Private Sub MessageError(ByVal title As String, ByVal message As String)
        Dim func As String = String.Format("MessageError(""{0}"",""{1}"");", title, message)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CallAlertMessage", func, True)
    End Sub

    Private Sub MessageInfo(ByVal title As String, ByVal message As String)
        Dim func As String = String.Format("MessageInfo(""{0}"",""{1}"");", title, message)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CallAlertMessage", func, True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If String.IsNullOrEmpty(Me.txtNew.Text.Trim) Or String.IsNullOrEmpty(Me.txtConfirm.Text.Trim) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','Field cannot be empty!.');", True)
                'Throw New Exception("Field cannot be empty!")
            End If

            If Me.txtNew.Text <> Me.txtConfirm.Text Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','Password do not match!.');", True)
            End If
            Dim uid As String = CType(Session("User"), Entities.Account).uid.ToString

            Try
                Dim user = DataAccess.AccountAccess.ChangePassword(uid, Me.txtNew.Text.Trim())

                Try
                    Me.Session.Clear()
                    Me.Response.Redirect("~/Index.aspx")
                    Me.Response.End()
                Catch ex As Exception
                    Me.Response.Redirect("~/Index.aspx", True)
                    Me.Response.End()
                End Try
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Success','Success Change Password.');", True)
                'MessageInfo("Change Password", "Success Change Password")
            Catch ex As Exception
                Throw
            End Try
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Info'," + ex.Message.ToString + ".');", True)
            'MessageError("Change Password Failed", ex.Message.ToString)

        End Try
    End Sub

    Private Function IsAuthenticate(ByVal strUserName As String, ByVal strPassword As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim objOutputModel As New WSFinance.OutputModel
            Dim oServ As FinanceService = New FinanceService
            Dim objEmployee As New WSFinance.Employee

            Dim user = DataAccess.AccountAccess.ChangePassword(strUserName.Trim, strPassword.Trim)
            'Entities.Account
            If user.ErrorCode = "0" Then
                Me.Session("User") = user
                result = True
                Me.txtNew.Text = ""
                Me.txtConfirm.Text = ""
                MessageInfo("Change Password", "Success Change Password")

            Else
                Throw New Exception(user.ErrorDescription)
            End If
        Catch ex As Exception
            Throw
        End Try
        Return result
    End Function


End Class