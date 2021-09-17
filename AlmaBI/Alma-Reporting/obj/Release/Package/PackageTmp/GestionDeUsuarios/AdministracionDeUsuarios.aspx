<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionDeUsuarios.aspx.cs" Inherits="Alma_Reporting.GestionDeUsuarios.AdministracionDeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="alert alert-primary" role="alert" runat="server" id="DivAlert">
        <asp:Label Text="text" runat="server" ID="LabMensajeAlerta" />
        <button type="button" class="btn-close align-items-center" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="card" runat="server" id="DivUsuarios">
        <div class="card-header"><b>Agregar Usuario</b></div>
        <div class="card-body">
            <div class="row">
                <div class="col-4">
                    <div class="cform-row" style="margin-top: 10px">
                        <label>Nombre Completo</label>
                        <asp:TextBox ID="TxtNombreCompleto" runat="server" placeholder="Nuevo Usuario" class="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="cform-row" style="margin-top: 10px">
                        <label>Correo</label>
                        <asp:TextBox ID="TxtCorreo" runat="server" placeholder="Email" class="form-control" MaxLength="50" autocomplete="off"></asp:TextBox>
                    </div>
                </div>

                <div class="col-4">
                    <div class="cform-row" style="margin-top: 10px">
                        <label>Tipo Perfil</label>
                        <asp:DropDownList ID="DropTipoPerfil" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                    <div class="cform-row" style="margin-top: 10px">
                        <label>Tipo acceso</label>
                        <asp:DropDownList ID="DropTipoAcceso" class="form-control" runat="server" OnSelectedIndexChanged="DropTipoAcceso_SelectedIndexChanged" AutoPostBack="true">
                            <Items>
                                <asp:ListItem Text="Operacion" Value="1" />
                                <asp:ListItem Text="Cliente" Value="2" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-4">
                    <div class="cform-row" style="margin-top: 10px">
                        <label>Cargo</label>
                        <asp:DropDownList ID="DropCargo" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>

                    <div class="cform-row" style="margin-top: 10px">
                        <label>Area</label>
                        <asp:DropDownList ID="DropArea" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="col-4">
                    <div class="cform-row" style="margin-top: 10px">
                        <label>Telefono de contacto</label>
                        <asp:TextBox ID="TxtTelefono" runat="server" placeholder="8524655" class="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>


                <div class="col-4">
                </div>
                <div class="col-4">
                </div>
            </div>
            <br />
            <hr />
            <div class="row">

                <div class="col-4">
                    <div class="form-row" style="margin-top: 10px">
                        <label>Operaciones:</label>
                        <asp:Repeater ID="RepeaterOperaciones" runat="server" OnItemDataBound="RepeaterOperaciones_ItemDataBound">
                            <ItemTemplate>
                                <div class="form-check form-switch ps-0">

                                    <label><%#Eval("Nombres") %></label>
                                    <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="LabIdOperacion" />
                                    <asp:Label Text='<%#Eval("Nombres") %>' runat="server" ID="LabNombreOperacion" Visible="false" />
                                    <asp:CheckBox runat="server" ID="ChekOperaciones" Style="margin-left: 25px !important" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col-8">
                    <div class="form-row" style="margin-top: 10px">
                        <label>Reportes:</label>
                        <asp:Repeater ID="RepeaterAsignacionReporte" runat="server" OnItemDataBound="RepeaterAsignacionReporte_ItemDataBound">
                            <ItemTemplate>
                                <div class="form-check form-switch ps-0">

                                    <label><%#Eval("Nombres") %></label>
                                    <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="LabId" />
                                    <asp:Label Text='<%#Eval("NombreArea") %>' runat="server" ID="LabNombreArea" />
                                    <asp:Label Text='<%#Eval("IdReporte") %>' runat="server" ID="LabIdReporte" />
                                    <asp:CheckBox runat="server" ID="ChekAreaReporte" Style="margin-left: 25px !important" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col">
                    <br />
                    <asp:Button ID="BtnGuardarUsuario" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm mb-0" OnClick="BtnGuardarUsuario_Click" />
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card" runat="server" id="Div1">
        <div class="card-header"><b>Editar Usuarios</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterUsuarios" runat="server" OnItemDataBound="OnItemDataBound">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Nombres</th>
                                    <th scope="col">Usuario</th>
                                    <th scope="col">Cargo</th>
                                    <th scope="col">Operacion</th>
                                    <th scope="col">Perfil</th>
                                    <th scope="col">Tipo Acceso</th>
                                    <th scope="col">Telefono</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col" style="text-align: center;" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdUsuario" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabNombreCompleto" runat="server" Text='<%#Eval("Nombres") %>'></asp:Label>
                                <asp:TextBox ID="TxtNombreCompleto" runat="server" Text='<%#Eval("Nombres") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabNombreUsuario" runat="server" Text='<%#Eval("Usuario") %>'></asp:Label>
                                <asp:TextBox ID="TxtNombreUsuario" runat="server" Text='<%#Eval("Usuario") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Labcargo" runat="server" Text='<%#Eval("Cargo") %>'></asp:Label>
                                <asp:Label ID="LabCargoAnterior" runat="server" Text='<%#Eval("IdCargo") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="DropCambiarCargo" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LabOperacion" runat="server" Text='<%#Eval("Operacion") %>' />
                                <asp:Label ID="LabOperacionAnterior" runat="server" Text='<%#Eval("Operacion") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="DropCambiarOperacion" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                                <asp:Label ID="LabIdOperacion" runat="server" Text='<%#Eval("Operacion") %>' Visible="false" />
                            </td>
                            <td>
                                <asp:Label ID="LabPerfil" runat="server" Text='<%#Eval("Perfil") %>' />
                                <asp:Label ID="LabIdPerfilAnterior" runat="server" Text='<%#Eval("IdPerfil") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="DropCambioPerfi" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LabArea" runat="server" Text='<%#Eval("IdArea") %>' />
                                <asp:Label ID="LabAreaAnterir" runat="server" Text='<%#Eval("IdArea") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="DropCambioArea" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LabTelefono" runat="server" Text='<%#Eval("Telefono") %>'></asp:Label>
                                <asp:TextBox ID="TxtTelefono" runat="server" Text='<%#Eval("Telefono") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <%--<input type="checkbox" id="ChkTipoUsuario" <%# Convert.ToBoolean(Eval("Acctivo")) ? "checked" : string.Empty %> />--%>
                                    <asp:CheckBox runat="server" ID="ChkTipoUsuarioCambio" CssClass="form-check-input ms-auto" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChkTipoUsuario" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
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

</asp:Content>
