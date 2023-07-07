Imports CollectionPortalDAL.Entities
Imports CollectionPortalDAL.DataAccess

Public Class frmLookupCorrID
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gvData.DataSource = AccountAccess.PageDataUserCorrespondentByParam("NULL", "NULL").Tables(0)
        gvData.DataBind()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        gvData.DataSource = AccountAccess.PageDataUserCorrespondentByParam(txtCorrID.Text, txtCorrName.Text).Tables(0)
        gvData.DataBind()

    End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        gvData.DataBind()
    End Sub
End Class