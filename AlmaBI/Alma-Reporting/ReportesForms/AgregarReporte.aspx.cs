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
    public partial class AgregarReporte : System.Web.UI.Page
    {
        static OperacionContexto contextoOperaciones = new OperacionContexto();
        static TipoReporteContexto contextoTipoReportes = new TipoReporteContexto();
        static ReporteContexto contextoReportes = new ReporteContexto();
        static LoginContexto contextoUsuario = new LoginContexto();
        static AreaContexto contextoArea = new AreaContexto();
        static GrupoContexto contextoGrupo = new GrupoContexto();

        List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();
        List<TipoReporte> ListTipoReportes = contextoTipoReportes.ObtenerTipoReportes();
        List<Reportes> ListReportes = contextoReportes.ObtenerReportess();
        List<Usuarios> ListUsuarios = contextoUsuario.ObtenerUsuarios();
        List<Areas> ListArea = contextoArea.ObtenerAreas();
        List<Grupos> ListGrupos = contextoGrupo.ObtenerGrupos();

        int IdUsuario = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //DivAlert.Visible = false;
            if (!IsPostBack)
            {
                if (Session["Nombres"] != null)
                {
                    ObtenerGrupos();
                    ObtenerTiposReportes();
                    ObtenerReportes();
                    ObtenerUsuarios();
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
            if (!IsPostBack)
            {
                Logs modelo = new Logs()
                {
                    Formulario = "AdministracionDeUsuarios",
                    Accion = Accion,
                    Fecha = DateTime.Now,
                    IdUsuario = int.Parse(Session["IdUsuario"].ToString())
                };
                contextoUsuario.GuardarLog(modelo);
            }

        }

        public void ObtenerGrupos()
        {
            var query = (from Grupo in ListGrupos
                         select new
                         {
                             Id = Grupo.Id,
                             Nombres = Grupo.Nombre
                         }).ToList();

            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar...";

            DropGrupo.DataSource = query.ToList();
            DropGrupo.DataTextField = "Nombres";
            DropGrupo.DataValueField = "Id";
            DropGrupo.DataBind();
            DropGrupo.Items.Insert(0, item);
        }

        public void ObtenerTiposReportes()
        {
            var query = (from TipoReporte in ListTipoReportes
                         select new
                         {
                             Id = TipoReporte.Id,
                             Nombres = TipoReporte.Nombre
                         }).ToList();

            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar...";

            DropTipoReporte.DataSource = query.ToList();
            DropTipoReporte.DataTextField = "Nombres";
            DropTipoReporte.DataValueField = "Id";
            DropTipoReporte.DataBind();
            DropTipoReporte.Items.Insert(0, item);
        }

        protected void BtnGuardarReporte_Click(object sender, EventArgs e)
        {

            try
            {

                IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                int TipoAcceeso = 0;

                //string TipopAccesoCli = (ChekTipoVizualizacionCli.Checked == true) ? "1" : "0";
                //for (int i = 0; i < RepeaterVizualizaciones.Items.Count; i++)
                //{
                //    CheckBox chk = (CheckBox)RepeaterVizualizaciones.Items[i].FindControl("ChekVizualizadoPor");
                //    Label id = (Label)RepeaterVizualizaciones.Items[i].FindControl("LabId");

                //    if (chk.Checked)
                //    {
                //        Vizualizaciones += (id.Text + ",");
                //    }
                //    else
                //    {
                //        Vizualizaciones += ("0" + ",");
                //    }
                //}

                Reportes modelo = new Reportes()
                {
                    Nombre = TxtNombreCompleto.Text.Trim(),
                    IdTipo = int.Parse(DropTipoReporte.SelectedValue.Trim()),
                    Ubicacion = TxtUbicacion.Text.Trim(),
                    IdEstado = 1,
                    FechaCreacion = DateTime.Now,
                    IdUsuarioCarga = int.Parse(IdUsuario.ToString()),
                    IdGrupo = int.Parse(DropGrupo.SelectedValue.Trim()),
                    IdPerfil=TipoAcceeso
                };
                contextoReportes.GuardarReporte(modelo);

                VaciarCampos();
                ObtenerReportes();
                GuardarLog("Regitro de reporte: " + TxtNombreCompleto.Text.Trim());

                DivAlert.Attributes.Add("style", "display:block");
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Reporte creado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                ObtenerReportes();
            }
            catch (Exception ex)
            {
                //throw ex;
                DivAlert.Attributes.Add("style", "display:block");
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);

            }

        }

        private void ObtenerReportes()
        {
            TipoReporteContexto contextoTipoReportes = new TipoReporteContexto();
            ReporteContexto contextoReportes = new ReporteContexto();
            LoginContexto contextoUsuario = new LoginContexto();
            AreaContexto contextoArea = new AreaContexto();
            GrupoContexto contextoGrupo = new GrupoContexto();

            List<TipoReporte> ListTipoReportes = contextoTipoReportes.ObtenerTipoReportes();
            List<Reportes> ListReportes = contextoReportes.ObtenerReportess();
            List<Usuarios> ListUsuarios = contextoUsuario.ObtenerUsuarios();
            List<Areas> ListArea = contextoArea.ObtenerAreas();
            List<Grupos> ListGrupo = contextoGrupo.ObtenerGrupos();

            var query = (from Reporte in ListReportes
                         join TiposReporte in ListTipoReportes on Reporte.IdTipo equals TiposReporte.Id
                         join Grupo in ListGrupo on Reporte.IdGrupo equals Grupo.Id
                         select new
                         {
                             Id = Reporte.Id,
                             Nombres = Reporte.Nombre,
                             IdTipoReporte = TiposReporte.Id,
                             TipoReporte = TiposReporte.Nombre,
                             Ubicacion = Reporte.Ubicacion,
                             Estado = Reporte.IdEstado,
                             FechaCreacion = Reporte.FechaCreacion,
                             NombreUsuario = "P",
                             IdGrupo = Grupo.Id,
                             Grupo = Grupo.Nombre,
                             Perfil = Reporte.IdPerfil
                         }).ToList();

            //RepterReportes.DataSource = query.Where(t => t.IdTipoReporte== 1).ToList();
            RepterReportes.DataSource = query.ToList();
            RepterReportes.DataBind();
            query = null;
        }

        private void VaciarCampos()
        {
            TxtNombreCompleto.Text = "";
            TxtUbicacion.Text = "";
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdReporte") as Label).Text);
                string Nombre = (item.FindControl("TxtNombreCompleto") as TextBox).Text.Trim();
                int IdTipoReporte = int.Parse((item.FindControl("DropCambioTipoReporte") as DropDownList).SelectedValue) == 0 ? int.Parse((item.FindControl("LabIdTipoReporteAnterior") as Label).Text) : int.Parse((item.FindControl("DropCambioTipoReporte") as DropDownList).SelectedValue);
                string Ubicacion = (item.FindControl("TxtUbicacion") as TextBox).Text.Trim();
                int Estado = (item.FindControl("ChkCambioEstado") as CheckBox).Checked ? 1 : 0;
                int Grupo = int.Parse((item.FindControl("DropCambioGrupo") as DropDownList).SelectedValue) == 0 ? int.Parse((item.FindControl("LabIdGrupoAnterior") as Label).Text) : int.Parse((item.FindControl("DropCambioGrupo") as DropDownList).SelectedValue);


                Reportes modelo = new Reportes()
                {
                    Id = Id,
                    Nombre = Nombre,
                    IdTipo = IdTipoReporte,
                    Ubicacion = Ubicacion,
                    IdEstado = Estado,
                    IdGrupo = Grupo
                };
                contextoReportes.ActualizarReporte(modelo);
                GuardarLog("Actualizacion de reporte: " + TxtNombreCompleto.Text.Trim());

                DivAlert.Attributes.Add("style", "display:block");
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Reporte actualizado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
                ObtenerReportes();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','" + ex.Message + "');", true);
            }

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int IdReporte = int.Parse((item.FindControl("LabIdReporte") as Label).Text);

            contextoReportes.EliminarReporte(IdReporte);

            GuardarLog("Eliminacion de reporte: " + TxtNombreCompleto.Text.Trim());

            DivAlert.Attributes.Add("style", "display:block");
            DivAlert.Attributes.Add("class", "alert alert-success");
            LabMensajeAlerta.Text = "Reporte eliminado exitosamente.";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            ObtenerReportes();
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
            item.FindControl("LabNombreCompleto").Visible = !isEdit;
            item.FindControl("LabTipoReporte").Visible = !isEdit;
            item.FindControl("LabUbicacion").Visible = !isEdit;
            item.FindControl("LabGrupo").Visible = !isEdit;
            item.FindControl("ChekEstado").Visible = !isEdit;
            //item.FindControl("ChkCambioPerfil").Visible = !isEdit;


            //Toggle TextBoxes.
            item.FindControl("TxtNombreCompleto").Visible = isEdit;
            item.FindControl("DropCambioTipoReporte").Visible = isEdit;
            item.FindControl("TxtUbicacion").Visible = isEdit;
            item.FindControl("DropCambioGrupo").Visible = isEdit;
            item.FindControl("ChkCambioEstado").Visible = isEdit;
            //item.FindControl("ChkCambioPerfil").Visible = isEdit;
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                var query = (from TipoReporte in ListTipoReportes
                             select new
                             {
                                 Id = TipoReporte.Id,
                                 Nombres = TipoReporte.Nombre
                             }).ToList();

                ListItem item = new ListItem();
                item.Value = "0";
                item.Text = "Seleccionar...";

                ddlCambiarTipoReporte.DataSource = query.ToList();
                ddlCambiarTipoReporte.DataTextField = "Nombres";
                ddlCambiarTipoReporte.DataValueField = "Id";
                ddlCambiarTipoReporte.DataBind();
                ddlCambiarTipoReporte.Items.Insert(0, item);

                DropDownList ddlCambiarGrupo = (e.Item.FindControl("DropCambioGrupo") as DropDownList);

                var queryOP = (from Grupo in ListGrupos
                               select new
                               {
                                   Id = Grupo.Id,
                                   Nombres = Grupo.Nombre
                               }).ToList();

                ddlCambiarGrupo.DataSource = queryOP.ToList();
                ddlCambiarGrupo.DataTextField = "Nombres";
                ddlCambiarGrupo.DataValueField = "Id";
                ddlCambiarGrupo.DataBind();
                ddlCambiarGrupo.Items.Insert(0, item);
            }
        }

        protected void RepeaterVizualizaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                CheckBox chk = (e.Item.FindControl("ChekVizualizadoPor") as CheckBox);

                chk.InputAttributes["class"] = "form-check-input ms-auto";
            }
        }

        private void ObtenerUsuarios()
        {
            var query = (from Usuario in ListUsuarios
                         join Area in ListArea on Usuario.IdArea equals Area.Id
                         select new
                         {
                             Id = Usuario.Id,
                             Nombres = Usuario.Nombres,
                             IdArea = Area.Id,
                             NombreArea = Area.Nombre,
                             NombreAreaUsuario = Area.Nombre +" - "+ Usuario.IdOperacion +" - "+Usuario.Nombres 
                         }).ToList();


            RepeaterAsignacionReporte.DataSource = query.ToList();
            RepeaterAsignacionReporte.DataBind();
            query = null;
        }

        protected void RepeaterAsignacionReporte_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                CheckBox chk = (e.Item.FindControl("ChekAreaUsuario") as CheckBox);
                Label labIdArea = (e.Item.FindControl("LabIdArea") as Label);

                chk.InputAttributes["class"] = "form-check-input ms-auto";
                labIdArea.Attributes.Add("style", "display: none");

            }
        }

        public int MenuExiste(string Titulo, int IdUsuario)
        {
            MenuContexto contextoMenu = new MenuContexto();
            List<MenuOperaciones> ListMenu = contextoMenu.ObtenerMenuOperaciones();

            int Contador = 0;

            var query = (from MenuOperacion in ListMenu
                         select new
                         {
                             Operacion = MenuOperacion.Titulo,
                             Url = MenuOperacion.Url,
                             Categoria = MenuOperacion.Categoria,
                             Estado = MenuOperacion.Estado,
                             IdUsuario = MenuOperacion.IdUsuario,
                             FechaCreacion = MenuOperacion.FechaCreacion,
                             FechaActualizacion = MenuOperacion.FechaActualizaion,
                             CreadoPor = MenuOperacion.CreadoPor,
                             ActualizadoPor = MenuOperacion.ActualizadoPor,
                             IdArea = MenuOperacion.IdArea
                         }).ToList();

            Contador = query.Where(op => op.Operacion == Titulo).Where(Id => Id.IdUsuario == IdUsuario).Count();
            return Contador;
        }


        protected void BtnAsignar_Click1(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int IdGrupo = int.Parse((item.FindControl("LabGrupoAsg") as Label).Text);
            string Grupo = (item.FindControl("LabGrupo") as Label).Text;
            LabIdGrupoModal.Text = IdGrupo.ToString();
            LabGrupoModal.Text = Grupo;
            LabIdReporteModal.Text = (item.FindControl("LabIdReporte") as Label).Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#UsuariosModal').modal('show'); });</script>", false);

        }

        protected void BtnAsignarReporteUsuario_Click(object sender, EventArgs e)
        {
            int IdReporte = int.Parse(LabIdReporteModal.Text.Trim());
            string NombreTitulo = LabGrupoModal.Text.Trim();
            int IdGrupo = int.Parse(LabIdGrupoModal.Text.Trim());
            int IdUsuario = 0;
            MenuContexto contextoMenu = new MenuContexto();
            
            for (int i = 0; i < RepeaterAsignacionReporte.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)RepeaterAsignacionReporte.Items[i].FindControl("ChekAreaUsuario");
                Label nombreArea = (Label)RepeaterAsignacionReporte.Items[i].FindControl("LabNombreGrupo");
                Label idUsuario = (Label)RepeaterAsignacionReporte.Items[i].FindControl("LabIdUsuario");

                if (chk.Checked)
                {
                    IdUsuario = int.Parse(idUsuario.Text.Trim());
                    if (MenuExiste(NombreTitulo, IdUsuario) == 0)
                    {
                        MenuOperaciones modelo = new MenuOperaciones()
                        {
                            Titulo = NombreTitulo,
                            Url = "/AlmaBI/ReportesForms/VerReportesBI?Area=" + IdGrupo,
                            Categoria = "Menu",
                            IdUsuario = IdUsuario,
                            Estado = 1,
                            FechaCreacion = DateTime.Now,
                            CreadoPor = Session["Nombres"].ToString(),
                            IdArea = IdGrupo
                        };
                        contextoMenu.GuardarMenuOperaciones(modelo);
                    }
                }

            }

            for (int i = 0; i < RepeaterAsignacionReporte.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)RepeaterAsignacionReporte.Items[i].FindControl("ChekAreaUsuario");
                Label idUsuario = (Label)RepeaterAsignacionReporte.Items[i].FindControl("LabIdUsuario");

                if (chk.Checked)
                {
                    IdUsuario = int.Parse(idUsuario.Text.Trim());
                    UsuarioReporte modelo = new UsuarioReporte()
                    {
                        IdReporte = IdReporte,
                        IdUsuario = IdUsuario,
                        FechaActualizaion = DateTime.Now,
                        CreadoPor = Session["Nombres"].ToString()
                    };
                    contextoUsuario.GuardarUsuarioReporte(modelo);
                }

            }


        }


    }
}