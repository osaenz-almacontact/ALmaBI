<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Alma_Reporting._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="PnlAdminnistracion" runat="server" Visible="true">

        <div class="row">
            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                <div class="card">
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-8">
                                <div class="numbers">
                                    <p class="text-sm mb-0 text-capitalize font-weight-bold"><a href="GestionDeUsuarios/AdministracionDeUsuarios.aspx" style="color:#67748e">Usuarios activos.</a></p>
                                    <h5 class="font-weight-bolder mb-0">
                                        <asp:Label Text="" runat="server" ID="LabContUsuariosActivos" />
                                    </h5>
                                </div>
                            </div>
                            <div class="col-4 text-end">
                                <div class="icon icon-shape bg-gradient-info shadow text-center border-radius-md">
                                    <i class="" aria-hidden="true"><img   src="Content/img/Iconos/Usr_Activo.png" style="width:25px; height:25px" /></i>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                <div class="card">
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-8">
                                <div class="numbers">
                                    <p class="text-sm mb-0 text-capitalize font-weight-bold">Usuarios inactivos.</p>
                                    <h5 class="font-weight-bolder mb-0">
                                        <asp:Label Text="" runat="server" ID="LabCountUsuariosInactivos" />
                                    </h5>
                                </div>
                            </div>
                            <div class="col-4 text-end">
                                <div class="icon icon-shape bg-gradient-info shadow text-center border-radius-md">
                                    <i class=""  aria-hidden="true"><img  src="Content/img/Iconos/Usr_Inactivo.png" style="width:25px; height:25px" /></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                <div class="card">
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-8">
                                <div class="numbers">
                                    <p class="text-sm mb-0 text-capitalize font-weight-bold"><a href="GestionDeUsuarios/ActivacionDeUsuarios.aspx" style="color:#67748e">Solicitudes pendientes.</a> </p>
                                    <h5 class="font-weight-bolder mb-0">
                                        <asp:Label Text="" runat="server" ID="LabCountSolicitudesPendientes" />
                                    </h5>
                                </div>
                            </div>
                            <div class="col-4 text-end">
                                <div class="icon icon-shape bg-gradient-info shadow text-center border-radius-md">
                                    <i class=""  aria-hidden="true"><img  src="Content/img/Iconos/Sol_Pend.png" style="width:25px; height:25px" /></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-sm-6">
                <div class="card">
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-8">
                                <div class="numbers">
                                    <p class="text-sm mb-0 text-capitalize font-weight-bold">Solicitudes respondidas.</p>
                                    <h5 class="font-weight-bolder mb-0">
                                        <asp:Label Text="" runat="server" ID="LabCountSolicitudesRespondidas" />
                                    </h5>
                                </div>
                            </div>
                            <div class="col-4 text-end">
                                <div class="icon icon-shape bg-gradient-info shadow text-center border-radius-md">
                                    <i class=""  aria-hidden="true"><img  src="Content/img/Iconos/Sol_Resp.png" style="width:25px; height:25px" /></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server">
        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="page-header section-height-75 m-3 border-radius-xl" style="background-image: url('Content/img/Carrusel/Carrusel1.png');">
                        
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 my-auto">
                                    <img src="Content/img/logos/AlmaBI.png" />
                                    <p class="lead text-white opacity-8 fadeIn3 fadeInBottom">es una solución completa de inteligencia de negocios,  la cual comprende no solo un modelo de presentación amigable y preciso, sino también un enfoque integral de modelamiento de datos que permite estructurar toda la información de sus procesos de negocio para tenerla de una forma  sencilla, confiable y oportuna, de tal forma  que  facilite el modelo de toma de decisiones en cualquier proceso de empresa, independiente del tamaño de la misma.</p>
                                    <p class="lead text-white opacity-8 fadeIn3 fadeInBottom">Nuestros servicios de BI se  basan en ayudar a los clientes a recopilar, ordenar, almacenar y analizar datos de cualquier proceso que requiera medirse, garantizando siempre una asesoría completa en el manejo de los indicadores correctos, para mantener un control end to end.</p>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="carousel-item">
                    <div class="page-header section-height-75 m-3 border-radius-xl" style="background-image: url('Content/img/Carrusel/Carrusel2.png');">
                        <%--<span class="mask bg-gradient-dark"></span>--%>
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 my-auto">
                                    <img src="Content/img/logos/AlmaBI.png" />
                                    <p class="lead text-white opacity-8 fadeIn3 fadeInBottom">combina las herramientas de última generación con un profundo conocimiento del modelamiento de procesos, facilitando así la integración de cualquier sistema, tipo de proceso y datos asociados, al modelo de trabajo.</p>
                                </div>
                                <div class="col-lg-6 my-auto">
                                    <img src="Content/img/illustrations/Descripción8.png" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="carousel-item">
                    <div class="page-header section-height-75 m-3 border-radius-xl" style="background-image: url('Content/img/Carrusel/Carrusel3.png');">
                        <%--<span class="mask bg-gradient-dark"></span>--%>
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 my-auto">
                                    <img src="Content/img/logos/AlmaBI.png" />
                                    <h1 class="text-white fadeIn2 fadeInBottom">Transforma tus datos en respuestas</h1> 
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="section-height-75 position-absolute w-100 top-0">
                <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon position-absolute bottom-50" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-bs-slide="next">
                    <span class="carousel-control-next-icon position-absolute bottom-50" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </a>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
