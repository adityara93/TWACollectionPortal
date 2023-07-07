Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL


Public Class Addaccess
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
        If Not IsPostBack Then
            LoadData()
        Else

        End If
    End Sub

    Public Sub LoadData()
        Try

            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.GetMasterAccess()
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
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)


        End Try
    End Sub


    Public Sub LoadDataPage()
        Try

            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.PageData()
            gvDataPage.DataSource = ds.Tables(0)
            gvDataPage.DataBind()

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim objmAccess As New Entities.mAccess
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmAccess.refCode = txtRefCode.Text.ToUpper.Trim
            objmAccess.Description = txtDescription.Text.ToUpper.Trim
            objmAccess.listPageArray = hfPageID.Value

            objmAccess = DataAccess.AccountAccess.InsertUpdateDeleteAccess(objmAccess, Session("User").uid)

            If objmAccess.ErrorCode.Trim = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Save data successfully');", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + objmAccess.ErrorDescription + "');", True)
            End If


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
        End Try

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim objmAccess As New Entities.mAccess
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmAccess.refCode = txtRefCode.Text.ToUpper.Trim
            objmAccess.Description = txtDescription.Text.ToUpper.Trim
            objmAccess.listPageArray = hfPageID.Value

            objmAccess = DataAccess.AccountAccess.InsertUpdateDeleteAccess(objmAccess, Session("User").uid)

            If objmAccess.ErrorCode.Trim = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Update data successfully');", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + objmAccess.ErrorDescription + "');", True)
            End If


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
        End Try

    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Response.Redirect("~/Contents/AddAccess.aspx")
    End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        LoadData()

    End Sub


    Private Sub gvDataPage_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDataPage.PageIndexChanging
        gvDataPage.PageIndex = e.NewPageIndex
        LoadDataPage()

    End Sub

    Private Sub btnSelectGrid_Click(sender As Object, e As System.EventArgs) Handles btnSelectGrid.Click
        Try
            Dim ds As New DataSet
            ds = DataAccess.AccountAccess.GetMasterAccessByParam(hfCode.Value)
            btnAdd.Visible = False
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                pnlSubmit.Visible = True
                PnlData.Visible = False

                txtRefCode.ReadOnly = True

                txtRefCode.Text = ds.Tables(0).Rows(0).Item("code").ToString.Trim.ToUpper
                txtDescription.Text = ds.Tables(0).Rows(0).Item("description").ToString.Trim
                hfPageID.Value = ds.Tables(0).Rows(0).Item("listPageArray").ToString.Trim

                btnSubmit.Visible = False
                btnUpdate.Visible = True

                LoadDataPage()
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ds.ExtendedProperties("ErrorDescription") + "');", True)
            End If
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)

        End Try


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        PnlData.Visible = False
        pnlSubmit.Visible = True
        btnUpdate.Visible = False
    End Sub

    Private Sub btnCloseMsg_Click(sender As Object, e As System.EventArgs) Handles btnCloseMsg.Click
        rowWarning.Visible = False
    End Sub

    Protected Sub gvData_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "RemoveColl" Then
            Dim objmAccess As New Entities.mAccess
            Dim objAccountAccess As New DataAccess.AccountAccess

            objmAccess.refCode = hfRemoveID.Value
            objmAccess.Description = txtDescription.Text
            objmAccess.listPageArray = ""

            objmAccess = DataAccess.AccountAccess.InsertUpdateDeleteAccess(objmAccess, Session("User").uid, True)

            If objmAccess.ErrorCode.Trim = "0" Then
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