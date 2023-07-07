Imports CollectionPortalDAL
Public Class NewSite
    Inherits System.Web.UI.MasterPage
    Public Property theMenu As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User") IsNot Nothing Then

            Dim currentPageName As String = Request.Url.Segments((Request.Url.Segments.Length - 1)).ToLower.Trim
            Dim ds As New DataSet
            Dim dsDetail As New DataSet

            Me.lblUname.Text = CType(Session("User"), Entities.Account).admin_name
            Me.lblUType.Text = CType(Session("User"), Entities.Account).utype_desc

            Dim background = "background:#8080804f"
            Dim HtmlGenericControl As New HtmlGenericControl

            ds = DataAccess.AccountAccess.PageAccess(CType(Session("User"), Entities.Account).email)

            If ds.ExtendedProperties("ErrorCode").ToString().Trim = "0" And ds.Tables(0).Rows.Count > 0 Then

                
                
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                    Try
                        Dim LINavItemTreeviewMenu1 As String = "<li runat=""server"" id=""{menu}"" visible=""false"" class=""nav-item has-treeview"">"
                        Dim LINavItemTreeviewMenu2 As String = "</li>"

                        Dim ANavLinkTreeview As String = "<a href=""#"" class=""nav-link""><i class=""nav-icon fas {icon}""></i><p>{menu_description}<i class=""fas fa-angle-left right""></i></p></a>"

                        Dim LINavTreeview1 As String = "<ul class=""nav nav-treeview"">"
                        Dim LINavTreeview2 As String = "</ul>"


                        'Cek Akses Detail
                        Dim headerMenuId = ds.Tables(0).Rows(i).Item("pagecontrolid").ToString.Trim
                        Dim headerMenuDesc = ds.Tables(0).Rows(i).Item("pagedescription").ToString.Trim
                        Dim headerMenuIcon = ds.Tables(0).Rows(i).Item("pageicon").ToString.Trim

                        LINavItemTreeviewMenu1 = LINavItemTreeviewMenu1.Replace("{menu}", headerMenuId)
                        ANavLinkTreeview = ANavLinkTreeview.Replace("{icon}", headerMenuIcon)
                        ANavLinkTreeview = ANavLinkTreeview.Replace("{menu_description}", headerMenuDesc)

                        dsDetail = DataAccess.AccountAccess.PageAccessDetail(CType(Session("User"), Entities.Account).email, headerMenuId)
                        Dim detailMenu As String = ""

                        If dsDetail.ExtendedProperties("ErrorCode").ToString().Trim = "0" And dsDetail.Tables(0).Rows.Count > 0 Then
                            For j As Integer = 0 To dsDetail.Tables(0).Rows.Count - 1
                                Dim LINavItemMenu1 As String = "<li class=""nav-item"" id=""{menu}"" visible=""false"" runat=""server"">"
                                Dim LINavItemMenu2 As String = "</li>"

                                Dim ANavLinkMenu As String = "<a href=""{page}"" class=""nav-link""><i class=""far fa-circle nav-icon""></i><p>{detail_description}</p></a>"


                                Dim detailMenuId = dsDetail.Tables(0).Rows(j).Item("pagecontrolid").ToString.Trim
                                Dim detailMenuDesc = dsDetail.Tables(0).Rows(j).Item("pagedescription").ToString.Trim
                                Dim detailMenuURL = dsDetail.Tables(0).Rows(j).Item("pageurl").ToString.Trim

                                'Replace string
                                LINavItemMenu1 = LINavItemMenu1.Replace("{menu}", detailMenuId)
                                ANavLinkMenu = ANavLinkMenu.Replace("{page}", detailMenuURL)
                                ANavLinkMenu = ANavLinkMenu.Replace("{detail_description}", detailMenuDesc)

                                detailMenu = detailMenu + LINavItemMenu1 + ANavLinkMenu + LINavItemMenu2

                            Next

                            theMenu = theMenu + LINavItemTreeviewMenu1 + ANavLinkTreeview + LINavTreeview1 + detailMenu + LINavTreeview2 + LINavItemTreeviewMenu2

                        Else

                        End If

                        'Me.FindControl(ds.Tables(0).Rows(i).Item("PageControlID").ToString.Trim).Visible = True

                        'HtmlGenericControl.ID = ds.Tables(0).Rows(i).Item("PageControlID").ToString.Trim

                        'Try
                        '    HtmlGenericControl.Attributes.Remove("style")
                        'Catch ex As Exception

                        'End Try

                        'If currentPageName.ToLower.Trim = ds.Tables(0).Rows(i).Item("pageURL").ToString.ToLower.Trim Then
                        '    HtmlGenericControl.Attributes.Add("style", background)
                        '    HtmlGenericControl.ID = ds.Tables(0).Rows(i).Item("PageControlHeaderID").ToString.Trim
                        '    Try
                        '        HtmlGenericControl.Attributes.Remove("class")
                        '    Catch ex As Exception

                        '    End Try
                        '    HtmlGenericControl.Attributes.Add("class", "nav-item has-treeview menu-open")
                        'End If


                    Catch ex As Exception

                    End Try

                Next

                'If ds.Tables(0).Rows(0).Item("CanAccess").ToString = "0" And currentPageName.ToLower.Trim <> "home.aspx" Then
                '    Response.Redirect("~/Contents/AccessDenied.aspx")
                'End If

            End If

            'If CType(Session("User"), Entities.Account).isadmin = True Then

            '    mnuAddUser.Visible = True
            '    mnuChangePwd.Visible = True
            '    mnuUserManagement.Visible = True
            '    mnuResendBRIVA.Visible = True
            '    mnuGenerateVirtualAccount.Visible = True
            '    mnuPaymentList.Visible = True
            '    mnuSettlementMonitoring.Visible = True
            '    mnuBRI.Visible = True
            '    mnuMandiri.Visible = True
            '    mnuPayment.Visible = True
            '    mnuUserManagement.Visible = True
            '    mnuAddPage.Visible = True
            '    mnuAddAccess.Visible = True
            '    mnuReportMandiri.Visible = True
            '    mnuReportMandiriVAClient.Visible = True
            '    'mnuBCA.Visible = True
            '    'mnuBNI.Visible = True
            'Else
            '    mnuChangePwd.Visible = True
            '    mnuUserManagement.Visible = True
            'End If


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