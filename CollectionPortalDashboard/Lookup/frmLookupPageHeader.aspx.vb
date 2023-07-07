Imports CollectionPortalDAL.Entities
Imports CollectionPortalDAL.DataAccess

Public Class frmLookupPageHeader
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

 
        Dim objmPage As New mPage
 
        gvData.DataSource = AccountAccess.PageDataHeader().Tables(0)
        gvData.DataBind()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click

        Dim objmPage As New mPage

        objmPage.PageURL = txtPageURL.Text.Trim
        objmPage.PageControlID = txtPageControlID.Text.Trim

        gvData.DataSource = AccountAccess.PageDataHeaderByID(objmPage).Tables(0)
        gvData.DataBind()

    End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        gvData.DataBind()
    End Sub
End Class