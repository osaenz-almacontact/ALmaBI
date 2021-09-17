<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActivacionDeUsuarios.aspx.cs" Inherits="Alma_Reporting.GestionDeUsuarios.ActivacionDeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="alert alert-primary" role="alert" runat="server" id="DivAlert" style="display: none">
        <asp:Label Text="text" runat="server" ID="LabMensajeAlerta" />
        <button type="button" class="btn-close align-items-center" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="card" runat="server" id="Div1">
        <div class="card-header"><b>Reactivar cuentas</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterSolicitudesPendientes" runat="server">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Correo Solicitante</th>
                                    <th scope="col">Nombres</th>
                                    <th scope="col">Fecha</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col" style="text-align: center;" >X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdSolicitud" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabCorreoSolicitante" runat="server" Text='<%#Eval("CorreoSolicitante") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabNombreSolicitante" runat="server" Text='<%#Eval("NombreSolicitante") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabFecha" runat="server" Text='<%#Eval("Fecha", "{0:dd/M/yyyy}") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <%--<input type="checkbox" id="ChkTipoUsuario" <%# Convert.ToBoolean(Eval("Acctivo")) ? "checked" : string.Empty %> />--%>
                                    <asp:CheckBox runat="server" ID="ChkCambioEstado" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" Style="margin-left: 25px !important" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChekEstado" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:Button ID="BtnActiivar" runat="server" Text="Enviar Contraseña" CssClass="btn btn-secondary" OnClick="BtnActiivar_Click"  />
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
    <br />
    <div class="card" runat="server" id="Div2">
        <div class="card-header"><b>Solicitudes respondias</b></div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:Repeater ID="RepterSolicitudesRespondidas" runat="server">
                    <HeaderTemplate>
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Correo Solicitante</th>
                                    <th scope="col">Nombres</th>
                                    <th scope="col">Fecha</th>
                                    <th scope="col">Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdSolicitud" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabCorreoSolicitante" runat="server" Text='<%#Eval("CorreoSolicitante") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabNombreSolicitante" runat="server" Text='<%#Eval("NombreSolicitante") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabFecha" runat="server" Text='<%#Eval("Fecha", "{0:dd/M/yyyy}") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="form-check form-switch ps-0">
                                    <%--<input type="checkbox" id="ChkTipoUsuario" <%# Convert.ToBoolean(Eval("Acctivo")) ? "checked" : string.Empty %> />--%>
                                    <asp:CheckBox runat="server" ID="ChkCambioEstado" Checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' Visible="false" Style="margin-left: 25px !important" />
                                    <input runat="server" class="form-check-input ms-auto" type="checkbox" id="ChekEstado" checked='<%# (Eval("Estado")).ToString() == "1" ? true : false %>' style="margin-left: 25px !important">
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


