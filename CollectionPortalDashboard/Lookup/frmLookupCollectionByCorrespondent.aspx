<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLookupCollectionByCorrespondent.aspx.vb"
    Inherits="CollectionPortalDashboard.frmLookupCollectionByCorrespondent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lookup Business Class</title>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.min.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.min.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/js/sweetalert.min.js") %>'></script> 
    <link type="text/css" rel="stylesheet" href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/css/dataTables.bootstrap4.css") %>' />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("~/Assets/css/main.css") %>' />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("~/Assets/css/myCSS.css") %>' />
    <link rel="stylesheet" href="~/Assets/admin-lte/plugins/fontawesome-free/css/all.min.css">
    <link rel="stylesheet" href="~/Assets/admin-lte/css/adminlte.min.css">
    <link rel="stylesheet" href="~/Assets/css/main.css">
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
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="hfPageID" />
                    <asp:GridView ID="gvData" EmptyDataText="No Records Found" runat="server" AllowPaging="false"
                            PageSize="10" CssClass="table table-sm table-bordered" ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
                                DataField="codeId" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkBox" name="chkName" CssClass="chkBoxClass" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No." ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="correspondent_id" HeaderText="Corr Id" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="insured_id" HeaderText="Insured Id" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="policy_nbr" HeaderText="Policy Nbr" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="uwyear" HeaderText="UWYear" />
                        </Columns>
                        <PagerStyle CssClass="footerCss" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-8">
                            </div>
                            
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Button runat="server" ID="btnAddInsured" Text="Add Insured" CssClass="btn btn-info btn-sm col-sm-12" />
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
        </div>
    </div>
    </form>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script>
   <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.js")%>' type="text/javascript"></script>
   <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/moment/moment.min.js")%>' type="text/javascript"></script>
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

        $(document).ready(function () {

            $('#gvData').DataTable({
                "bFilter": true,
                "bInfo": false,
                "lengthChange": false
            });
        });


        $("#btnClose").click(function () {
            $('#MainContent_btnCloseHeaderID', window.parent.document).click()
        });

        $("#btnAddInsured").click(function () {
            var value = $('#hfPageID').val()
            $('#MainContent_hfCodeIns', window.parent.document).val(value)

            $('#MainContent_btnSelectInsID', window.parent.document).click()
        });

        $(document).on('click', '.chkBoxClass', function () {

            var checkedValues = $('input:checkbox:checked').map(function () {
                return $(this).parent().parent().parent().find('td:eq(0)').text().trim()
            }).get();
//            alert(checkedValues)
            $('#hfPageID').val(checkedValues)

        });

        LoadChecklist()

        function LoadChecklist() {

            var chkArr = [];
            chkArr = $('#hfPageID').val().split(",")
            var rowscount = $("#<%=gvData.ClientID %> tr").length;
            //alert(rowscount)
//            alert(chkArr)
            for (var i = 0; i < rowscount; i++) {

                var id = $("#MainContent_gvData > tbody > tr:eq(" + i + ") > td:eq(0)").text()

                if ($.inArray(id, chkArr) !== -1) {
                    $("#MainContent_gvData > tbody > tr:eq(" + i + ") > td:eq(2) > .chkBoxClass > input").prop('checked', 'checked');
                }

            }

        }

        function LoadBG() {


            var rowscount = $("#<%=gvData.ClientID %> tr").length;

            for (var i = 0; i < rowscount - 1; i++) {

                if ($("#<%=gvData.ClientID %>").find('tr:eq(' + i + ')').find('.ClassHeaderID').text() == "0") {
                    $("#<%=gvData.ClientID %>").find('tr:eq(' + i + ')').attr('style', 'background:#80808045;')
                }

            }

        }


        var footer = false

        $(document).on('click', '.itemcol', function () {

            if (footer == false) {

                var Code = $(this).parent().find('td:eq(0)').text()

                $('#hfCode').val('#hfPageID')
//                alert($('#hfCode').val())

                $('#MainContent_btnSelectInsID').click()

            }
        });

        function callSubmitButton() {
            document.getElementById('<%=btnAddInsured.ClientID%>').click();
        }

//        $("#gvData > tbody > tr > td").click(function () {
//            if (footer == false) {
//                var code = $(this).parent().find('td:eq(0)').text()
//                var description = $(this).parent().find('td:eq(1)').text()

//                $('#MainContent_hfHeaderID', window.parent.document).val(code)

//                $('#MainContent_btnCloseHeaderID', window.parent.document).click()
//                $('#MainContent_btnSelectHeaderID', window.parent.document).click()
//            }
//        });

        $(".footerCss").mouseenter(function () {
            footer = true;
        });

        $(".footerCss").mouseleave(function () {
            footer = false;
        });

    </script>
</body>
</html>
