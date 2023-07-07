Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL


Public Class AddPage
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
            ds = DataAccess.AccountAccess.PageData()
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
            Dim objmPage As New Entities.mPage
            Dim objAccountAccess As New DataAccess.AccountAccess
            If String.IsNullOrEmpty(hfHeaderID.Value) Then
                hfHeaderID.Value = 0
            End If
            objmPage.ID = IIf(hfID.Value = "", 0, hfID.Value)
            objmPage.PageURL = txtPageURL.Text.Trim
            objmPage.PageControlID = txtPageControlID.Text.Trim
            objmPage.PageDescription = txtPageDescription.Text.Trim
            objmPage.PageHeader = txtPageHeader.Text.Trim
            objmPage.HeaderID = hfHeaderID.Value
            objmPage = DataAccess.AccountAccess.InsertUpdateDeletePage(objmPage)

            If objmPage.ErrorCode.Trim = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Save data successfully');", True)
                'ShowMessage("Save data successfully")
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + objmPage.ErrorDescription + "');", True)
                'ShowErrorMessage(objmPage.ErrorDescription)
            End If


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
            'MessageError("Add Page Failed", ex.Message.ToString)
        End Try

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            Dim objmPage As New Entities.mPage
            Dim objAccountAccess As New DataAccess.AccountAccess
            If String.IsNullOrEmpty(hfHeaderID.Value) Then
                hfHeaderID.Value = 0
            End If
            objmPage.ID = IIf(hfID.Value = "", 0, hfID.Value)
            objmPage.PageURL = txtPageURL.Text.Trim
            objmPage.PageControlID = txtPageControlID.Text.Trim
            objmPage.PageDescription = txtPageDescription.Text.Trim
            objmPage.PageHeader = txtPageHeader.Text.Trim
            objmPage.HeaderID = hfHeaderID.Value
            objmPage = DataAccess.AccountAccess.InsertUpdateDeletePage(objmPage)

            If objmPage.ErrorCode.Trim = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Update data successfully');", True)
                'ShowMessage("Save data successfully")
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + objmPage.ErrorDescription + "');", True)
                'ShowErrorMessage(objmPage.ErrorDescription)
            End If


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
            'MessageError("Add Page Failed", ex.Message.ToString)
        End Try

    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Response.Redirect("~/Contents/AddPage.aspx")
    End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        LoadData()

    End Sub

    Private Sub btnSelectGrid_Click(sender As Object, e As System.EventArgs) Handles btnSelectGrid.Click

        Try
            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.PageDataByID(hfID.Value)
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                pnlSubmit.Visible = True
                PnlData.Visible = False
                txtPageURL.Text = ds.Tables(0).Rows(0).Item("pageURL").ToString.Trim
                txtPageControlID.Text = ds.Tables(0).Rows(0).Item("PageControlID").ToString.Trim
                txtPageDescription.Text = ds.Tables(0).Rows(0).Item("PageDescription").ToString.Trim
                txtPageHeader.Text = ds.Tables(0).Rows(0).Item("PageHeader").ToString.Trim
                txtPageIcon.Text = ds.Tables(0).Rows(0).Item("PageIcon").ToString.Trim

                btnSubmit.Visible = False
                btnUpdate.Visible = True
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + ds.ExtendedProperties("ErrorDescription") + "');", True)
                'ShowErrorMessage(ds.ExtendedProperties("ErrorDescription"))
            End If
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
            'ShowErrorMessage(ex.Message)
        End Try
       

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        PnlData.Visible = False
        pnlSubmit.Visible = True
        btnAdd.Visible = False
        btnUpdate.Visible = False

    End Sub

    Private Sub btnCloseMsg_Click(sender As Object, e As System.EventArgs) Handles btnCloseMsg.Click
        rowWarning.Visible = False
    End Sub



    Private Sub lnkHeader_Click(sender As Object, e As System.EventArgs) Handles lnkHeader.Click
        IframeCorrID.Attributes("src") = ConfigurationManager.AppSettings("root") & "/LookUp/frmLookupPageHeader.aspx"
        mpLookupCorrID.Show()
    End Sub

    Private Sub btnSelectHeaderID_Click(sender As Object, e As System.EventArgs) Handles btnSelectHeaderID.Click
        Try
            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.PageDataByID(hfHeaderID.Value)
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                txtPageHeader.Text = ds.Tables(0).Rows(0).Item("PageControlID").ToString.Trim
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + ds.ExtendedProperties("ErrorDescription") + "');", True)
                'ShowErrorMessage(ds.ExtendedProperties("ErrorDescription"))
            End If
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + ex.Message + "');", True)
            'ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Protected Sub gvData_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "RemoveColl" Then
            Dim objmPage As New Entities.mPage
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmPage.ID = hfRemoveID.Value
            objmPage.PageURL = ""
            objmPage.PageControlID = ""
            objmPage.PageDescription = ""
            objmPage.PageHeader = ""
            objmPage.HeaderID = 0
            objmPage = DataAccess.AccountAccess.InsertUpdateDeletePage(objmPage, True)

            If objmPage.ErrorCode.Trim = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Delete data successfully.');", True)
                PnlData.Visible = True
                pnlSubmit.Visible = False
                LoadData()
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','Please try again.');", True)
            End If
        End If
    End Sub

End Class