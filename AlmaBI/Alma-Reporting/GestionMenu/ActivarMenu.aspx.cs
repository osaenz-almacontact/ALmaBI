using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alma_Reporting.GestionMenu
{
    public partial class ActivarMenu : System.Web.UI.Page
    {
        static MenuContexto contextoMenu = new MenuContexto();
        static PerfilContexto contextoPerfiles = new PerfilContexto();
        static AreaContexto contextoArea = new AreaContexto();
        static OperacionContexto contextoOperaciones = new OperacionContexto();

        List<MenuOperaciones> ListMenu = contextoMenu.ObtenerMenuOperaciones();
        List<Perfiles> ListPerfiles = contextoPerfiles.ObtenerPerfiles();
        List<Areas> ListArea = contextoArea.ObtenerAreas();
        List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerMenuOperaciones();
                ObtnerAreas();
                ObtenerOperaciones();
                ObtenrTiposPerfiles();
            }
        }

        public void ObtnerAreas()
        {
            var query = (from Area in ListArea
                         select new
                         {
                             Id = Area.Id,
                             Nombres = Area.Nombre
                         }).ToList();

            RepeaterVizualizacionesAreas.DataSource = query.ToList();
            RepeaterVizualizacionesAreas.DataBind();
        }

        public void ObtenerOperaciones()
        {
            var query = (from Operacion in ListOperaciones
                         select new
                         {
                             Id = Operacion.Id,
                             Nombres = Operacion.Nombre
                         }).ToList();

            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar...";

            DropOperacion.DataSource = query.ToList();
            DropOperacion.DataTextField = "Nombres";
            DropOperacion.DataValueField = "Id";
            DropOperacion.DataBind();
            DropOperacion.Items.Insert(0, item);
        }

        public void ObtenrTiposPerfiles()
        {
            var query = (from Perfil in ListPerfiles
                         select new
                         {
                             Id = Perfil.Id,
                             Nombres = Perfil.Nombre
                         }).ToList();

            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar...";

            DropPerfil.DataSource = query.ToList();
            DropPerfil.DataTextField = "Nombres";
            DropPerfil.DataValueField = "Id";
            DropPerfil.DataBind();
            DropPerfil.Items.Insert(0, item);
        }


        private void ObtenerMenuOperaciones()
        {
            var query = (from MenuOperacion in ListMenu
                         join Perfil in ListPerfiles on MenuOperacion.IdUsuario equals Perfil.Id

                         select new
                         {
                             Id = MenuOperacion.Id,
                             Operacion = MenuOperacion.Titulo,
                             Url = MenuOperacion.Url,
                             Categoria = MenuOperacion.Categoria,
                             IdPerfil = MenuOperacion.IdUsuario,
                             Pefil = Perfil.Nombre,
                             Estado = MenuOperacion.Estado,
                             FechaCreacion = MenuOperacion.FechaCreacion,
                             FechaActualizacion = MenuOperacion.FechaActualizaion,
                             CreadoPor = MenuOperacion.CreadoPor,
                             ActualizadoPor = MenuOperacion.ActualizadoPor,
                             IdArea = MenuOperacion.IdArea
                         }).ToList();


            RepterMenuOperaciones.DataSource = query.ToList();
            RepterMenuOperaciones.DataBind();

            //IdNombreOperacion.Text = query.Select(n => n.Nombres).FirstOrDefault();
        }

        protected void BtnGuardarMenu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RepeaterVizualizacionesAreas.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)RepeaterVizualizacionesAreas.Items[i].FindControl("ChekVizualizadoPor");
                Label id = (Label)RepeaterVizualizacionesAreas.Items[i].FindControl("LabId");

                if (chk.Checked)
                {
                    MenuOperaciones modelo = new MenuOperaciones()
                    {
                        Titulo = DropOperacion.SelectedItem.Text.Trim(),
                        Url = "/AlmaBI/ReportesForms/VerReportesBI?Opr=" + DropOperacion.SelectedValue.Trim(),
                        Categoria = "Menu",
                        IdUsuario = int.Parse(DropPerfil.SelectedValue.Trim()),
                        Estado = 1,
                        FechaCreacion = DateTime.Now,
                        CreadoPor = Session["Nombres"].ToString(),
                        IdArea = int.Parse(id.Text)
                    };
                    contextoMenu.GuardarMenuOperaciones(modelo);
                }
                
            }
        }

        
        protected void RepeaterVizualizacionesAreas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                CheckBox chk = (e.Item.FindControl("ChekVizualizadoPor") as CheckBox);

                chk.InputAttributes["class"] = "form-check-input ms-auto";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}