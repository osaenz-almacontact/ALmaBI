<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Alma_Reporting.GestionDeUsuarios.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        $off_white:#fafafa;
        $light_grey:#A39D9E;
        * {
            box-sizing: border-box;
        }

        body {
            background-color: $off_white;
        }

        .container {
            margin: 80px auto;
            width: 809px;
        }

        .light {
            background-color: #fff;
        }

        .calendar {
            width: 100%;
            font-family: 'century gothic', sans-serif;
            padding: 20px 30px;
            display: inline-block;
        }

        .calendar_header {
            border-bottom: 2px solid rgba(0, 0, 0, 0.08);
        }

        .header_copy {
            color: $light_grey;
        }

        .calendar_plan {
            margin: 20px 0 40px;
        }

        .cl_plan {
            width: 100%;
            height: 140px;
            background-image: linear-gradient(-222deg, #12679B, #1EA6FA);
            box-shadow: 0px 0px 52px -18px rgba(0, 0, 0, 0.75);
            padding: 30px;
            color: #fff;
        }

        .cl_title {
        }

        .cl_copy {
            font-size: 20px;
            margin: 20px 0;
            display: inline-block;
        }

        .calendar_events {
            color: $light_grey;
        }

        .ce_title {
            font-size: 14px;
        }
    </style>

    <div class="container-fluid">
        <div class="page-header min-height-100 border-radius-xl mt-4" style="background-image: url('../assets/img/curved-images/curved0.jpg'); background-position-y: 50%; margin-top: 0px !important">
            <span class="mask bg-gradient-info opacity-6"></span>
        </div>
        <div class="card card-body blur shadow-blur mx-4 mt-n6">
            <div class="row gx-4">
                <div class="col-auto my-auto">
                    <div class="h-100">
                        <h5 class="mb-1">
                            <asp:Label Text="text" runat="server" ID="LabNombre" />
                        </h5>
                        <p class="mb-0 font-weight-bold text-sm">
                            <asp:Label Text="text" runat="server" ID="LabCargo" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid py-4">
        <div class="row">


            <div class="col-md-12 mx-auto">
                <div class="accordion accordion-flush" id="accordionPerfil">
                    <div class="accordion-item mb-3">
                        <h5 class="accordion-header" id="headingOne">
                            <button class="accordion-button border-bottom font-weight-bold collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                Informacion de perfil
                <i class="collapse-close fa fa-plus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                                <i class="collapse-open fa fa-minus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                            </button>
                        </h5>
                        <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionPerfil" style="">
                            <div class="accordion-body text-sm opacity-8">

                                <div class="row">
                                    <div class="col-12 col-xl-4">
                                        <div class="card h-100">
                                            <div class="card-header pb-0 p-3">
                                                <div class="row">
                                                    <div class="col-md-8 d-flex align-items-center">
                                                        <h6 class="mb-0">Informacion personal</h6>
                                                    </div>
                                                    <div class="col-md-4 text-right">
                                                        <a href="javascript:;">
                                                            <i class="fas fa-user-edit text-secondary text-sm" data-bs-toggle="tooltip" data-bs-placement="top" title="Edit Profile"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card-body p-3">
                                                <hr />
                                                <ul class="list-group">
                                                    <li class="list-group-item border-0 ps-0 pt-0 text-sm"><strong class="text-dark">Nombre commpleto:</strong> &nbsp;
                                <asp:Label Text="text" runat="server" ID="LabNombreCompleto" /></li>
                                                    <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark">Nombre de usuario:</strong> &nbsp;
                                <asp:Label Text="text" runat="server" ID="LabNombeDeUsuario" /></li>
                                                    <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark">Telefono:</strong> &nbsp;
                                <asp:Label Text="text" runat="server" ID="LabTelefono" /></li>
                                                    <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark">Operacion:</strong> &nbsp;
                                <asp:Label Text="text" runat="server" ID="LabOperacion" /></li>
                                                    <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark">Cargo:</strong> &nbsp;
                                <asp:Label Text="text" runat="server" ID="LabCargoAsignado" /></li>

                                                </ul>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-12 col-xl-4">
                                        <div class="card h-100">
                                            <div class="card-header pb-0 p-3">
                                                <h6 class="mb-0">Reportes habilitados.</h6>
                                            </div>
                                            <div class="card-body p-3">
                                                <hr />
                                                <asp:Repeater ID="RepeaterVizualizacionReportes" runat="server" OnItemDataBound="RepeaterVizualizacionesAreas_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="form-check form-switch ps-0">

                                                            <label><%#Eval("Nombres") %></label>
                                                            <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="LabId" />
                                                            <asp:CheckBox runat="server" ID="ChekVizualizadoPor" Style="margin-left: 25px !important" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>

                                    
                                </div>

                            </div>
                        </div>
                    </div>
                    <!---END TAB--->
                    <div class="accordion-item mb-3">
                        <h5 class="accordion-header" id="headingTwo">
                            <button class="accordion-button border-bottom font-weight-bold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                Cambio de clave
                <i class="collapse-close fa fa-plus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                                <i class="collapse-open fa fa-minus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                            </button>
                        </h5>
                        <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionPerfil">
                            <div class="accordion-body text-sm opacity-8">
                                <label>Nuevo Password</label>
                                <asp:TextBox runat="server" class="form-control" ID="TxtNuevoPassword" />
                                <div class="col">
                                    <br />
                                    <asp:Button ID="BtnGuardarPassword" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm mb-0" OnClick="BtnGuardarPassword_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item mb-3" style="display:none">
                        <h5 class="accordion-header" id="headingThree">
                            <button class="accordion-button border-bottom font-weight-bold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                Horario
                <i class="collapse-close fa fa-plus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                                <i class="collapse-open fa fa-minus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                            </button>
                        </h5>
                        <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionPerfil">
                            <div class="accordion-body text-sm opacity-8">

                                <div class="card">
                                    <div class="card-header">
                                        <ul class="nav nav-tabs card-header-tabs pull-right" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-toggle="tab" href="#tab-1">Activo</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#tab-2">Cambio</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link disabled" data-toggle="tab" href="#tab-3">Autorizacion</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="card-body">


                                        <div class="tab-content">
                                            <div class="tab-pane fade show active" id="tab-1" role="tabpanel">



                                                <div class="calendar light">
                                                    <div class="calendar_header">
                                                        <h1 class="header_title">Mi Horario</h1>
                                                        <p class="header_copy">Semanal</p>
                                                    </div>
                                                    <div class="calendar_plan">
                                                        <div class="cl_plan">
                                                            <div class="cl_title">Hoy</div>
                                                            <div class="row">
                                                                <div class="cl_copy col-md-4">22nd  April  2018</div>
                                                                <div class="col-md-8">
                                                                    <h2 style="color: white;"><b>Hora Ingreso</b> 8 AM - <b>Hora Salida</b> 5PM</h2>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="calendar_events">

                                                        <div class="row">
                                                            <div class="col-md-8">

                                                                <div class="table-responsive">
                                                                    <table class="table mb-0">
                                                                        <thead>
                                                                            <tr>
                                                                                <th scope="col">Dia</th>
                                                                                <th scope="col">Ingreso</th>
                                                                                <th scope="col">Break #1</th>
                                                                                <th scope="col">Break #2</th>
                                                                                <th scope="col">Dialogo</th>
                                                                                <th scope="col">Formacion</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <th scope="row">Lunes</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th scope="row">Martes</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th scope="row">Miercoles</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th scope="row">Jueves</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th scope="row">Viernes</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th scope="row">Sabado</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th scope="row">Domingo</th>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                                <td>Cell</td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>

                                                                <hr />
                                                                <br />
                                                                <div class="col-sm-12">
                                                                    <h3>Solicitud de cambio</h3>
                                                                    <p style="color: red">Recuerde que la solicitud debe ser enviada al menos 24 horas antes del día a cambiar</p>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label>Dia</label>
                                                                            <input type="date" id="DateDiaCambio" class="form-control" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label>Id Trabajador</label>
                                                                            <asp:TextBox runat="server" ID="TxtIdPersonaCmabio" placeholder="Id de la persona con quien se realizará el cambio." CssClass="form-control" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label>Ingreso</label>
                                                                            <asp:DropDownList ID="DropIngreso" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label>Salida</label>
                                                                            <asp:DropDownList ID="DropSalida" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <asp:Button runat="server" ID="BtnSolicitar" class="btn btn-primary btn-block" Text="Solicitar" />
                                                                </div>


                                                            </div>
                                                            <!---END COL--->
                                                            <div class="col-md-4">

                                                                <div class="alert alert-primary alert-dismissible" role="alert">
                                                                    <div class="alert-icon">
                                                                        <i class="far fa-fw fa-bell"></i>
                                                                    </div>
                                                                    <div class="alert-message" style="color: white">
                                                                        <strong>Fecha de ingreso</strong> Su solicitud para el dia 02-02-2021 en estado Pendiente!
                                                                    </div>
                                                                </div>

                                                                <div class="alert alert-primary alert-dismissible" role="alert">
                                                                    <div class="alert-icon">
                                                                        <i class="far fa-fw fa-bell"></i>
                                                                    </div>
                                                                    <div class="alert-message" style="color: white">
                                                                        <strong>Fecha de ingreso</strong> Su solicitud para el dia 02-02-2021 en estado Pendiente!
                                                                    </div>
                                                                </div>


                                                            </div>

                                                        </div>
                                                        <!----END ROW---->

                                                    </div>
                                                </div>


                                            </div>


                                            <div class="tab-pane fade" id="tab-2" role="tabpanel">
                                                <div class="calendar light">
                                                    <div class="calendar_header">
                                                        <h1 class="header_title">Cambio de Jornada</h1>
                                                        <p class="header_copy">Semanal</p>
                                                    </div>
                                                    <div class="caledar_events">
                                                        <div class="row">
                                                            <div class="col-md-8">
                                                                <br />
                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <label>ID Agente</label>
                                                                        <asp:TextBox runat="server" ID="TxtIdAgenteCambio" CssClass="form-control" />
                                                                    </div>
                                                                    <div class="form-group" style="margin-top: 25px; margin-left: 5px;">
                                                                        <asp:Button Text="Buscar Horario" runat="server" CssClass="btn btn-pill btn-primary" />
                                                                    </div>

                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label>Dia</label>
                                                                            <asp:TextBox ID="TxtMonday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="TxtTuesday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="TxtWednesday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="TxtThursday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="TxtFriday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="TxtSaturday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="TxtSunday" runat="server" placeholder="Dia" class="form-control" OnFocus="this.blur()"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label>LogIn</label>
                                                                            <asp:DropDownList ID="DropLogInMonday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogInTuesday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogInWednesday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogInThursday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogInFriday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogInSaturday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogInSunday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label>LogOut</label>
                                                                            <asp:DropDownList ID="DropLogOutMonday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogOutTuesday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogOutWednesday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogOutThursday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogOutFriday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogOutSaturday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="DropLogOutSunday" class="form-control" runat="server">
                                                                                <asp:ListItem>(Seleccionar)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!----END COL---->
                                                            <div class="col-md-4">

                                                                <div class="alert alert-primary alert-dismissible" role="alert">
                                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                    <div class="alert-icon">
                                                                        <i class="far fa-fw fa-bell"></i>
                                                                    </div>
                                                                    <div class="alert-message">
                                                                        <strong>Oscar Orduz</strong> Ha solicitado canbiar jornada con <strong>Jaime Garcia</strong> El dia 12-02-2021
                                                                    </div>
                                                                </div>

                                                                <div class="alert alert-primary alert-dismissible" role="alert">
                                                                    <button type="button" class="close" data-dismiss="alert">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                    <div class="alert-icon">
                                                                        <i class="far fa-fw fa-bell"></i>
                                                                    </div>
                                                                    <div class="alert-message">
                                                                        <strong>Oscar Orduz</strong> Ha solicitado canbiar jornada con <strong>Jaime Garcia</strong> El dia 12-02-2021
                                                                    </div>
                                                                </div>


                                                            </div>

                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="tab-3" role="tabpanel">
                                                <h5 class="card-title">Card with tabs</h5>
                                                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                                                <a href="#" class="btn btn-primary">Go somewhere</a>
                                            </div>
                                        </div>

                                    </div>


                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="accordion-item mb-3" style="display:none">
                        <h5 class="accordion-header" id="headingFour">
                            <button class="accordion-button border-bottom font-weight-bold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                Indicadores
                <i class="collapse-close fa fa-plus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                                <i class="collapse-open fa fa-minus text-xs pt-1 position-absolute end-0 me-3" aria-hidden="true"></i>
                            </button>
                        </h5>
                        <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingFour" data-bs-parent="#accordionPerfil">
                            <div class="accordion-body text-sm opacity-8">

                                <div class="card">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="w-100">


                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title mb-4">Indicador 1</h5>
                                                                <div class="row">
                                                                    <div class="col-md-8">
                                                                        <h1 class="display-5 mt-1 mb-3">0,0</h1>
                                                                    </div>
                                                                    <div class="col-md-4" align="center">
                                                                        <i class="text-success far fa-arrow-alt-circle-up fa-4x" data-feather="arrow-up-circle"></i>
                                                                    </div>
                                                                </div>

                                                                <div class="mb-1">
                                                                    <span class="text-success"><i class="mdi mdi-arrow-bottom-right"></i>0,0% </span>
                                                                    <span class="text-muted">Desde el mes pasado</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title mb-4">Indicador 2</h5>
                                                                <div class="row">
                                                                    <div class="col-md-8">
                                                                        <h1 class="display-5 mt-1 mb-3">0,0</h1>
                                                                    </div>
                                                                    <div class="col-md-4" align="center">
                                                                        <i class="text-success far fa-arrow-alt-circle-up fa-4x" data-feather="arrow-up-circle"></i>
                                                                    </div>
                                                                </div>

                                                                <div class="mb-1">
                                                                    <span class="text-success"><i class="mdi mdi-arrow-bottom-right"></i>0,0% </span>
                                                                    <span class="text-muted">Desde el mes pasado</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title mb-4">Indicador 3</h5>
                                                                <div class="row">
                                                                    <div class="col-md-8">
                                                                        <h1 class="display-5 mt-1 mb-3">0,0</h1>
                                                                    </div>
                                                                    <div class="col-md-4" align="center">
                                                                        <i class="text-info far fas fa-info-circle fa-4x" data-feather="arrow-up-circle"></i>
                                                                    </div>
                                                                </div>

                                                                <div class="mb-1">
                                                                    <span class="text-danger"><i class="mdi mdi-arrow-bottom-right"></i>0,0% </span>
                                                                    <span class="text-muted">Desde el mes pasado</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title mb-4">Indicador 4</h5>
                                                                <div class="row">
                                                                    <div class="col-md-8">
                                                                        <h1 class="display-5 mt-1 mb-3">0,0</h1>
                                                                    </div>
                                                                    <div class="col-md-4" align="center">
                                                                        <i class="text-info far fas fa-info-circle fa-4x" data-feather="arrow-up-circle"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="mb-1">
                                                                    <span class="text-danger"><i class="mdi mdi-arrow-bottom-right"></i>-0,0% </span>
                                                                    <span class="text-muted">Desde el mes pasado</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row" style="margin-top: 15px">
                                                    <div class="col-sm-3">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title mb-4">Desempeño Mes</h5>
                                                                <div class="row">
                                                                    <div class="col-md-8">
                                                                        <h1 class="display-5 mt-1 mb-3">0,0</h1>
                                                                    </div>
                                                                    <div class="col-md-4" align="center">
                                                                        <i class="text-danger far fa-arrow-alt-circle-down fa-4x" data-feather="arrow-up-circle"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="mb-1">
                                                                    <span class="text-danger"><i class="mdi mdi-arrow-bottom-right"></i>0,0% </span>
                                                                    <span class="text-muted">Desde el mes pasado</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="card" style="margin-top: 15px">
                                                            <div class="card-body">
                                                                <h5 class="card-title mb-4">Orders</h5>
                                                                <h1 class="display-5 mt-1 mb-3">64</h1>
                                                                <div class="mb-1">
                                                                    <span class="text-danger"><i class="mdi mdi-arrow-bottom-right"></i>-2.25% </span>
                                                                    <span class="text-muted">Desde el mes pasado</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-9">

                                                        <div class="table-responsive">
                                                            <table class="table mb-0">
                                                                <thead>
                                                                    <tr>
                                                                        <th scope="col">Semana</th>
                                                                        <th scope="col">Indicador 1</th>
                                                                        <th scope="col">Indicador 2</th>
                                                                        <th scope="col">Indicador 3</th>
                                                                        <th scope="col">Indicador 4</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <th scope="row">Semana 1</th>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th scope="row">Semana 2</th>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th scope="row">Semana 3</th>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th scope="row">Semana 4</th>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                        <td>Cell</td>
                                                                    </tr>

                                                                </tbody>
                                                            </table>
                                                        </div>


                                                    </div>
                                                </div>

                                            </div>

                                        </div>


                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <!---END CARD---->


                </div>
                <!---END TAB---->
            </div>




        </div>


    </div>
</asp:Content>
