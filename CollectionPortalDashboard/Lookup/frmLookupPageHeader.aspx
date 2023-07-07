<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLookupPageHeader.aspx.vb"
    Inherits="CollectionPortalDashboard.frmLookupPageHeader" %>

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
        <%-- <div class="popup_Titlebar" id="PopupHeader" >
        <div class="TitlebarLeft">
            Business Class
        </div>
        <div class="TitlebarRight" onclick="cancel();">
        </div>
    </div>
        --%>
        <div class="popup_Body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="row">
                            <label class="col-3 form-control-sm" style="font-weight: 400">
                                Page URL</label>
                            <div class="col-9">
                                <div class="input-group">
                                    <asp:TextBox ID="txtPageURL" runat="server" MaxLength="25" CssClass="form-control form-control-sm" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-3 form-control-sm" style="font-weight: 400">
                                Page Control ID</label>
                            <div class="col-9">
                                <div class="input-group">
                                    <asp:TextBox ID="txtPageControlID" runat="server" MaxLength="25" CssClass="form-control form-control-sm" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-secondary btn-sm col-sm-12" />
                                </div>
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
            <div class="row">
                <div class="col-md-6">
                    <asp:GridView ID="gvData" runat="server" AllowPaging="True" PageSize="6" CssClass="table table-sm table-bordered"
                        ShowHeaderWhenEmpty="true" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
                                DataField="ID" />
                            <asp:TemplateField HeaderText="No." ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="pageURL" HeaderText="Page URL" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="PageControlID" HeaderText="Page Control ID" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="PageDescription"
                                HeaderText="Page Description" />
                        </Columns>
                        <PagerStyle CssClass="footerCss" />
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <%--<EmptyDataRowStyle BackColor="#17a2b8" Font-Bold="True" ForeColor="#f8f9fa" />--%>
                    </asp:GridView>
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

        $("#gvData > tbody > tr > td").click(function () {
            if (footer == false) {
                var code = $(this).parent().find('td:eq(0)').text()
                var description = $(this).parent().find('td:eq(1)').text()

                $('#MainContent_hfHeaderID', window.parent.document).val(code)

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
