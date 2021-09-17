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
    public partial class AdministracionDeGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DivAlert.Visible = false;
            if (!IsPostBack)
            {
                if (Session["Nombres"] != null)
                {
                    ObternerGrupos();
                    GuardarLog("Ingreso al formulario");
                }
                else
                {
                    Response.Redirect("../Login/Login");
                }
            }
            
        }

        public void GuardarLog(string Accion)
        {
            LoginContexto contextoUsuario = new LoginContexto();

            Logs modelo = new Logs()
            {
                Formulario = "AdministracionDeGrupos",
                Accion = Accion,
                Fecha = DateTime.Now,
                IdUsuario = int.Parse(Session["IdUsuario"].ToString())
            };
            contextoUsuario.GuardarLog(modelo);

        }


        public void ObternerGrupos()
        {
            GrupoContexto contextoGrupo = new GrupoContexto();
            List<Grupos> ListGrupos = contextoGrupo.ObtenerGrupos();

            var query = (from Grupo in ListGrupos
                         select new
                         {
                             Id = Grupo.Id,
                             Nombres = Grupo.Nombre,
                             CreadoPor = Grupo.CreadoPor,
                             FechaCreacion = Grupo.FechaCreacion,
                             Estado = Grupo.IdEstado
                         }).ToList();


            RepterGrupos.DataSource = query.ToList();
            RepterGrupos.DataBind();
        }

        protected void RepeaterGRupos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GrupoContexto contextoGrupo = new GrupoContexto();

                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                string NombreGrupo = (item.FindControl("TxtNombreNuevoGrupo") as TextBox).Text.Trim();

                Grupos modelo = new Grupos()
                {
                    Nombre = NombreGrupo,
                    CreadoPor = Session["Nombres"].ToString(),
                    FechaCreacion = DateTime.Now,
                    IdEstado = 1,
                };
                contextoGrupo.GuardarGrupo(modelo);

                ObternerGrupos();

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Grupo agregado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
            catch(Exception ex)
            {
                bool tipoExcepcion = ex.ToString().Contains("Cannot insert duplicate key in object");
                //throw ex;
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                if (tipoExcepcion)
                {
                    LabMensajeAlerta.Text = "El nombre del grupo ya ha sido ingresado";
                }
                else
                {
                    LabMensajeAlerta.Text = ex.ToString();
                }
            }
        }

        public void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int IdGrupo = int.Parse((item.FindControl("LabIdGrupo") as Label).Text);
            string Grupo = (item.FindControl("LabNombreGrupo") as Label).Text;

            GrupoContexto contextoGrupo = new GrupoContexto();
            ReporteContexto contextoReporte = new ReporteContexto();
            MenuContexto contextoMenu = new MenuContexto();
            try
            {
                contextoMenu.EliminarMenuPorGrupo(Grupo);
                contextoReporte.EliminarReportesPorGrupo(IdGrupo);
                contextoGrupo.ElimuarGrupo(IdGrupo);

                ObternerGrupos();

                GuardarLog("Eliminacion de grupo: " + Session["Nombres"].ToString());

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Grupo eliminado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
            catch (Exception ex)
            {
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            GrupoContexto contextoGrupo = new GrupoContexto();
            try
            {
                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdGrupo") as Label).Text);
                string Nombre = (item.FindControl("TxtGrupo") as TextBox).Text.Trim();
                int Estado = (item.FindControl("ChkEstado") as CheckBox).Checked ? 1 : 0;

                Grupos modelo = new Grupos()
                {
                    Id = Id,
                    Nombre = Nombre,
                    IdEstado = Estado
                };
                contextoGrupo.ActualizarGrupo(modelo);

                GuardarLog("Actualizacion de Grupo: ");

                DivAlert.Attributes.Add("style", "display:block");
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Grupo actualizado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                ObternerGrupos();
            }
            catch (Exception ex)
            {
                DivAlert.Attributes.Add("style", "display:block");
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Buttons
            item.FindControl("LnkEditar").Visible = !isEdit;
            item.FindControl("BtnActualizar").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabNombreGrupo").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("TxtGrupo").Visible = isEdit;;
        }
    }
}