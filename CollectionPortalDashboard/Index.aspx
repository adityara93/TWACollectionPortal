<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="CollectionPortalDashboard.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>Collection Portal</title>
    <link rel="stylesheet" href="~/Assets/admin-lte/plugins/fontawesome-free/css/all.min.css">
    <link rel="stylesheet" href="~/Assets/admin-lte/css/adminlte.min.css">
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.5/dist/sweetalert2.min.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.5/dist/sweetalert2.all.min.js"></script>
    
    <script type="text/javascript">
//        $(document).ready(function () {
//            swal.fire({
//                position: 'top-end',
//                icon: 'success',
//                title: 'Your work has been saved',
//                showConfirmButton: false,
//                timer: 1500
//            });
    </script>
</head>
<body class="login-page">
    <div class="login-box">
        
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-9">
                        <span class="login-logo" style="text-align:left"><b>Collection</b> Portal</span>
                    </div>
                    <div class="col-md-2">
                        <img src='<%=ResolveClientUrl("~/Assets/admin-lte/img/LogoATPI2.png") %>' style="vertical-align:middle;" height="60" width="85" />
                    </div>
                </div>
                
            </div>
            <div class="card-body login-card-body">
                
                <p>Login to start application Collection Portal</p>
                <form id="frmLogin" runat="server">
                <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtUserlogin" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"/>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtUserpassword" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-8"><asp:Label ID="lblAlert" runat="server" style="color:Red" Text="" Font-Size="10px"></asp:Label></div>
                        <div class="col-4">
                            <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="btn btn-primary btn-block toastsDefaultAutohide"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:UpdatePanel ID="upLogin" runat="server">
                                <ContentTemplate>
                                    
                                </ContentTemplate>
                                <Triggers>
                                <asp:PostBackTrigger ControlID="btnLogin"  />
                                   
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    
</body>
</html>
