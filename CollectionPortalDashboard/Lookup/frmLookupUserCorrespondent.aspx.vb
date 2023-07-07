Imports CollectionPortalDAL
Imports CollectionPortalDAL.DataAccess
Imports CollectionPortalDAL.Entities

Public Class frmLookupUserCorrespondent
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim objmPage As New mPage
        Dim ID As String = Session("User").user_id
        Dim UID As String = Session("User").uid
        gvData.DataSource = AccountAccess.PageDataUserCorrespondent(ID).Tables(0)
        gvData.DataBind()

    End Sub

    'Private Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click

    '    Dim objmUser As New mUser
    '    Dim ID As String = Session("User").user_id
    '    objmUser.ClientID = txtClient.Text.Trim
    '    objmUser.CorrName = txtName.Text.Trim

    '    gvData.DataSource = AccountAccess.PageDataUserCorrespondentByID(ID, objmUser).Tables(0)
    '    gvData.DataBind()

    'End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        gvData.DataBind()
    End Sub

    'Protected Sub btnAddInsured_Click(sender As Object, e As EventArgs) Handles btnAddInsured.Click

    '    Try
    '        Dim listPageArray As String = hfPageID.Value
    '        Dim ds As DataSet
    '        ds = AccountAccess.PageDataUserCorrespondentByID(Session("User").user_id.ToString(), listPageArray)

    '        If ds.Tables(0).Rows.Count() > 0 Then
    '            'btnDeleteIns.Visible = True
    '        Else

    '        End If


    '    Catch ex As Exception


    '    End Try

    'End Sub

End Class