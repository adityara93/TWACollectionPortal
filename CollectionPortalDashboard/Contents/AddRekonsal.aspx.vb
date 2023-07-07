Imports CollectionPortalDashboard.WSFinance
Imports CollectionPortalDAL
Imports CollectionPortalDAL.Entities
Imports CollectionPortalDAL.DataAccess


Public Class AddRekonsal
    Inherits System.Web.UI.Page


    Private Sub MessageError(ByVal title As String, ByVal message As String)
        Dim func As String = String.Format("MessageError(""{0}"",""{1}"");", title, message)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CallAlertMessage", func, True)
    End Sub

    Private Sub MessageInfo(ByVal title As String, ByVal message As String)
        Dim func As String = String.Format("MessageInfo(""{0}"",""{1}"");", title, message)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CallAlertMessage", func, True)
    End Sub

    Private btnAddCorrClicked As Boolean = False
    Private initGridView As Boolean = True

    Private Sub BindDataddlUmurPiutang()
        Try
            Dim ds As DataSet
            ds = DataAccess.LookupAccess.LookupUmurPiutang()
            Dim val = ddlUmurPiutang.SelectedValue
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ddlUmurPiutang.DataSource = ds.Tables(0)
                    ddlUmurPiutang.DataValueField = "ref_code"
                    ddlUmurPiutang.DataTextField = "description"
                    ddlUmurPiutang.DataBind()
                    ddlUmurPiutang.SelectedIndex = 0
                End If
            Else
                Throw New InvalidOperationException(ds.ExtendedProperties("ErrorDescription"))
            End If
            ddlUmurPiutang.SelectedValue = val
        Catch ex As Exception
            ddlUmurPiutang.SelectedValue = ""
        End Try
    End Sub

    Private Sub BindDataddlStatusCollection()
        Try
            Dim ds As DataSet
            ds = DataAccess.LookupAccess.LookupStatusCollection()
            Dim val = ddlStatus.SelectedValue
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ddlStatus.DataSource = ds.Tables(0)
                    ddlStatus.DataValueField = "ref_code"
                    ddlStatus.DataTextField = "description"
                    ddlStatus.DataBind()
                    ddlStatus.SelectedIndex = 0
                End If
            Else
                Throw New InvalidOperationException(ds.ExtendedProperties("ErrorDescription"))
            End If
            ddlStatus.SelectedValue = val
        Catch ex As Exception
            ddlStatus.SelectedValue = ""
        End Try
    End Sub

    Private Sub AccessForm()
        Dim AccFormUserName As String = Session("User").admin_name
        Dim AccFormUID As String = Session("User").uid
        Dim AccForm As String = Session("User").uaccess
        txtUIDCollector.Text = AccFormUID + " - " + AccFormUserName
        'ADMINISTRATOR
        'INPUT
        If AccForm = "ACC" Then
            btnAdd.Visible = False
            dvVANumber.Visible = False
            btnUpdate.Visible = True
        ElseIf AccForm = "RVW" Then
            btnAdd.Visible = False
            dvVANumber.Visible = False
            btnAccept.Visible = False
            btnUpdate.Visible = False
            btnSearchColl.Visible = False
        End If


        'VIEWER - Atasan dari INPUT
        'ACCEPT
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccessForm()
        rowWarning.Visible = False
        BindDataddlUmurPiutang()
        BindDataddlStatusCollection()
        If Not IsPostBack Then
            LoadData()
        Else
            LoadDataPage()
        End If

    End Sub

    Public Sub LoadData()
        Try

            Dim ds As New DataSet
            Dim ID As String = Session("User").uid
            Dim Access As String = Session("User").uaccess
            ds = DataAccess.AccountAccess.GetDataCollectionRekonsalByParam(ID, Access)
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
            ID = ex.Message
        End Try
    End Sub


    Public Sub LoadDataPage()
        Try
            Dim objmCollection As New mCollection
            Dim ID As String = Session("User").user_id

            If hfCorrID.Value = "" Then
                txtTotalAmountIDR.Text = "0.00"
                objmCollection.correspondentID = ""
                objmCollection.dueDate = "1900-01-01 00:00:00.000"
                objmCollection.uPiutang = ""

                ViewState("gridDetailOri") = AccountAccess.GetDataInsByParam(objmCollection).Tables(0)
                gvDataPage.DataSource = ViewState("gridDetailOri")
            ElseIf gvDataPage.Rows.Count = 0 Then
                gvDataPage.DataSource = ViewState("gridDetailOri")
            Else
                gvDataPage.DataSource = ViewState("gridDetailRev")
            End If
            gvDataPage.DataBind()

        Catch ex As Exception
            'ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSearchColl_Click(sender As Object, e As System.EventArgs) Handles btnSearchColl.Click

        Dim objmCollection As New mCollection
        Dim ID As String = Session("User").user_id
        objmCollection.correspondentID = hfCorrID.Value
        objmCollection.dueDate = txtDueDate.Text.Trim
        objmCollection.uPiutang = ddlUmurPiutang.SelectedValue

        Dim ds As New DataSet
        ds = AccountAccess.GetDataInsByParam(objmCollection)
        gvDataPage.DataSource = ds.Tables(0)
        gvDataPage.DataBind()

        Dim totalFinal As Decimal
        If gvDataPage.Rows.Count > 0 Then
            For Each row As GridViewRow In gvDataPage.Rows
                Dim totalTagihan As Decimal = Convert.ToDecimal(row.Cells(11).Text)
                totalFinal = totalFinal + totalTagihan
            Next
        End If
        txtTotalAmountIDR.Text = totalFinal.ToString("#,##0.00")

        ViewState("gridDetailOri") = ds.Tables(0)
        ViewState("gridDetailRev") = ds.Tables(0)

    End Sub

    Private Sub btnRollbackColl_Click(sender As Object, e As System.EventArgs) Handles btnRollbackColl.Click
        gvDataPage.DataSource = ViewState("gridDetailOri")
        gvDataPage.DataBind()

        Dim totalFinal As Decimal
        If gvDataPage.Rows.Count > 0 Then
            For Each row As GridViewRow In gvDataPage.Rows
                Dim totalTagihan As Decimal = Convert.ToDecimal(row.Cells(10).Text)
                totalFinal = totalFinal + totalTagihan
            Next
        End If
        txtTotalAmountIDR.Text = totalFinal.ToString("#,##0.00")

        ViewState("gridDetailRev") = ViewState("gridDetailOri")

    End Sub

    Protected Sub gvDataPage_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "RemoveColl" Then
            Dim code As String = hfRemoveID.Value
            Dim dt As New DataTable
            dt = ViewState("gridDetailRev")

            'check index by name code
            Dim targetName As String = code ' The name you want to search for
            Dim rowIndex As Integer = -1 ' Variable to store the index of the row

            For Each row As GridViewRow In gvDataPage.Rows
                Dim nameCell As TableCell = row.Cells(0) ' Assuming "Name" column is the first column

                ' Assuming the name is stored as a Text value in the cell
                If nameCell.Text = targetName Then
                    rowIndex = row.RowIndex
                    Exit For ' Exit the loop if the name is found
                End If
            Next

            If rowIndex <> -1 Then
                ' The row with the target name was found
                Dim targetRow As GridViewRow = gvDataPage.Rows(rowIndex)

                ' Now you can access the row's data and perform further operations
                ' For example, you can access specific cells using the Cells collection:
                Dim cellValue As String = targetRow.Cells(1).Text ' Assuming the desired column index is 1
                ' Do something with the cell value

                dt.Rows.RemoveAt(rowIndex)
                ViewState("gridDetailRev") = dt
                gvDataPage.DataSource = dt
                gvDataPage.DataBind()

                Dim totalFinal As Decimal
                If gvDataPage.Rows.Count > 0 Then
                    For Each row As GridViewRow In gvDataPage.Rows
                        Dim totalTagihan As Decimal = Convert.ToDecimal(row.Cells(10).Text)
                        totalFinal = totalFinal + totalTagihan
                    Next
                End If
                txtTotalAmountIDR.Text = totalFinal.ToString("#,##0.00")

            Else
                ' The row with the target name was not found
                ' Handle the case where the name is not found in the GridView
            End If



        End If
    End Sub

    Private Sub lnkLookupCorr_Click(sender As Object, e As System.EventArgs) Handles lnkLookupCorr.Click
        IframeCorrID.Attributes("src") = ConfigurationManager.AppSettings("root") & "/LookUp/frmLookupUserCorrespondent.aspx"
        mpLookupCorrID.Show()
    End Sub

    Private Sub btnSelectHeaderID_Click(sender As Object, e As System.EventArgs) Handles btnSelectHeaderID.Click
        Try
            Dim ds As New DataSet
            Dim uid As String = Session("User").user_id
            Dim objMUser As New Entities.mUser()
            objMUser.ClientID = hfCode.Value
            ds = DataAccess.AccountAccess.PageDataUserCorrespondentByID(uid, objMUser)
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                Dim nCorr As String = ""
                Dim nCorrTitle As String = ""
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    Dim lastChar As Integer = nCorrTitle.Length

                    Dim nameCorr As String = ds.Tables(0).Rows(i).Item("client_id").ToString.Trim()
                    Dim nameCorrDetail As String = ds.Tables(0).Rows(i).Item("client_id").ToString.Trim() + " - " + ds.Tables(0).Rows(i).Item("name").ToString.Trim()

                    nCorr += nameCorr
                    nCorrTitle += nameCorrDetail

                Next

                hfCorrID.Value = nCorr
                lblNameCorr.Text = nCorrTitle

            Else
                'ShowErrorMessage(ds.ExtendedProperties("ErrorDescription"))
            End If
        Catch ex As Exception
            'ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            'Get Collection Number
            Dim objmColHeader As New Entities.mCollection
            Dim objAccountAccess As New DataAccess.AccountAccess
            Dim listCodeId As New List(Of String)
            Dim listCodeDocNbrId As New List(Of String)
            'Insert To Master Collection
            objmColHeader.collectionNbr = txtColNumber.Text
            objmColHeader.correspondentID = hfCorrID.Value
            objmColHeader.dueDate = txtDueDate.Text
            objmColHeader.uPiutang = ddlUmurPiutang.SelectedValue
            objmColHeader.totalAmount = txtTotalAmountIDR.Text
            objmColHeader.uid = Session("User").uid
            objmColHeader.colStatus = ddlStatus.SelectedValue
            objmColHeader = DataAccess.AccountAccess.InsertUpdateDeleteUserCollection(objmColHeader)

            If objmColHeader.ErrorCode.Trim = "0" Then
                hfCollNbr.Value = objmColHeader.collectionNbr
                txtColNumber.Text = hfCollNbr.Value
                'Looping for get CodeId by GV to CollectionDetail
                For Each row As GridViewRow In gvDataPage.Rows
                    listCodeId.Add(row.Cells(0).Text)
                    listCodeDocNbrId.Add(row.Cells(1).Text)
                Next

                Dim objmColDetail As New Entities.mCollection
                objmColDetail.collectionNbr = hfCollNbr.Value
                objmColDetail.lCodeId = String.Join(",", listCodeId)
                objmColDetail.docNbr = String.Join(",", listCodeDocNbrId)
                objmColDetail = DataAccess.AccountAccess.InsertUpdateDeleteUserCollectionDetail(objmColDetail)
                If objmColDetail.ErrorCode.Trim = "0" Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Save Data Successfully.');", True)
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + objmColHeader.ErrorDescription + "');", True)
                'MsgBox(objmColHeader.ErrorDescription)
            End If

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
            'MessageError("Add Page Failed", ex.Message.ToString)
        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            'Get Collection Number
            Dim objmColHeader As New Entities.mCollection
            Dim objAccountAccess As New DataAccess.AccountAccess
            Dim listCodeId As New List(Of String)
            Dim listCodeDocNbrId As New List(Of String)
            'Insert To Master Collection
            objmColHeader.collectionNbr = txtColNumber.Text
            objmColHeader.correspondentID = hfCorrID.Value
            objmColHeader.dueDate = txtDueDate.Text
            objmColHeader.uPiutang = ddlUmurPiutang.SelectedValue
            objmColHeader.totalAmount = txtTotalAmountIDR.Text
            objmColHeader.uid = Session("User").uid
            objmColHeader.colStatus = ddlStatus.SelectedValue
            objmColHeader = DataAccess.AccountAccess.InsertUpdateDeleteUserCollection(objmColHeader)

            If objmColHeader.ErrorCode.Trim = "0" Then
                hfCollNbr.Value = objmColHeader.collectionNbr
                txtColNumber.Text = hfCollNbr.Value
                'Looping for get CodeId by GV to CollectionDetail
                For Each row As GridViewRow In gvDataPage.Rows
                    listCodeId.Add(row.Cells(0).Text)
                    listCodeDocNbrId.Add(row.Cells(1).Text)
                Next

                Dim objmColDetail As New Entities.mCollection
                objmColDetail.collectionNbr = hfCollNbr.Value
                objmColDetail.lCodeId = String.Join(",", listCodeId)
                objmColDetail.docNbr = String.Join(",", listCodeDocNbrId)
                objmColDetail = DataAccess.AccountAccess.InsertUpdateDeleteUserCollectionDetail(objmColDetail)
                If objmColDetail.ErrorCode.Trim = "0" Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Save Data Successfully.');", True)
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageInfo('Info','" + objmColHeader.ErrorDescription + "');", True)
                'MsgBox(objmColHeader.ErrorDescription)
            End If

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message.ToString + "');", True)
            'MessageError("Add Page Failed", ex.Message.ToString)
        End Try
    End Sub

    Protected Sub btnBackCancel_Click(sender As Object, e As EventArgs) Handles btnBackCancel.Click
        Response.Redirect("~/Contents/AddRekonsal.aspx")
    End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub btnSelectGrid_Click(sender As Object, e As System.EventArgs) Handles btnSelectGrid.Click
        Try
            Dim ds As New DataSet
            Dim ID As String = Session("User").user_id
            ds = DataAccess.AccountAccess.GetDataCollectionAllByParam(hfCode.Value)
            If ds.ExtendedProperties("ErrorCode") = "0" Then
                pnlSubmit.Visible = True
                PnlData.Visible = False
                btnAdd.Visible = False
                btnSubmit.Visible = False
                lnkLookupCorr.Enabled = False
                txtColNumber.Text = ds.Tables(0).Rows(0).Item("CollectionNbr").ToString.Trim
                lblNameCorr.Text = ds.Tables(0).Rows(0).Item("corr_name").ToString.Trim
                hfCorrID.Value = ds.Tables(0).Rows(0).Item("corr_id").ToString.Trim
                txtDueDate.Text = ds.Tables(0).Rows(0).Item("duedate2").ToString.Trim
                ddlUmurPiutang.SelectedValue = ds.Tables(0).Rows(0).Item("umurpiutang").ToString.Trim
                ddlStatus.SelectedValue = ds.Tables(0).Rows(0).Item("collectionstatus").ToString.Trim
                txtTotalAmountIDR.Text = Format(Val(ds.Tables(0).Rows(0).Item("totalamount").ToString.Trim), "#,##0.00")

                If Session("user").uaccess = "ACC" Then
                    ddlStatus.SelectedValue = "R"
                End If


                ViewState("gridDetailOri") = ds.Tables(1)
                ViewState("gridDetailRev") = ds.Tables(1)
                gvDataPage.DataSource = ViewState("gridDetailRev")
                gvDataPage.DataBind()
            Else
                'ShowErrorMessage(ds.ExtendedProperties("ErrorDescription"))
            End If
        Catch ex As Exception
            'ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As System.EventArgs) Handles btnAccept.Click
        Try
            Dim objmAccept As New Entities.mUser
            objmAccept.UID = Session("user").uid
            objmAccept.UAccess = Session("user").uaccess
            DataAccess.AccountAccess.AcceptRekonsal(txtColNumber.Text, objmAccept)
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageSuccess('Success','Data has been Accepted.');", True)
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "MessageError('Error','" + ex.Message + "');", True)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        hfID.Value = 0
        PnlData.Visible = False
        pnlSubmit.Visible = True
        pnlGridData.Visible = True
        btnAdd.Visible = False
    End Sub

    'Private Sub btnCloseMsg_Click(sender As Object, e As System.EventArgs) Handles btnCloseMsg.Click
    '    rowWarning.Visible = False
    'End Sub

    'Private Sub btnDelete_Click(sender As Object, e As System.EventArgs)
    '    Try
    '        Dim objmPage As New Entities.mPage
    '        Dim objAccountAccess As New DataAccess.AccountAccess

    '        objmPage.ID = hfID.Value
    '        'objmPage.PageURL = txtPageURL.Text.Trim
    '        'objmPage.PageControlID = txtPageControlID.Text.Trim
    '        'objmPage.PageDescription = txtPageDescription.Text.Trim
    '        'objmPage.PageHeader = txtPageHeader.Text.Trim
    '        objmPage.HeaderID = 0
    '        objmPage = DataAccess.AccountAccess.InsertUpdateDeletePage(objmPage, True)

    '        If objmPage.ErrorCode.Trim = "0" Then
    '            ShowMessage("Delete data successfully")
    '            PnlData.Visible = True
    '            pnlSubmit.Visible = False
    '            LoadData()
    '        Else
    '            ShowErrorMessage(objmPage.ErrorDescription)
    '        End If

    '    Catch ex As Exception

    '        MessageError("Add Page Failed", ex.Message.ToString)

    '    End Try

    'End Sub

    'Private Sub lnkHeader_Click(sender As Object, e As System.EventArgs) Handles lnkHeader.Click
    '    IframeCorrID.Attributes("src") = ConfigurationManager.AppSettings("root") & "/LookUp/frmLookupPageHeader.aspx"
    '    mpLookupCorrID.Show()
    'End Sub



    'Private Sub lnkClear_Click(sender As Object, e As System.EventArgs) Handles lnkClear.Click
    '    txtPageHeader.Text = ""
    '    hfHeaderID.Value = 0
    'End Sub





End Class