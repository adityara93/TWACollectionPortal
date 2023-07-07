Imports CollectionPortalDAL
Public Class NewSite
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User") IsNot Nothing Then

            Dim currentPageName As String = Request.Url.Segments((Request.Url.Segments.Length - 1)).ToLower.Trim
            Dim ds As New DataSet

            Me.lblUname.Text = CType(Session("User"), Entities.Account).admin_name
            Me.lblUType.Text = CType(Session("User"), Entities.Account).utype_desc

            Dim background = "background:#8080804f"
            Dim HtmlGenericControl As New HtmlGenericControl

            ds = DataAccess.AccountAccess.PageAccess(CType(Session("User"), Entities.Account).email)

            If ds.ExtendedProperties("ErrorCode").ToString().Trim = "0" And ds.Tables(0).Rows.Count > 0 Then


                


                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                    Try
                        Me.FindControl(ds.Tables(0).Rows(i).Item("PageControlID").ToString.Trim).Visible = True

                        HtmlGenericControl.ID = ds.Tables(0).Rows(i).Item("PageControlID").ToString.Trim

                        Try
                            HtmlGenericControl.Attributes.Remove("style")
                        Catch ex As Exception

                        End Try

                        If currentPageName.ToLower.Trim = ds.Tables(0).Rows(i).Item("pageURL").ToString.ToLower.Trim Then
                            HtmlGenericControl.Attributes.Add("style", background)
                            HtmlGenericControl.ID = ds.Tables(0).Rows(i).Item("PageControlHeaderID").ToString.Trim
                            Try
                                HtmlGenericControl.Attributes.Remove("class")
                            Catch ex As Exception

                            End Try
                            HtmlGenericControl.Attributes.Add("class", "nav-item has-treeview menu-open")
                        End If


                    Catch ex As Exception

                    End Try

                Next

                If ds.Tables(0).Rows(0).Item("CanAccess").ToString = "0" And currentPageName.ToLower.Trim <> "home.aspx" Then
                    Response.Redirect("~/Contents/AccessDenied.aspx")
                End If
             
            End If

            If CType(Session("User"), Entities.Account).isadmin = True Then

                mnuAddUser.Visible = True
                mnuChangePwd.Visible = True
                mnuUserManagement.Visible = True
                mnuResendBRIVA.Visible = True
                mnuGenerateVirtualAccount.Visible = True
                mnuPaymentList.Visible = True
                mnuSettlementMonitoring.Visible = True
                mnuBRI.Visible = True
                mnuMandiri.Visible = True
                mnuPayment.Visible = True
                mnuUserManagement.Visible = True
                mnuAddPage.Visible = True
                mnuAddAccess.Visible = True
                mnuReportMandiri.Visible = True
                mnuReportMandiriVAClient.Visible = True
                'mnuBCA.Visible = True
                'mnuBNI.Visible = True
            Else
                mnuChangePwd.Visible = True
                mnuUserManagement.Visible = True
            End If


        Else

            LogOut()

        End If
    End Sub

    Protected Sub LogOut()
        Try
            Me.Session.Clear()
            Me.Response.Redirect("~/Index.aspx")
            Me.Response.End()
        Catch ex As Exception
            Me.Response.Redirect("~/Index.aspx", True)
            Me.Response.End()
        End Try
        
    End Sub
End Class