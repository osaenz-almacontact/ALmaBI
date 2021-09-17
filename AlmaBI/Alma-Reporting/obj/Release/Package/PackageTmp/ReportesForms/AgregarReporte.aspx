<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarReporte.aspx.cs" Inherits="Alma_Reporting.ReportesForms.AgregarReporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery/jquery.js"></script>
    <script src="../Scripts/jquery/jquery.min.js"></script>
    <style>
        span.CheckBox input {
            /* Styles here */
        }
    </style>
    <div class="alert alert-primary" role="alert" runat="server" id="DivAlert" style="display: none">
        <asp:Label Text="text" runat="server" ID="LabMensajeAlerta" />
        <button type="button" class="btn-close align-items-center" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="card" runat="server" id="DivUsuarios">
        <div class="card-header"><b>Agregar Reporte</b></div>
        <div class="card-body">
            <div class="row">
                <div class="col-6">
                    <div class="form-row">
                        <label>Nombre</label>
                        <asp:TextBox ID="TxtNombreCompleto" runat="server" placeholder="Nuevo Reporte" class="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="form-row" style="margin-top: 10px">
                        <label>Tipo reporte</label>
                        <asp:DropDownList ID="DropTipoReporte" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-6">
                    <div class="cform-row">
                        <label>Ubicacion</label>
                        <asp:TextBox ID="TxtUbicacion" runat="server" placeholder="Link o URL" class="form-control" MaxLength="500"></asp:TextBox>
                    </div>
                    <div class="form-row" style="margin-top: 10px">
                        <label>Grupo</label>
                        <asp:DropDownList ID="DropGrupo" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>

                <hr class="horizontal gray-light my-2">
                <%--<div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <div class="cform-row">
                                <label>Tipo Vizualizacion</label>
                                <div class="form-check form-switch ps-0">
                                    <label>Operacion</label>
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChekTipoVizualizacionOp">
                                </div>
                                <div class="form-check form-switch ps-0">
                                    <label>Cliente</label>
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChekTipoVizualizacionCli">
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>--%>
                <hr />
                <div class="col">
                    <br />
                    <asp:Button ID="BtnGuardarReporte" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm mb-0" OnClick="BtnGuardarReporte_Click" />
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card" runat="server" id="Div1">
        <div class="card-header"><b>Editar Reportes</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterReportes" runat="server" OnItemDataBound="OnItemDataBound">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Nombres</th>
                                    <th scope="col">Tipo</th>
                                    <th scope="col">Ubicacion</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col">FechaCreacion</th>
                                    <th scope="col">Usuario</th>
                                    <th scope="col">Grupo</th>
                                    <%--                                    <th scope="col">Cliente/Operacion</th>--%>
                                    <th scope="col" style="text-align: center;" colspan="3">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdReporte" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabGrupoAsg" runat="server" Text='<%#Eval("IdGrupo") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabeArea" runat="server" Text='<%#Eval("Grupo") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabNombreCompleto" runat="server" Text='<%#Eval("Nombres") %>'></asp:Label>
                                <asp:TextBox ID="TxtNombreCompleto" runat="server" Text='<%#Eval("Nombres") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td class="text-center">
                                <asp:Label ID="LabTipoReporte" runat="server" Text='<%#Eval("TipoReporte") %>'></asp:Label>
                                <asp:Label ID="LabIdTipoReporteAnterior" runat="server" Text='<%#Eval("IdTipoReporte") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="DropCambioTipoReporte" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LabUbicacion" runat="server" Text='<%#Eval("Ubicacion") %>'></asp:Label>
                                <asp:TextBox ID="TxtUbicacion" runat="server" Text='<%#Eval("Ubicacion") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <%--<input type="checkbox" id="ChkTipoUsuario" <%# Convert.ToBoolean(Eval("Acctivo")) ? "checked" : string.Empty %> />--%>
                                    <asp:CheckBox runat="server" ID="ChkCambioEstado" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" Style="margin-left: 25px !important" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChekEstado" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:Label ID="LabFechaCreacion" runat="server" Text='<%#Eval("FechaCreacion", "{0:dd/M/yyyy}") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabNombreUsuario" runat="server" Text='<%#Eval("NombreUsuario") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LabGrupo" runat="server" Text='<%#Eval("Grupo") %>' />
                                <asp:Label ID="LabIdGrupoAnterior" runat="server" Text='<%#Eval("IdGrupo") %>' Visible="false" />
                                <asp:DropDownList ID="DropCambioGrupo" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <div class="text-center">
                                    <%--<button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#UsuariosModal" runat="server" OnClick="BtnAsignar_Click1">Asignar</button>--%>
                                    <asp:Button Text="asignar" runat="server" class="btn btn-warning" ID="BtnAsignar" OnClick="BtnAsignar_Click1" />
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:LinkButton ID="LnkEditar" Text="Editar" runat="server" OnClick="OnEdit" CssClass="btn btn-secondary" />
                                    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizar_Click" Visible="false" />
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                                </div>
                            </td>

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>  
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <!---MODAL---->
    <div class="modal fade" id="UsuariosModal" tabindex="-1" role="dialog" aria-labelledby="UsuariosModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Asignación de reportes</h5>
                    <asp:Label ID="LabIdGrupoModal" runat="server" Font-Bold="true" Visible="false" Text="test" />
                    <asp:Label ID="LabGrupoModal" runat="server" Font-Bold="true" Visible="false" Text="test" />
                    <asp:Label ID="LabIdReporteModal" runat="server" Font-Bold="true" Visible="false" Text="test" />
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-row" style="margin-top: 10px">
                        <label>Usuarios:</label>
                        <asp:Repeater ID="RepeaterAsignacionReporte" runat="server" OnItemDataBound="RepeaterAsignacionReporte_ItemDataBound">
                            <ItemTemplate>
                                <div class="form-check form-switch ps-0">

                                    <label><%#Eval("NombreAreaUsuario") %></label>
                                    <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="LabIdUsuario" Visible="false"/>
                                    <asp:Label Text='<%#Eval("Nombres") %>' runat="server" ID="LabNombreUsuario" Visible="false"/>
                                    <asp:Label Text='<%#Eval("IdArea") %>' runat="server" ID="LabIdArea" Visible="false"/>
                                    <asp:CheckBox runat="server" ID="ChekAreaUsuario" Style="margin-left: 25px !important" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button ID="BtnAsignarReporteUsuario" Text="Asignar" runat="server" CssClass="btn btn-secondary" OnClick="BtnAsignarReporteUsuario_Click" />
                </div>
            </div>
        </div>
    </div>


    <script>
        function autoHide() {  //hide after 5 seconds
            setTimeout(function () { document.getElementById("<%=DivAlert.ClientID %>").style.display = 'none'; }, 5000);
        }
    </script>

    <script type="text/javascript">
        function modal() {
            var myModal = document.getElementById('UsuariosModal')

            myModal.addEventListener('shown.bs.modal', function () {
                myInput.focus()
            })


            document.getElementById("#UsuariosModal").show();
            $("#UsuariosModal").show();
            alert("df");
        }
    </script>

</asp:Content>
