<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionDeGrupos.aspx.cs" Inherits="Alma_Reporting.ReportesForms.AdministracionDeGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="alert alert-primary" role="alert" runat="server" id="DivAlert">
        <asp:Label Text="text" runat="server" ID="LabMensajeAlerta" />
        <button type="button" class="btn-close align-items-center" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="card" runat="server" id="DivGrupos">
        <div class="card-header"><b>Administrar grupos</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterGrupos" runat="server">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Creado Por</th>
                                    <th scope="col">Fecha Creacion</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col" style="text-align: center;" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdGrupo" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabNombreGrupo" runat="server" Text='<%#Eval("Nombres") %>'></asp:Label>
                                <asp:TextBox ID="TxtGrupo" runat="server" Text='<%#Eval("Nombres") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabCreadoPor" runat="server" Text='<%#Eval("CreadoPor") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabFechaCreacion" runat="server" Text='<%#Eval("FechaCreacion", "{0:dd/M/yyyy}") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <asp:CheckBox runat="server" ID="ChkEstado" CssClass="form-check-input ms-auto" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChkEstadoActualizado" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
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
                        <tfoot>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="TxtNombreNuevoGrupo" runat="server" Text="" class="form-control" ></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <div class="text-center">
                                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardar_Click" />
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                        </table>  
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
