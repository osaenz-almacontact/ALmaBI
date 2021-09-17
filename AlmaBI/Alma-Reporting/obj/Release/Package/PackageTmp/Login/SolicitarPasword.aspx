<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitarPasword.aspx.cs" Inherits="Alma_Reporting.Login.SolicitarPasword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://fonts.googleapis.com/css?family=Century+Gothic:300,400,600,700" rel="stylesheet" />

    <link href="../Content/css/nucleo-icons.css" rel="stylesheet" />
    <link href="../Content/css/nucleo-svg.css" rel="stylesheet" />

    <link href="../Content/css/soft-ui-dashboard.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Login</title>
</head>
<body class="g-sidenav-show  bg-white app-login p-0">

    <section>
        <div class="row g-0 app-auth-wrapper">
            <div class="col-12 col-md-12 col-lg-6 auth-main-col p-5">
                <div class="col-xl-8 col-lg-9 col-md-12 d-flex flex-column mx-auto">
                    <div class="card card-plain mt-6">
                        <div class="card-header pb-0 text-left bg-transparent">
                            <img src="../Content/img/logos/AlmaBI.png" />
                            <ul>
                                <li>
                                    <p class="mb-0">Ingrese su dirección de correo electrónico que utiliza para iniciar sesión en su cuenta</p>
                                </li>

                                <li>
                                    <p class="mb-0">Le enviaremos un correo electrónico con instrucciones para elegir una nueva contraseña.</p>
                                </li>
                            </ul>


                        </div>
                        <div class="card-body">
                            <form id="form1" runat="server" role="form text-left">
                                <label>Email</label>
                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="TxtUsuario" class="form-control" placeholder="Email" aria-label="Email" aria-describedby="email-addon" required="required" />
                                </div>
                                <div class="text-center">
                                    <asp:Button Text="Solicitar" ID="btnSolicitud" runat="server" class="btn bg-gradient-info w-100 mt-4 mb-0" OnClick="btnSolicitud_Click" />
                                </div>

                                <asp:Panel ID="pnl_Mensaje" runat="server" Visible="false">
                                    <hr />
                                    <div class="alert alert-success" role="alert">
                                        <asp:Label ID="LblMensaje" runat="server" ForeColor="white" Font-Bold="true"></asp:Label>
                                    </div>

                                </asp:Panel>
                            </form>
                        </div>

                    </div>
                </div>
               
            </div>
            <div class="col-12 col-md-12 col-lg-6 h-100 auth-background-col">
                <div class="auth-background-holder">
                </div>
            </div>
        </div>
    </section>
    <!-- -------- START FOOTER 3 w/ COMPANY DESCRIPTION WITH LINKS & SOCIAL ICONS & COPYRIGHT ------- -->
    <%--    <footer class="footer py-4 fixed-bottom">
        <div class="container">
            <div class="d-flex align-items-center justify-content-between small">
                <div class="text-muted">
                    <asp:Label ID="lbl_Pagina" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <a href="#">Privacy Policy</a>
                    &middot;
                                <a href="#">Terms &amp; Conditions</a>
                </div>
            </div>
        </div>
    </footer>--%>
    <!-- -------- END FOOTER 3 w/ COMPANY DESCRIPTION WITH LINKS & SOCIAL ICONS & COPYRIGHT ------- -->
    <!--   Core JS Files   -->
    <script src="../assets/js/core/popper.min.js"></script>
    <script src="../assets/js/core/bootstrap.min.js"></script>
    <script src="../assets/js/plugins/smooth-scrollbar.min.js"></script>
    <!-- Control Center for Soft Dashboard: parallax effects, scripts for the example pages etc -->
    <script src="../assets/js/soft-ui-dashboard.min.js?v=1.0.1"></script>
    <script>
        var win = navigator.platform.indexOf('Win') > -1;
        if (win && document.querySelector('#sidenav-scrollbar')) {
            var options = {
                damping: '0.5'
            }
            Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
        }
    </script>
    <!-- Github buttons -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>
</body>
</html>
