using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alma_Reporting.ReportesForms
{
    public partial class VerReportesBI : System.Web.UI.Page
    {
        static OperacionContexto contextoOperaciones = new OperacionContexto();
        static ReporteContexto contextoReportes = new ReporteContexto();
        static LoginContexto contextoUsuario = new LoginContexto();
        static GrupoContexto contextoGrupo = new GrupoContexto();

        List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();
        List<Reportes> ListReportes = contextoReportes.ObtenerReportess();
        List<UsuarioReporte> ListUsuarioReporte = contextoUsuario.ObtenerUsuarioReportes();
        List<Grupos> ListGrupo = contextoGrupo.ObtenerGrupos();

        int IdArea;
        int IdUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdArea = Convert.ToInt32(Request.QueryString["Area"]);
            if (Session["Nombres"] != null)
            {
                IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            }
            else
            {
                Response.Redirect("../Login/Login");
            }
            if (!IsPostBack)
            {
                ObtenerBanner();
                ObtenerMenuReportes();
            }
        }

        public void GuardarLog(string Accion)
        {
            Logs modelo = new Logs()
            {
                Formulario = "VerReportesBI",
                Accion = Accion,
                Fecha = DateTime.Now,
                IdUsuario = IdUsuario
            };
            contextoUsuario.GuardarLog(modelo);

        }

        private void ObtenerMenuReportes()
        {
            var query = (from UsuarioReporte in ListUsuarioReporte
                         join Reporte in ListReportes on UsuarioReporte.IdReporte equals Reporte.Id
                         select new
                         {
                             Id = Reporte.Id,
                             Nombres = Reporte.Nombre,
                             Ubicacion = Reporte.Ubicacion,
                             Estado = Reporte.IdEstado,
                             IdUsuario = UsuarioReporte.IdUsuario,
                             IdArea = Reporte.IdGrupo
                         }).Where( ar => ar.IdArea == IdArea).Where(us => us.IdUsuario == IdUsuario).Where(e=>e.Estado==1).ToList();


            RepterMenuReportesUsuario.DataSource = query.ToList();
            RepterMenuReportesUsuario.DataBind();

            IdNombreOperacion.Text = query.Select(n => n.Nombres).FirstOrDefault();
        }

        public void ObtenerBanner()
        {
            string ruta="";
            try 
            {
                IdArea = Convert.ToInt32(Request.QueryString["Area"]);
                var query = (from Grupo in ListGrupo
                             select new
                             {
                                 Id = Grupo.Id,
                                 RutaBanner = Grupo.RutaBanner,
                                 Estado = Grupo.IdEstado
                             }).ToList();

                ruta = query.Where(gr => gr.Id == IdArea).Where(es => es.Estado == 1).Select(ru => ru.RutaBanner).FirstOrDefault().ToString();
                //DivBanner.Attributes.Add("background-image", ""+ ruta +"");
            }
            catch
            {
                ruta = "../assets/img/curved-images/curved0.jpg";
                DivBanner.Style["background-image"] = "" + ruta + "";
            }

            DivBanner.Style["background-image"] = "" + ruta + "";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {

                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdReporte") as Label).Text);
                IdArea = Convert.ToInt32(Request.QueryString["Area"]);

                var query = (from Reporte in ListReportes
                             join Grupo in ListGrupo on Reporte.IdGrupo equals Grupo.Id
                             select new
                             {
                                 Id = Reporte.Id,
                                 Nombres = Reporte.Nombre,
                                 Ubicacion = Reporte.Ubicacion,
                                 Estado = Reporte.IdEstado,
                                 IdOperacion = Grupo.Id,
                                 Operacion = Grupo.Nombre
                             }).Where(op => op.IdOperacion == IdArea).Where(es => es.Estado == 1).Where(id => id.Id == Id).FirstOrDefault();

                IframeReporte.Src = query.Ubicacion.ToString();
                if(IdUsuario== 3)
                {
                    iframeDiv.Controls.Add(new LiteralControl("<iframe src=\"" + query.Ubicacion.ToString() + "\"></iframe><br />"));
                    IframeReporte.Attributes.Add("src", query.Ubicacion.ToString());
                }
                
                GuardarLog("Visualización de reporte: " + query.Ubicacion.ToString());
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','" + ex.Message + "');", true);
            }
        }
    }
}