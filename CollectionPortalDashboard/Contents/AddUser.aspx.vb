Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL


Public Class AddUser
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

        rowWarning.Visible = False
        BindDataddlUserAccess()
        BindDataddlUserType()
        If Not IsPostBack Then
            LoadData()
        Else

        End If

    End Sub

    Private Sub LoadPageData(ByVal uid As String)
        Try

            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.PageDataUserCorrespondent(uid)
            gvDataPage.DataSource = ds.Tables(0)
            gvDataPage.DataBind()

            gvDataPage.UseAccessibleHeader = True
            gvDataPage.HeaderRow.TableSection = TableRowSection.TableHeader

            If gvDataPage.TopPagerRow IsNot Nothing Then
                gvDataPage.TopPagerRow.TableSection = TableRowSection.TableHeader
            End If

            If gvDataPage.BottomPagerRow IsNot Nothing Then
                gvDataPage.BottomPagerRow.TableSection = TableRowSection.TableFooter
            End If

        Catch ex As Exception

            ShowErrorMessage(ex.Message)

        End Try
    End Sub

    Private Sub LoadData()
        Try

            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.UserAccessData()
            gvData.DataSource = ds.Tables(0)
            gvData.DataBind()

            gvData.UseAccessibleHeader = True
            gvData.HeaderRow.TableSection = TableRowSection.TableHeader

            If gvData.TopPagerRow IsNot Nothing Then
                gvData.TopPagerRow.TableSection = TableRowSection.TableHeader
            End If

            If gvData.BottomPagerRow IsNot Nothing Then
                gvData.BottomPagerRow.TableSection = TableRowSection.TableFooter
            End If

        Catch ex As Exception

            ShowErrorMessage(ex.Message)

        End Try
    End Sub

    Public Sub ShowMessage(ByVal message As String)
        lblWarning.Text = message
        lblWarning.ForeColor = Drawing.Color.Green
        rowWarning.Visible = True
    End Sub

    Public Sub ShowErrorMessage(ByVal message As String)
        lblWarning.Text = message
        lblWarning.ForeColor = Drawing.Color.Red
        rowWarning.Visible = True
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try
            Dim objmUser As New Entities.mUser
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmUser.UID = txtUID.Text
            objmUser.AdminName = txtAdminName.Text
            objmUser.CompanyName = txtCompanyName.Text
            objmUser.Email = txtEmail.Text
            objmUser.Address = txtAddess.Text
            objmUser.Phone = txtPhone.Text
            objmUser.UType = ddlUserType.SelectedValue.ToString()
            objmUser.UAccess = ddlUserAccess.SelectedValue.ToString()
            objmUser.Expirydate = ""
            objmUser.AuthUID = Session("User").uid
            objmUser.Password = "RasunaSaid89"
            objmUser = DataAccess.AccountAccess.InsertUpdateDeleteUserAccess(objmUser)

            If objmUser.ErrorCode.Trim = "0" Then
                btnSubmit.Visible = False
                btnUpdate.Visible = True
                dvAddCorr.Visible = True
                LoadPageData("")
                'btnDelete.Visible = True
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','Save data successfully, Please set your Correspondent.');", True)
                'ShowMessage("Save data successfully")
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + objmUser.ErrorDescription + ".');", True)
                'ShowErrorMessage(objmUser.ErrorDescription)
            End If


        Catch ex As Exception

            ShowErrorMessage(ex.Message)

        End Try

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            Dim objmUser As New Entities.mUser
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmUser.UID = txtUID.Text
            objmUser.AdminName = txtAdminName.Text
            objmUser.CompanyName = txtCompanyName.Text
            objmUser.Email = txtEmail.Text
            objmUser.Address = txtAddess.Text
            objmUser.Phone = txtPhone.Text
            objmUser.UType = ddlUserType.SelectedValue.ToString()
            objmUser.UAccess = ddlUserAccess.SelectedValue.ToString()
            objmUser.Expirydate = ""
            objmUser.AuthUID = Session("User").uid
            objmUser.Password = "RasunaSaid89"
            objmUser = DataAccess.AccountAccess.InsertUpdateDeleteUserAccess(objmUser)

            If objmUser.ErrorCode.Trim = "0" Then
                btnSubmit.Visible = False
                btnUpdate.Visible = True
                dvAddCorr.Visible = True
                LoadPageData("")
                'btnDelete.Visible = True
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Save data successfully.');", True)
                'ShowMessage("Save data successfully")
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + objmUser.ErrorDescription + ".');", True)
                'ShowErrorMessage(objmUser.ErrorDescription)
            End If


        Catch ex As Exception

            ShowErrorMessage(ex.Message)

        End Try

    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Response.Redirect("~/Contents/AddUser.aspx")
    End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging

        'LoadData()
        gvData.PageIndex = e.NewPageIndex
        LoadData()

    End Sub

    Private Sub btnSelectGrid_Click(sender As Object, e As System.EventArgs) Handles btnSelectGrid.Click

        Try
            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.UserAccessDataByID(hfID.Value)
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                pnlSubmit.Visible = True
                PnlData.Visible = False
                txtUID.Text = ds.Tables(0).Rows(0).Item("uid").ToString.Trim
                txtAdminName.Text = ds.Tables(0).Rows(0).Item("admin_name").ToString.Trim
                txtCompanyName.Text = ds.Tables(0).Rows(0).Item("company_name").ToString.Trim
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
                txtAddess.Text = ds.Tables(0).Rows(0).Item("address_1").ToString.Trim
                txtPhone.Text = ds.Tables(0).Rows(0).Item("Phone_nbr").ToString.Trim
                ddlUserAccess.SelectedValue = ds.Tables(0).Rows(0).Item("uaccess").ToString.Trim
                ddlUserType.SelectedValue = ds.Tables(0).Rows(0).Item("utype").ToString.Trim

                btnSubmit.Visible = False
                btnAdd.Visible = False

                LoadPageData(hfID.Value)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + ds.ExtendedProperties("ErrorDescription") + ".');", True)
                'ShowErrorMessage(ds.ExtendedProperties("ErrorDescription"))
            End If
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message + ".');", True)
            'ShowErrorMessage(ex.Message)
        End Try


    End Sub

    Private Sub btnSelectHeaderID_Click(sender As Object, e As System.EventArgs) Handles btnSelectHeaderID.Click
        Try
            Dim result As New Entities.mUser
            result = DataAccess.AccountAccess.PageDataInsertUserCorrespondent(txtUID.Text, hfHeaderID.Value)
            If result.ErrorCode = "0" Then
                Dim user_id As String = result.user_id
                LoadPageData(user_id)
            Else
                ShowErrorMessage(result.ErrorDescription)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        PnlData.Visible = False
        pnlSubmit.Visible = True
        btnAdd.Visible = False
        btnUpdate.Visible = False

        dvAddCorr.Visible = False
    End Sub

    Private Sub BindDataddlUserType()
        Try
            Dim ds As DataSet
            ds = DataAccess.LookupAccess.LookupUserType()
            Dim val = ddlUserType.SelectedValue
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ddlUserType.DataSource = ds.Tables(0)
                    ddlUserType.DataValueField = "ref_code"
                    ddlUserType.DataTextField = "description"
                    ddlUserType.DataBind()
                    ddlUserType.SelectedIndex = 0
                End If
            Else
                Throw New InvalidOperationException(ds.ExtendedProperties("ErrorDescription"))
            End If
            ddlUserType.SelectedValue = val
        Catch ex As Exception
            ddlUserType.SelectedValue = ""
        End Try
    End Sub

    Private Sub BindDataddlUserAccess()
        Try
            Dim ds As DataSet
            ds = DataAccess.LookupAccess.LookupUserAccess()
            Dim val = ddlUserAccess.SelectedValue
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ddlUserAccess.DataSource = ds.Tables(0)
                    ddlUserAccess.DataValueField = "ref_code"
                    ddlUserAccess.DataTextField = "description"
                    ddlUserAccess.DataBind()
                    ddlUserAccess.SelectedIndex = 0
                End If
            Else
                Throw New InvalidOperationException(ds.ExtendedProperties("ErrorDescription"))
            End If
            ddlUserAccess.SelectedValue = val
        Catch ex As Exception
            ddlUserAccess.SelectedValue = ""
        End Try
    End Sub

    Private Sub btnCloseMsg_Click(sender As Object, e As System.EventArgs) Handles btnCloseMsg.Click
        rowWarning.Visible = False
    End Sub

    Protected Sub gvData_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "RemoveColl" Then
            Dim objmUser As New Entities.mUser
            Dim code As String = hfRemoveID.Value
            objmUser.UID = hfID.Value
            objmUser.AdminName = ""
            objmUser.CompanyName = ""
            objmUser.Address = ""
            objmUser.Phone = ""
            objmUser.UType = ""
            objmUser.UAccess = ""
            objmUser.Email = hfRemoveID.Value
            objmUser.AuthUID = ""
            objmUser.Password = ""

            objmUser = DataAccess.AccountAccess.InsertUpdateDeleteUserAccess(objmUser, True)

            If objmUser.ErrorCode.Trim = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Delete data successfully.');", True)
                PnlData.Visible = True
                pnlSubmit.Visible = False
                LoadData()
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','Please try again.');", True)
            End If
        End If
    End Sub

    Protected Sub gvDataPage_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "RemoveColl2" Then
            Dim objmUser As New Entities.mUser
            Dim code As String = hfRemoveID.Value
            objmUser.UID = hfID.Value
            objmUser.AdminName = ""
            objmUser.CompanyName = ""
            objmUser.Address = ""
            objmUser.Phone = ""
            objmUser.UType = ""
            objmUser.UAccess = ""
            objmUser.Email = hfRemoveID.Value
            objmUser.AuthUID = ""
            objmUser.Password = ""

            objmUser = DataAccess.AccountAccess.PageDataDeleteUserCorrespondent(txtUID.Text, hfRemoveID.Value)

            If objmUser.ErrorCode.Trim = "0" Then
                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Delete data successfully.');", True)
                LoadPageData(hfID.Value)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','Please try again.');", True)
            End If
        End If
    End Sub

    Private Sub lnkLookupCorr_Click(sender As Object, e As System.EventArgs) Handles lnkLookupCorr.Click
        IframeCorrID.Attributes("src") = ConfigurationManager.AppSettings("root") & "/LookUp/frmLookupCorrID.aspx"
        mpLookupCorrID.Show()
    End Sub

    'Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
    '    Try
    '        Dim objmUser As New Entities.mUser
    '        Dim objAccountAccess As New DataAccess.AccountAccess

    '        objmUser.UID = hfID.Value

    '        objmUser = DataAccess.AccountAccess.InsertUpdateDeleteUserAccess(objmUser, True)

    '        If objmUser.ErrorCode.Trim = "0" Then
    '            ShowMessage("Delete data successfully")
    '            PnlData.Visible = True
    '            pnlSubmit.Visible = False
    '            LoadData()
    '        Else
    '            ShowErrorMessage(objmUser.ErrorDescription)
    '        End If

    '    Catch ex As Exception

    '        MessageError("Add Page Failed", ex.Message.ToString)

    '    End Try

    'End Sub
End Class