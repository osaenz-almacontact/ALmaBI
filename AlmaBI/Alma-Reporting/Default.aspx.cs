using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alma_Reporting
{
    public partial class _Default : Page
    {
        LoginContexto contextoUsuarios = new LoginContexto();
        SolicitudesContexto contextoSolicitudes = new SolicitudesContexto();


        string Perfil = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Nombres"] != null)
                {
                    Perfil = Session["Perfil"].ToString();

                    ObtenerContadores();
                    ObtenerPermisos();
                }
                else
                {
                    Response.Redirect("~/Login/Login.aspx");
                }
            }
            
        }

        public void ObtenerContadores()
        {
            List<Usuarios> ListUsuarios = contextoUsuarios.ObtenerUsuarios();
            List<Solicitudes> ListSolicitudes = contextoSolicitudes.ObtenerSolicitudes();

            var queryUsuarios = (from Usuario in ListUsuarios
                        select new
                        {
                            IdUsuario = Usuario.Id,
                            Nombres = Usuario.Nombres,
                            EstadoUsuario = Usuario.IdEstado,
                        }).ToList();

            LabContUsuariosActivos.Text = queryUsuarios.Where(es => es.EstadoUsuario == 1).Count().ToString();
            LabCountUsuariosInactivos.Text = queryUsuarios.Where(es => es.EstadoUsuario == 2).Count().ToString();

            var querySolicitudes = (from solicitud in ListSolicitudes
                                 select new
                                 {
                                     IdSolicitud = solicitud.Id,
                                     EstadoSolicitud = solicitud.Estado
                                 }).ToList();

            LabCountSolicitudesPendientes.Text = querySolicitudes.Where(es => es.EstadoSolicitud == 1).Count().ToString();
            LabCountSolicitudesRespondidas.Text= querySolicitudes.Where(es => es.EstadoSolicitud == 2).Count().ToString();
        }

        public void ObtenerPermisos()
        {
                        
            if (Perfil == "Administrador")
            {
                PnlAdminnistracion.Visible = true;
            }
            else if (Perfil == "Gerente")
            {
                PnlAdminnistracion.Visible = false;
            }
            else if (Perfil == "Gestor de reportes")
            {
                PnlAdminnistracion.Visible = true;
            }
            else if (Perfil == "Visualizador")
            {
                PnlAdminnistracion.Visible = false;
            }

        }
    }
}