Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL


Public Class AddUserCorr
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
        If Not IsPostBack Then
            LoadData()
        Else

        End If

    End Sub

    Public Sub LoadData()
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
            objmUser.Expirydate = ""
            objmUser.AuthUID = Session("User").uid
            objmUser.Password = "RasunaSaid89"
            objmUser = DataAccess.AccountAccess.InsertUpdateDeleteUserAccess(objmUser)

            If objmUser.ErrorCode.Trim = "0" Then
                btnSubmit.Text = "Update"
                btnDelete.Visible = True
                ShowMessage("Save data successfully")
            Else
                ShowErrorMessage(objmUser.ErrorDescription)
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

    Private Sub gvDataPage_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDataPage.PageIndexChanging

        'LoadData()
        gvDataPage.PageIndex = e.NewPageIndex
        LoadDataPage()

    End Sub

    Private Sub lnkHeader_Click(sender As Object, e As System.EventArgs) Handles lnkHeader.Click
        IframeCorrID.Attributes("src") = ConfigurationManager.AppSettings("root") & "/LookUp/frmLookupUserCorrespondent.aspx"
        mpLookupCorrID.Show()
    End Sub

    Private Sub btnSelectGrid_Click(sender As Object, e As System.EventArgs) Handles btnSelectGrid.Click

        Try
            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.UserAccessDataByID(hfID.Value)
            btnDelete.Visible = True
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                pnlSubmit.Visible = True
                PnlData.Visible = False
                txtUID.Text = ds.Tables(0).Rows(0).Item("uid").ToString.Trim
                txtAdminName.Text = ds.Tables(0).Rows(0).Item("admin_name").ToString.Trim
                txtCompanyName.Text = ds.Tables(0).Rows(0).Item("company_name").ToString.Trim
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim

                btnSubmit.Text = "Update"
                txtUID.Enabled = False
                txtAdminName.Enabled = False
                txtCompanyName.Enabled = False
                txtEmail.Enabled = False

                'LoadDataPage()
            Else
                ShowErrorMessage(ds.ExtendedProperties("ErrorDescription"))
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try


    End Sub

    Public Sub LoadDataPage()
        Try

            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.GetCorrespondent()
            gvDataPage.DataSource = ds.Tables(0)
            gvDataPage.DataBind()

        Catch ex As Exception

            ShowErrorMessage(ex.Message)

        End Try
    End Sub

    Private Sub btnCloseMsg_Click(sender As Object, e As System.EventArgs) Handles btnCloseMsg.Click
        rowWarning.Visible = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim objmUser As New Entities.mUser
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmUser.UID = hfID.Value

            objmUser = DataAccess.AccountAccess.InsertUpdateDeleteUserAccess(objmUser, True)

            If objmUser.ErrorCode.Trim = "0" Then
                ShowMessage("Delete data successfully")
                PnlData.Visible = True
                pnlSubmit.Visible = False
                LoadData()
            Else
                ShowErrorMessage(objmUser.ErrorDescription)
            End If

        Catch ex As Exception

            MessageError("Add Page Failed", ex.Message.ToString)

        End Try

    End Sub


End Class