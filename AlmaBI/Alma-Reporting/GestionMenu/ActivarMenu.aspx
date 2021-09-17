<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActivarMenu.aspx.cs" Inherits="Alma_Reporting.GestionMenu.ActivarMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-primary" role="alert" runat="server" id="DivAlert" style="display: none">
        <asp:Label Text="text" runat="server" ID="LabMensajeAlerta" />
        <button type="button" class="btn-close align-items-center" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
        <div class="card" runat="server" id="DivAgregarMenu">
        <div class="card-header"><b>Agregar Reporte</b></div>
        <div class="card-body">
            <div class="row">
                <div class="col-6">
                    <div class="form-row" style="margin-top: 10px">
                        <label>Tipo reporte</label>
                        <asp:DropDownList ID="DropOperacion" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-6">
                    <div class="form-row" style="margin-top: 10px">
                        <label>Perfil</label>
                        <asp:DropDownList ID="DropPerfil" class="form-control" runat="server">
                            <Items>
                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>

                <hr class="horizontal gray-light my-2">
                <div class="col-6">
                    <div class="row">
                        
                        <div class="col-8">
                            <div class="form-row" style="margin-top: 10px">
                                <label>Vizualizado por:</label>
                                <asp:Repeater ID="RepeaterVizualizacionesAreas" runat="server" OnItemDataBound="RepeaterVizualizacionesAreas_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="form-check form-switch ps-0">

                                            <label><%#Eval("Nombres") %></label>
                                            <asp:Label Text='<%#Eval("Id") %>' runat="server" id="LabId"/>
                                            <asp:CheckBox runat="server" ID="ChekVizualizadoPor" Style="margin-left: 25px !important" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <hr />
                <div class="col">
                    <br />
                    <asp:Button ID="BtnGuardarMenu" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm mb-0" OnClick="BtnGuardarMenu_Click" />
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card" runat="server" id="DivTabalaMenu">
        <div class="card-header"><b>Configuracion Menu</b></div>
        <div class="card-body">
            <div class="row">
                <div class="table-responsive">
                    <asp:Repeater ID="RepterMenuOperaciones" runat="server">

                        <HeaderTemplate>
                            <table class="table align-items-center mb-0">
                                <thead>
                                    <tr>
                                        <th scope="col">Operacion</th>
                                        <th scope="col">Tipo</th>
                                        <th scope="col">Estado</th>
                                        <th scope="col">Fecha Creacion</th>
                                        <th scope="col">Fecha Actualizacion</th>
                                        <th scope="col">Usuario</th>
                                        <th scope="col">Area</th>
                                        <th scope="col" style="text-align: center;" colspan="2">X</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>

                        <ItemTemplate>

                            <tr>
                                <td>
                                    <asp:Label ID="LabIdReporte" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                    <asp:Label ID="LabNombreCompleto" runat="server" Text='<%#Eval("Operacion") %>'></asp:Label>
                                    <asp:TextBox ID="TxtNombreCompleto" runat="server" Text='<%#Eval("Operacion") %>' class="form-control" Visible="false"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:Label ID="LabTipoReporte" runat="server" Text='<%#Eval("Pefil") %>'></asp:Label>
                                    <asp:Label ID="LabIdTipoReporteAnterior" runat="server" Text='<%#Eval("IdPerfil") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="DropCambioTipoReporte" class="form-control" runat="server" Visible="false">
                                        <Items>
                                            <asp:ListItem Text="(Seleccionar)" Value="0" />
                                        </Items>
                                    </asp:DropDownList>
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
                                <td class="text-center">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("FechaActualizacion", "{0:dd/M/yyyy}") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LabCreadoPor" runat="server" Text='<%#Eval("CreadoPor") %>'></asp:Label>
                                </td>


                                <td>
                                    <asp:Label ID="LabActualizadoPor" runat="server" Text='<%#Eval("ActualizadoPor") %>' />
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="LabArea" runat="server" Text='<%#Eval("IdArea") %>' />
                                    <asp:Label ID="LabIdAreaAnterior" runat="server" Text='<%#Eval("IdArea") %>' Visible="false" />
                                    <asp:DropDownList ID="DropCambioArea" class="form-control" runat="server" Visible="false">
                                        <Items>
                                            <asp:ListItem Text="(Seleccionar)" Value="0" />
                                        </Items>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <div class="text-center">
                                        <%--<asp:LinkButton ID="LnkEditar" Text="Editar" runat="server" OnClick="OnEdit" CssClass="btn btn-secondary" />--%>
                                        <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizar_Click" Visible="true" />
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
    </div>
</asp:Content>
