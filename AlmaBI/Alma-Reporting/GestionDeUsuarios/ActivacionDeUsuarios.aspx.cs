using Alma_Reporting.Crypto;
using Alma_Reporting.Mail;
using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Alma_Reporting.GestionDeUsuarios
{
    public partial class ActivacionDeUsuarios : System.Web.UI.Page
    {
        static SolicitudesContexto contextoSolicitudes = new SolicitudesContexto();
        static LoginContexto contextoUsuarios = new LoginContexto();
        static LoginContexto contextoLog = new LoginContexto();

        List<Solicitudes> ListSolicitudes = contextoSolicitudes.ObtenerSolicitudes();
        List<Usuarios> ListUsuarios = contextoUsuarios.ObtenerUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Nombres"] != null)
                {
                    ObtenerSolicitudes();
                }
                else
                {
                    Response.Redirect("../Login/Login");
                }

            }
        }

        private void ObtenerSolicitudes()
        {
            SolicitudesContexto contextoSolicitudes = new SolicitudesContexto();
            LoginContexto contextoUsuarios = new LoginContexto();
            LoginContexto contextoLog = new LoginContexto();

            List<Solicitudes> ListSolicitudes = contextoSolicitudes.ObtenerSolicitudes();
            List<Usuarios> ListUsuarios = contextoUsuarios.ObtenerUsuarios();

            var query = (from Solicitud in ListSolicitudes
                         join Usuario in ListUsuarios on Solicitud.CorreoSolicitante equals Usuario.Usuario
                         select new
                         {
                             Id = Solicitud.Id,
                             CorreoSolicitante = Solicitud.CorreoSolicitante,
                             NombreSolicitante = Usuario.Nombres,
                             Fecha = Solicitud.Fecha,
                             Estado = Solicitud.Estado
                         }).ToList();


            RepterSolicitudesPendientes.DataSource = query.Where(es => es.Estado == 1).ToList();
            RepterSolicitudesPendientes.DataBind();

            RepterSolicitudesRespondidas.DataSource = query.Where(es => es.Estado == 2).ToList();
            RepterSolicitudesRespondidas.DataBind();
        }

        protected void BtnActiivar_Click(object sender, EventArgs e)
        {
            byte[] salt = Cryptographic.GenerateSalt();
            String html = "";
            var hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes("AlmaBI2021#"), salt);

            try
            {
                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdSolicitud") as Label).Text);
                string CorreoSolicitante = (item.FindControl("LabCorreoSolicitante") as Label).Text.Trim();
                string NombreSolicitante = (item.FindControl("LabNombreSolicitante") as Label).Text.Trim();

                Solicitudes modelo = new Solicitudes()
                {
                    Id = Id,
                    Estado = 2
                };
                contextoSolicitudes.ActualizarSolicitud(modelo);

                Usuarios modeloUsuario = new Usuarios()
                {
                    Usuario= CorreoSolicitante,
                    Salt = salt,
                    Password = hashedPassword,
                    IdEstado = 1
                };
                contextoUsuarios.ActualizarEstadoUsuario(modeloUsuario);


                html = "<div style='padding:15px;'>" +
                            "<p style='margin:10px 0px 10px 10px;font-family:century gothic;font-size:14px'><strong>Hola: </strong> " + NombreSolicitante.Trim() + "</p>" +
                            "<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Se ha realizado el restablecimiento de su contraseña.</ p>" +
                            "<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Por favor ingrese al link con las credenciales iniciales asignadas y a continuación registre una nueva contraseña para mayor seguridad. </p>" +
                            "<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Ingreso a la aplicación <a href='http://alma-bi.co/AlmaBI/Login/Login'>link</a></p>" +
                            //"<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Si presenta algún problema al ingresar a la encuesta pude ingresar en el siguiente <a href='http://alma-bi.co/AlmaBI/Login/Login'>link</a></p>" +
                            "<p style='margin:0px 0px 10px 50px;font-size:16px;color:#12679B'><strong>Recuerde sus datos:</strong></p>" +
                             "<p style='margin:0px 0px 10px 50px;font-size:16px;color:#12679B'><strong>Usuario : </strong><a style='color:#585964'>" + CorreoSolicitante.Trim() + "</a></p>" +
                             "<p style='margin:0px 0px 10px 50px;font-size:16px;color:#12679B'><strong>Contraseña : </strong><a style='color:#585964'>" + "AlmaBI2021#" + "</a></p></div>";
                html = BaseEmail.crearRetornarCuerpoCorreo("NUEVO USUARIO ASIGNADO ", html, "Almacontact", "");


                Email.EnviarEmail(CorreoSolicitante.Trim(), CorreoSolicitante.Trim(), "ALMA-BI", "ALMACONTACT - Creacion de usuario ", html);

                ObtenerSolicitudes();
                GuardarLog("Reenvia password usuario");

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Usuario creado exitosamente.";

            }
            catch (Exception ex)
            {
                bool tipoExcepcion = ex.ToString().Contains("Cannot insert duplicate key in object");
                //throw ex;
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                if (tipoExcepcion)
                {
                    LabMensajeAlerta.Text = "El nombre de usuario ya ha sido ingresado";
                }
                else
                {
                    LabMensajeAlerta.Text = ex.ToString();
                }


            }
        }

        public void GuardarLog(string Accion)
        {
            Logs modelo = new Logs()
            {
                Formulario = "AdministracionDeUsuarios",
                Accion = Accion,
                Fecha = DateTime.Now,
                IdUsuario = int.Parse(Session["IdUsuario"].ToString())
            };
            contextoUsuarios.GuardarLog(modelo);

        }
    }
}