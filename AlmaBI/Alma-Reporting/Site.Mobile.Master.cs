using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Alma_Reporting
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        static MenuContexto contextoMenu = new MenuContexto();

        static OperacionContexto contextoOperaciones = new OperacionContexto();
        static LoginContexto contextoUsuarios = new LoginContexto();
        static AreaContexto contextoAreas = new AreaContexto();

        List<MenuOperaciones> ListMenu = contextoMenu.ObtenerMenuOperaciones();

        List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();
        List<Usuarios> ListUsuarios = contextoUsuarios.ObtenerUsuarios();
        List<Areas> ListAreas = contextoAreas.ObtenerAreas();

        int IdUsuario = 0;
        int IdPerfil = 0;
        int IdOperacion = 0;
        int IdArea = 0;
        string Operacion = "";
        string Perfil = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                else
                {
                    if (Session["Nombres"] != null)
                    {
                        IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                        LabNombres.Text = Session["Nombres"].ToString();
                        IdPerfil = int.Parse(Session["IdPerfil"].ToString());
                        //IdOperacion = int.Parse(Session["IdOperacion"].ToString());
                        Operacion = Session["Operacion"].ToString();
                        Perfil = Session["Perfil"].ToString();
                        IdArea = int.Parse(Session["IdArea"].ToString());

                        ObtenerMenuOperaciones();
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx");
                    }

                }
            }
        }

        public void ObtenerMenuOperaciones()
        {
            if (!IsPostBack)
            {
                var query = (from MenuOperacion in ListMenu
                             select new
                             {
                                 Id = MenuOperacion.Id,
                                 Url = MenuOperacion.Url,
                                 IdUsuario = MenuOperacion.IdUsuario,
                                 IdOperacion = MenuOperacion.IdOperacion,
                                 Operacion = MenuOperacion.Titulo,
                                 IdPerfil = MenuOperacion.IdUsuario,
                                 Estado = MenuOperacion.Estado,
                                 IdArea = MenuOperacion.IdArea
                             }).Where(est => est.Estado == 1).ToList();


                if (Perfil == "Administrador")
                {
                    RepterMenuOperaciones.DataSource = query.Where(usu => usu.IdUsuario == IdUsuario).ToList();
                    RepterMenuOperaciones.DataBind();
                }
                else if (Perfil == "Gerente")
                {
                    RepterMenuOperaciones.DataSource = query.Where(usu => usu.IdUsuario == IdUsuario).ToList();
                    RepterMenuOperaciones.DataBind();

                    LiOpcioneAdicionales.Visible = false;
                    LinkActivacionDeUsuarios.Visible = false;
                    LinkAdministracionDeUsuarios.Visible = false;
                    LinkConfiguracionMenu.Visible = false;

                    LiOpcionesReportes.Visible = false;
                    LinkAgregarReporte.Visible = false;
                }
                else if (Perfil == "Gestor de reportes")
                {
                    RepterMenuOperaciones.DataSource = query.Where(usu => usu.IdUsuario == IdUsuario).ToList();
                    RepterMenuOperaciones.DataBind();

                    LiOpcioneAdicionales.Visible = false;
                    LinkActivacionDeUsuarios.Visible = false;
                    LinkAdministracionDeUsuarios.Visible = false;
                }
                else if (Perfil == "Visualizador")
                {
                    RepterMenuOperaciones.DataSource = query.Where(usu => usu.IdUsuario == IdUsuario).ToList();
                    RepterMenuOperaciones.DataBind();

                    LiOpcioneAdicionales.Visible = false;
                    LinkActivacionDeUsuarios.Visible = false;
                    LinkAdministracionDeUsuarios.Visible = false;
                    LinkConfiguracionMenu.Visible = false;

                    LiOpcionesReportes.Visible = false;
                    LinkAgregarReporte.Visible = false;
                }

            }

        }


        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

            HttpContext.Current.Response.Redirect("~/Default.aspx", true);
        }

    }
}