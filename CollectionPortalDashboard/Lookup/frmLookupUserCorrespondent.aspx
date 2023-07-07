<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLookupUserCorrespondent.aspx.vb"
    Inherits="CollectionPortalDashboard.frmLookupUserCorrespondent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lookup Business Class</title>
    <link rel="stylesheet" href="~/Assets/admin-lte/plugins/fontawesome-free/css/all.min.css">
    <link rel="stylesheet" href="~/Assets/admin-lte/css/adminlte.min.css">
    <link rel="stylesheet" href="~/Assets/css/main.css">
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.min.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/Assets/js/sweetalert.min.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.slim.min.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.min.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/Assets/js/bootstrap.min.js") %>'></script>
    <link href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.css") %>'
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" style="padding: 30px;" runat="server">
    <div class="popup_Container">
        <div class="popup_Body">
            <div class="row">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="hfCorrID" />
                    <asp:GridView ID="gvData" EmptyDataText="No Records Found" runat="server" AllowPaging="false"
                            PageSize="10" CssClass="table table-sm table-bordered" ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
                                DataField="client_id" />
                            <asp:TemplateField HeaderText="No." ItemStyle-Width="10">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="client_id" HeaderText="ClientID" ItemStyle-Width="100"/>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="name" HeaderText="Client Name" ItemStyle-Width="100%"/>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="client_status" HeaderText="Status" ItemStyle-Width="100%" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="remarks" HeaderText="Remarks" ItemStyle-Width="100%"/>
                        </Columns>
                        <PagerStyle CssClass="footerCss" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-10">
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <button type="button" id="btnClose" class="btn btn-secondary btn-sm col-sm-12">
                                        Close</button>
                                    <%--<asp:Button runat="server" ID="btnClose" Text="Close" CssClass="btn btn-secondary btn-sm col-sm-12"/>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <!-- Bootstrap 4 -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/bootstrap/js/bootstrap.bundle.min.js") %>'></script>
    <!-- AdminLTE App -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/js/adminlte.min.js") %>'></script>
    <style type="text/css">
        tbody > tr > td
        {
            cursor: pointer;
        }
        tbody > tr:hover
        {
            background: beige;
        }
        .hiddencol
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        var footer = false

        $("#btnClose").click(function () {
            $('#MainContent_btnCloseHeaderID', window.parent.document).click()
        });

        $("#btnAddCorr").click(function () {
            var value = $('#hfCorrID').val()
            $('#MainContent_hfCode', window.parent.document).val(value)

            $('#MainContent_btnSelectHeaderID', window.parent.document).click()
        });

        $("#gvData > tbody > tr > td").click(function () {
            if (footer == false) {
                var code = $(this).parent().find('td:eq(0)').text()
                var description = $(this).parent().find('td:eq(1)').text()

                $('#MainContent_hfCode', window.parent.document).val(code)

                $('#MainContent_btnCloseHeaderID', window.parent.document).click()
                $('#MainContent_btnSelectHeaderID', window.parent.document).click()
            }
        });

        $(".footerCss").mouseenter(function () {
            footer = true;
        });

        $(".footerCss").mouseleave(function () {
            footer = false;
        });

    </script>
</body>
</html>
