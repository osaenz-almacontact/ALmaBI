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
    public partial class Personalizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DivAlert.Visible = false;
            if (!IsPostBack)
            {
                if (Session["Nombres"] != null)
                {
                    ObternerAreas();
                    ObternerCargos();
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
                Formulario = "Personalizacion",
                Accion = Accion,
                Fecha = DateTime.Now,
                IdUsuario = int.Parse(Session["IdUsuario"].ToString())
            };
            contextoUsuario.GuardarLog(modelo);

        }

        public void ObternerAreas()
        {
            AreaContexto contextoArea = new AreaContexto();
            List<Areas> ListAreas = contextoArea.ObtenerAreas();

            var query = (from Area in ListAreas
                         select new
                         {
                             Id = Area.Id,
                             Nombres = Area.Nombre,
                             Estado = Area.Estado
                         }).ToList();


            RepterAreas.DataSource = query.ToList();
            RepterAreas.DataBind();
        }

        public int ObternerArea(string NombreArea)
        {
            AreaContexto contextoArea = new AreaContexto();
            List<Areas> ListAreas = contextoArea.ObtenerAreas();

            int count = 0;

            var query = (from Area in ListAreas
                         select new
                         {
                             Id = Area.Id,
                             Nombres = Area.Nombre.Trim(),
                             Estado = Area.Estado
                         }).ToList();


            count = query.Where(nom => nom.Nombres==NombreArea).Count();
            return count;
        }

        public void ObternerCargos()
        {
            CargoContexto contextoCargo = new CargoContexto();
            List<Cargos> ListCargos = contextoCargo.ObtenerCargos();

            var query = (from Cargo in ListCargos
                         select new
                         {
                             Id = Cargo.Id,
                             Nombres = Cargo.Nombre.Trim(),
                             Estado = Cargo.Estado
                         }).ToList();


            RepterCargos.DataSource = query.ToList();
            RepterCargos.DataBind();
        }

        public int ObternerCargo(string NombreCargo)
        {
            CargoContexto contextoCargo = new CargoContexto();
            List<Cargos> ListCargo = contextoCargo.ObtenerCargos();

            int count = 0;

            var query = (from Cargo in ListCargo
                         select new
                         {
                             Id = Cargo.Id,
                             Nombres = Cargo.Nombre.Trim(),
                             Estado = Cargo.Estado
                         }).ToList();


            count = query.Where(nom => nom.Nombres == NombreCargo).Count();
            return count;
        }
        protected void BtnGuardarArea_Click(object sender, EventArgs e)
        {
            try
            {
                AreaContexto contextoArea = new AreaContexto();

                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                string NombreArea = (item.FindControl("TxtNombreNuevaArea") as TextBox).Text.Trim();
                
                if(ObternerArea(NombreArea)==0)
                {
                    Areas modelo = new Areas()
                    {
                        Nombre = NombreArea,
                        Estado = 1,
                    };
                    contextoArea.GuardarArea(modelo);

                    ObternerAreas();

                    DivAlert.Visible = true;
                    DivAlert.Attributes.Add("class", "alert alert-success");
                    LabMensajeAlerta.Text = "Area agregada exitosamente.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                }
                else
                {
                    DivAlert.Visible = true;
                    DivAlert.Attributes.Add("class", "alert alert-danger");
                    LabMensajeAlerta.Text = "Area ya existe.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                }

                
            }
            catch (Exception ex)
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

        protected void BtnEliminarArea_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int IdArea = int.Parse((item.FindControl("LabIdArea") as Label).Text);

            AreaContexto contextoArea = new AreaContexto();
            try
            {
                contextoArea.ElimiarArea(IdArea);

                ObternerAreas();

                GuardarLog("Eliminacion de Area: " + Session["Nombres"].ToString());

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Area eliminada exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
            catch (Exception ex)
            {
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
            }
        }

        protected void BtnActualizarArea_Click(object sender, EventArgs e)
        {
            AreaContexto contextoArea = new AreaContexto();
            try
            {
                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdArea") as Label).Text);
                string Nombre = (item.FindControl("TxtArea") as TextBox).Text.Trim();
                int Estado = (item.FindControl("ChkEstado") as CheckBox).Checked ? 1 : 0;

                Areas modelo = new Areas()
                {
                    Id = Id,
                    Nombre = Nombre,
                    Estado = Estado
                };
                contextoArea.ActualizarArea(modelo);

                GuardarLog("Actualizacion de Area: ");

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Area actualizada exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                ObternerAreas();
            }
            catch (Exception ex)
            {
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
        }

        protected void BtnGuardarCargo_Click(object sender, EventArgs e)
        {
            try
            {
                CargoContexto contextoCargo = new CargoContexto();

                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                string NombreCargo = (item.FindControl("TxtNombreNuevaCargo") as TextBox).Text.Trim();

                if(ObternerCargo(NombreCargo)==0)
                {
                    Cargos modelo = new Cargos()
                    {
                        Nombre = NombreCargo,
                        Estado = 1,
                    };
                    contextoCargo.GuardarCargo(modelo);

                    ObternerCargos();

                    DivAlert.Visible = true;
                    DivAlert.Attributes.Add("class", "alert alert-success");
                    LabMensajeAlerta.Text = "Area agregada exitosamente.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                }
                else
                {
                    DivAlert.Visible = true;
                    DivAlert.Attributes.Add("class", "alert alert-danger");
                    LabMensajeAlerta.Text = "Cargo ya existe.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                }
            }
            catch (Exception ex)
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

        protected void BtnEliminarCargo_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int IdCargo = int.Parse((item.FindControl("LabIdCargo") as Label).Text);

            CargoContexto contextoCargo = new CargoContexto();
            try
            {
                contextoCargo.ElimiarCargo(IdCargo);

                ObternerAreas();

                GuardarLog("Eliminacion de Cargo: " + Session["Nombres"].ToString());

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Cargo eliminado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
            catch (Exception ex)
            {
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
            }
        }

        protected void BtnActualizarCargo_Click(object sender, EventArgs e)
        {
            CargoContexto contextoCargo = new CargoContexto();
            try
            {
                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdCargo") as Label).Text);
                string Nombre = (item.FindControl("TxtCargo") as TextBox).Text.Trim();
                int Estado = (item.FindControl("ChkEstadoCargo") as CheckBox).Checked ? 1 : 0;

                Cargos  modelo = new Cargos()
                {
                    Id = Id,
                    Nombre = Nombre,
                    Estado = Estado
                };
                contextoCargo.ActualizarCargo(modelo);

                GuardarLog("Actualizacion de Cargo: ");

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Cargo actualizado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                ObternerCargos();
            }
            catch (Exception ex)
            {
                DivAlert.Visible = true;
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
            item.FindControl("LnkEditarArea").Visible = !isEdit;
            item.FindControl("BtnActualizarArea").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabNombreArea").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("TxtArea").Visible = isEdit; ;
        }

        protected void OnEditCargo(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElementsCargo(item, true);
        }
        private void ToggleElementsCargo(RepeaterItem item, bool isEdit)
        {
            //Buttons
            item.FindControl("LnkEditarCargo").Visible = !isEdit;
            item.FindControl("BtnActualizarCargo").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabNombreCargo").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("TxtCargo").Visible = isEdit; ;
        }
    }
}