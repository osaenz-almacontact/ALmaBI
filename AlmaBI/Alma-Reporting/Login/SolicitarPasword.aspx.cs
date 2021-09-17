using Alma_Reporting.Crypto;
using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alma_Reporting.Login
{
    public partial class SolicitarPasword : System.Web.UI.Page
    {
        static SolicitudesContexto contextoSolicitudes = new SolicitudesContexto();
        static LoginContexto contextoUsuario = new LoginContexto();

        List<Solicitudes> ListSolicitudes = contextoSolicitudes.ObtenerSolicitudes();
        List<Usuarios> ListUsuarios = contextoUsuario.ObtenerUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerUsuario() > 0)
                {
                    if (ObtenerSolicitud() == 0)
                    {
                        Solicitudes modelo = new Solicitudes()
                        {
                            CorreoSolicitante = TxtUsuario.Text.Trim(),
                            Fecha = DateTime.Now,
                            Estado = 1
                        };
                        contextoSolicitudes.GuardarSolicitud(modelo);

                        TxtUsuario.Text = "";

                        pnl_Mensaje.Visible = true;
                        LblMensaje.Text = "Solicitud enviada.";
                    }
                }
                else
                {
                    pnl_Mensaje.Visible = true;
                    LblMensaje.Text = "Solicitud enviada.";
                }
            }
            catch (Exception ex)
            {
                bool tipoExcepcion = ex.ToString().Contains("Cannot insert duplicate key in object");
                //throw ex;
                pnl_Mensaje.Visible = true;
                
                LblMensaje.Text = ex.ToString();
                
            }
        }

        private int ObtenerUsuario()
        {
            int count = 0;
            var query = (from Usuario in ListUsuarios
                         select new
                         {
                             Usuario = Usuario.Usuario,
                             Estado = Usuario.IdEstado
                         }).Where(es => es.Estado == 1).Where(usu => usu.Usuario == TxtUsuario.Text.Trim()).ToList();

            count = query.Count();
            return count;
        }

        private int ObtenerSolicitud()
        {
            int count = 0;
            var query = (from Solicitud in ListSolicitudes
                         select new
                         {
                             correo = Solicitud.CorreoSolicitante,
                             estado = Solicitud.Estado
                         }).ToList();

            count = query.Where(email => email.correo == TxtUsuario.Text.Trim()).Where(es=>es.estado==1).Count();
            return count;
        }
    }
}