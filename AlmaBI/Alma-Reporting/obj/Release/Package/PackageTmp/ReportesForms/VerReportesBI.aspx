<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerReportesBI.aspx.cs" Inherits="Alma_Reporting.ReportesForms.VerReportesBI" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">--%>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="/AlmaBI/Scripts/jquery/jquery.js"></script>
    <style>
        .resizable-iframe {
            overflow: visible;
            height: auto;
            width: auto;
            position: relative;
        }

            .resizable-iframe iframe {
                /* position: relative;
                z-index: -1;*/
            }

        .iframe-cover {
            position: absolute;
            z-index: 99999;
            background: #EAEAEA;
        }

        /*scroller*/
        .btn-header-links {
            padding-top: 5px;
            padding-bottom: 15px;
            overflow-x: scroll;
            display: inline-block;
            white-space: nowrap;
            transition: 1s ease;
        }

        .padding-align {
            padding-left: 4em !important;
            padding-right: 4em !important;
        }

        .top-adjust {
            top: 1.4em;
        }

        .btn-header-links button {
            border-radius: 8px;
        }


        /*scroller parent style*/

        .scroller {
            position: relative;
            overflow: hidden;
            margin-top: -0.5%;
        }


        /*left arrow styles*/
        .left-btn-scroller {
            position: absolute;
            left: 0%;
            top: 0.6em;
            font-size: 22px;
            color: #3f3f3f;
            bottom: 0;
            width: 55px;
            height: 55px;
            background-color: rgba(242, 242, 242, 0.94);
            z-index: 1002;
            border-radius: 50%;
            -webkit-box-shadow: 0 2px 5px 0 rgba(0, 0, 0, .16), 0 2px 10px 0 rgba(0, 0, 0, .12);
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, .16), 0 2px 10px 0 rgba(0, 0, 0, .12);
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
        }


        /*right arrow styles*/
        .right-btn-scroller {
            position: absolute;
            right: 0%;
            top: 0.6em;
            font-size: 22px;
            color: #3f3f3f;
            bottom: 0;
            width: 55px;
            cursor: pointer;
            height: 55px;
            background-color: rgba(242, 242, 242, 0.94);
            border-radius: 50%;
            z-index: 1002;
            -webkit-box-shadow: 0 2px 5px 0 rgba(0, 0, 0, .16), 0 2px 10px 0 rgba(0, 0, 0, .12);
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, .16), 0 2px 10px 0 rgba(0, 0, 0, .12);
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .opacity-0 {
            opacity: 0;
        }

        .col-lg-12 {
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            position: relative;
            width: 100%;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }
        /*mobile responsive*/
        @media (max-width: 275.98px) {

            .padding-align {
                padding: 0 !important;
            }

            .top-adjust {
                top: 3%;
            }

            .left-btn-scroller {
                display: none;
            }

            .right-btn-scroller {
                display: none;
            }
        }
    </style>
    <%--<div class="sidenav-footer mx-3 mt-3 pt-3">
      <div class="card card-background shadow-none " id="sidenavCard">
        <div class="full-background" runat="server" Id="DivBanner" ></div>
        <div class="card-body text-left p-3 w-100" style="height:150px">
        </div>
      </div>
    </div>--%>
    <div class="page-header min-height-100 border-radius-xl mt-4" runat="server" id="DivBanner" style="background-position-y: 50%; margin-top: 0px !important">
        <span class="mask bg-gradient-secondary opacity-0"></span>
    </div>
    <div class="card card-body blur shadow-blur mx-4 mt-n6">
        <div class="row gx-2">
            <div class="col-auto my-auto">
                <div class="h-100">
                    <h5 class="mb-1">
                        <asp:Label Text="text" runat="server" ID="IdNombreOperacion" Visible="false" />
                    </h5>
                </div>
            </div>
            <div class="col-lg-12 no-pad scroller">
                <div class="left-btn-scroller left-scroll ">
                    <i class="fas fa-chevron-left"></i>
                </div>
                <div class="right-btn-scroller right-scroll ">
                    <i class="fas fa-chevron-right"></i>
                </div>


                <asp:Repeater ID="RepterMenuReportesUsuario" runat="server">
                    <HeaderTemplate>
                        <div class="col-lg-12 no-pad btn-header-links padding-align top-adjust" id="scroll-div">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="LabIdReporte" Visible="false" />
                        <asp:Button Text='<%#Eval("Nombres") %>' runat="server" class="btn btn-outline-primary mb-0 px-6 py-2" OnClick="Unnamed_Click" />
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>


            </div>
        </div>
    </div>

    <br />
    <br />

    <div class="container-fluid">
        <div class="embed-responsive">
            <div class="resizable-iframe">
                <div style="height: 45px; width: 150px; bottom: 0px; right: 0px" class="iframe-cover"></div>
                <iframe class="col-lg-12 col-md-12 col-sm-12 embed-responsive-item" runat="server" id="IframeReporte" src="" style="height: 600px"></iframe>
            </div>
            <div class="row">
                <asp:PlaceHolder ID="iframeDiv" runat="server"/>
            </div>
        </div>
    </div>

    <script>
        $(function () {
            //pin scrooler
            $('.left-scroll').click(function (e) {
                e.preventDefault();
                var container = document.getElementById('scroll-div');
                sideScroll(container, 'left', 25, 100, 10);
            });
            $('.right-scroll').click(function (e) {
                e.preventDefault();
                var container = document.getElementById('scroll-div');
                sideScroll(container, 'right', 25, 100, 10);
            })

        })


        function sideScroll(element, direction, speed, distance, step) {
            scrollAmount = 0;


            var slideTimer = setInterval(function () {
                if (direction == 'left') {
                    element.scrollLeft -= step;

                } else {
                    element.scrollLeft += step;


                }
                scrollAmount += step;
                if (scrollAmount >= distance) {
                    window.clearInterval(slideTimer);
                }


            }, speed);
        }

    </script>

</asp:Content>
