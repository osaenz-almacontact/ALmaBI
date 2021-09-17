<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personalizacion.aspx.cs" Inherits="Alma_Reporting.ReportesForms.Personalizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="alert alert-primary" role="alert" runat="server" id="DivAlert">
        <asp:Label Text="text" runat="server" ID="LabMensajeAlerta" />
        <button type="button" class="btn-close align-items-center" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="card" runat="server" id="DivAreas">
        <div class="card-header"><b>Administrar Area</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterAreas" runat="server">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col" style="text-align: center;" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdArea" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabNombreArea" runat="server" Text='<%#Eval("Nombres") %>'></asp:Label>
                                <asp:TextBox ID="TxtArea" runat="server" Text='<%#Eval("Nombres") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <asp:CheckBox runat="server" ID="ChkEstado" CssClass="form-check-input ms-auto" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChkEstadoActualizado" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:LinkButton ID="LnkEditarArea" Text="Editar" runat="server" OnClick="OnEdit" CssClass="btn btn-secondary" />
                                    <asp:Button ID="BtnActualizarArea" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizarArea_Click" Visible="false" />
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:Button ID="BtnEliminarArea" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminarArea_Click" />
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="TxtNombreNuevaArea" runat="server" Text="" class="form-control" ></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <div class="text-center">
                                        <asp:Button ID="BtnGuardarArea" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardarArea_Click" />
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

    <hr />

    <div class="card" runat="server" id="DivCargo">
        <div class="card-header"><b>Administrar Cargo</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterCargos" runat="server">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col" style="text-align: center;" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdCargo" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabNombreCargo" runat="server" Text='<%#Eval("Nombres") %>'></asp:Label>
                                <asp:TextBox ID="TxtCargo" runat="server" Text='<%#Eval("Nombres") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <asp:CheckBox runat="server" ID="ChkEstadoCargo" CssClass="form-check-input ms-auto" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChkEstadoActualizadoCargo" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:LinkButton ID="LnkEditarCargo" Text="Editar" runat="server" OnClick="OnEditCargo" CssClass="btn btn-secondary" />
                                    <asp:Button ID="BtnActualizarCargo" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizarCargo_Click" Visible="false" />
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:Button ID="BtnEliminarCargo" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminarCargo_Click" />
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="TxtNombreNuevaCargo" runat="server" Text="" class="form-control" ></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <div class="text-center">
                                        <asp:Button ID="BtnGuardarCargo" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardarCargo_Click" />
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
