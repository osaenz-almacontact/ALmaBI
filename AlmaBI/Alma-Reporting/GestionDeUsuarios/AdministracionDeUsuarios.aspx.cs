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
    public partial class AdministracionDeUsuarios : System.Web.UI.Page
    {
        static OperacionContexto contextoOperaciones = new OperacionContexto();
        static CargoContexto contextoCargos = new CargoContexto();
        static LoginContexto contextoUsuario = new LoginContexto();
        static PerfilContexto contextoPerfil = new PerfilContexto();
        static AreaContexto contextoArea = new AreaContexto();
        static ReporteContexto contextoReporte = new ReporteContexto();
        static GrupoContexto contextoGrupo = new GrupoContexto();

        List<Cargos> ListCargos = contextoCargos.ObtenerCargos();
        List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();
        List<Usuarios> ListUsuarios = contextoUsuario.ObtenerUsuarios();
        List<Perfiles> ListPerfiles = contextoPerfil.ObtenerPerfiles();
        List<Areas> ListAreas = contextoArea.ObtenerAreas();
        List<Reportes> ListReportes = contextoReporte.ObtenerReportess();
        List<Grupos> ListGrupos = contextoGrupo.ObtenerGrupos();
        protected void Page_Load(object sender, EventArgs e)
        {
            DivAlert.Visible = false;
            if (!IsPostBack)
            {
                if (Session["Nombres"] != null)
                {
                    ObtenerCargos();
                    ObtenerOperaciones();
                    ObtenerAreas();
                    ObtenerUsuarios();
                    ObtenrTiposPerfiles();
                    ObtnerGruposReportes();
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
            Logs modelo = new Logs()
            {
                Formulario = "AdministracionDeUsuarios",
                Accion = Accion,
                Fecha = DateTime.Now,
                IdUsuario = int.Parse(Session["IdUsuario"].ToString())
            };
            contextoUsuario.GuardarLog(modelo);

        }

        public void ObtenerCargos()
        {
            var query = (from Cargo in ListCargos
                         select new
                         {
                             Id = Cargo.Id,
                             Nombres = Cargo.Nombre
                         }).ToList();

            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar...";

            DropCargo.DataSource = query.ToList();
            DropCargo.DataTextField = "Nombres";
            DropCargo.DataValueField = "Id";
            DropCargo.DataBind();
            DropCargo.Items.Insert(0, item);
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

            RepeaterOperaciones.DataSource = query.ToList();
            RepeaterOperaciones.DataBind();
        }

        public void ObtenerUsuarios()
        {
            CargoContexto contextoCargos = new CargoContexto();
            LoginContexto contextoUsuario = new LoginContexto();
            PerfilContexto contextoPerfil = new PerfilContexto();
            AreaContexto contextoArea = new AreaContexto();

            List<Cargos> ListCargos = contextoCargos.ObtenerCargos();
            List<Usuarios> ListUsuarios = contextoUsuario.ObtenerUsuarios();
            List<Perfiles> ListPerfiles = contextoPerfil.ObtenerPerfiles();
            List<Areas> ListAreas = contextoArea.ObtenerAreas();

            var query = (from Usuario in ListUsuarios
                         join Cargo in ListCargos on Usuario.IdCargo equals Cargo.Id
                         join Perfil in ListPerfiles on Usuario.IdPerfil equals Perfil.Id
                         join Area in ListAreas on Usuario.IdArea equals Area.Id
                         select new
                         {
                             Id = Usuario.Id,
                             Nombres = Usuario.Nombres,
                             Usuario = Usuario.Usuario,
                             IdCargo = Cargo.Id,
                             Cargo = Cargo.Id == 0 ? "Cliente": Cargo.Nombre,
                             IdOperacion = Usuario.IdOperacion,
                             Operacion = Usuario.IdOperacion,
                             Telefono = Usuario.TelContacto,
                             Estado = Usuario.IdEstado,
                             IdPerfil = Perfil.Id,
                             Perfil = Perfil.Nombre,
                             IdArea = Area.Id,
                             Area = Area.Nombre
                         }).ToList();


            RepterUsuarios.DataSource = query.ToList().OrderByDescending(n => n.Nombres);
            RepterUsuarios.DataBind();
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

            DropTipoPerfil.DataSource = query.ToList();
            DropTipoPerfil.DataTextField = "Nombres";
            DropTipoPerfil.DataValueField = "Id";
            DropTipoPerfil.DataBind();
            DropTipoPerfil.Items.Insert(0, item);
        }

        public int ObtenerUsuario()
        {
            int count = 0;
            var query = (from Usuario in ListUsuarios
                         select new
                         {
                             Usuario = Usuario.Usuario,
                         }).Where(usu => usu.Usuario == TxtCorreo.Text.Trim()).ToList();

            count = query.Count();
            return count;
        }

        public int ObtenerUltimoUsuario()
        {

            LoginContexto contexto = new LoginContexto();
            List<Usuarios> ListaUsuarios = contexto.ObtenerUsuarios();
            int count = 0;
            var query = (from Usuario in ListaUsuarios
                         select new
                         {
                             Id = Usuario.Id,
                             Usuario = Usuario.Usuario,
                         }).Max(u => u.Id);

            count = query;
            return count;
        }

        public void ObtnerGruposReportes()
        {
            var query = (from Grupo in ListGrupos
                         join Reporte in ListReportes on Grupo.Id equals Reporte.IdGrupo
                         select new
                         {
                             Id = Grupo.Id,
                             Nombres = Grupo.Nombre + " - " + Reporte.Nombre,
                             NombreArea = Grupo.Nombre,
                             Estado = Reporte.IdEstado,
                             IdReporte = Reporte.Id
                         }).Where(es => es.Estado == 1).ToList();

            RepeaterAsignacionReporte.DataSource = query.ToList();
            RepeaterAsignacionReporte.DataBind();
        }

        public void ObtenerAreas()
        {
            var query = (from Area in ListAreas
                         select new
                         {
                             Id = Area.Id,
                             Nombres = Area.Nombre
                         }).ToList();

            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar...";

            DropArea.DataSource = query.ToList();
            DropArea.DataTextField = "Nombres";
            DropArea.DataValueField = "Id";
            DropArea.DataBind();
            DropArea.Items.Insert(0, item);
        }

        protected void BtnGuardarUsuario_Click(object sender, EventArgs e)
        {
            //bool isSaved = false;
            byte[] salt = Cryptographic.GenerateSalt();
            String html = "";
            string operacion = "";
            var hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes("AlmaBI2021#"), salt);

            try
            {
                if (ObtenerUsuario() == 0)
                {
                    for (int i = 0; i < RepeaterOperaciones.Items.Count; i++)
                    {
                        CheckBox chk = (CheckBox)RepeaterOperaciones.Items[i].FindControl("ChekOperaciones");
                        Label nombreOperacion = (Label)RepeaterOperaciones.Items[i].FindControl("LabNombreOperacion");

                        if (chk.Checked)
                        {
                            operacion = operacion + "," + nombreOperacion.Text;
                        }

                    }

                    Usuarios modelo = new Usuarios()
                    {
                        Nombres = TxtNombreCompleto.Text.Trim(),
                        Usuario = TxtCorreo.Text.Trim(),
                        Salt = salt,
                        Password = hashedPassword,
                        TelContacto = TxtTelefono.Text.Trim(),
                        IdCargo = int.Parse(DropCargo.SelectedValue.Trim()) == 0 ? 55 : int.Parse(DropCargo.SelectedValue.Trim()),
                        IdOperacion = operacion,
                        IdArea = int.Parse(DropArea.SelectedValue.Trim()) == 0 ? 11 : int.Parse(DropArea.SelectedValue.Trim()),
                        IdEstado = 1,
                        IdPerfil = int.Parse(DropTipoPerfil.SelectedValue.Trim())
                    };
                    contextoUsuario.GuardarUsuario(modelo);


                    GuardarUsuarioMenu(ObtenerUltimoUsuario());
                    GuardarUsuarioReporte(ObtenerUltimoUsuario());

                    //Crear menu

                    html = "<div style='padding:15px;'>" +
                                "<p style='margin:10px 0px 10px 10px;font-family:century gothic;font-size:14px'><strong>Hola: </strong> " + TxtNombreCompleto.Text.Trim() + "</p>" +
                                "<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Bienvenido! A partir de este momento puede acceder al portal de reportes ALMA-BI.</ p>" +
                                "<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Por favor ingrese al link con las credenciales iniciales asignadas y a continuación registre una nueva contraseña para mayor seguridad. </p>" +
                                "<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Ingreso a la aplicación <a href='http://alma-bi.co/AlmaBI/Login/Login'>link</a></p>" +
                                //"<p style='margin:0px 0px 20px 10px;font-family:century gothic;font-size:14px;color:#585964'>Si presenta algún problema al ingresar a la encuesta pude ingresar en el siguiente <a href='http://alma-bi.co/AlmaBI/Login/Login'>link</a></p>" +
                                "<p style='margin:0px 0px 10px 50px;font-size:16px;color:#12679B'><strong>Recuerde sus datos:</strong></p>" +
                                 "<p style='margin:0px 0px 10px 50px;font-size:16px;color:#12679B'><strong>Usuario : </strong><a style='color:#585964'>" + TxtCorreo.Text.Trim() + "</a></p>" +
                                 "<p style='margin:0px 0px 10px 50px;font-size:16px;color:#12679B'><strong>Contraseña : </strong><a style='color:#585964'>" + "AlmaBI2021#" + "</a></p></div>";
                    html = BaseEmail.crearRetornarCuerpoCorreo("NUEVO USUARIO ASIGNADO ", html, "Almacontact", "");


                    Email.EnviarEmail(TxtCorreo.Text.Trim(), TxtCorreo.Text.Trim(), "ALMA-BI", "ALMACONTACT - Creacion de usuario ", html);

                    //contextoReporte.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, entity);



                    VaciarCampos();
                    ObtenerUsuarios();
                    GuardarLog("Registro de usuario");

                    DivAlert.Visible = true;
                    DivAlert.Attributes.Add("class", "alert alert-success");
                    LabMensajeAlerta.Text = "Usuario creado exitosamente.";
                }
                else
                {
                    DivAlert.Visible = true;
                    DivAlert.Attributes.Add("class", "alert alert-danger");
                    LabMensajeAlerta.Text = "La direccion de correo ya ha sido ingresada";
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
                    LabMensajeAlerta.Text = "El nombre de usuario ya ha sido ingresado";
                }
                else
                {
                    LabMensajeAlerta.Text = ex.ToString();
                }


            }

        }

        public void GuardarUsuarioMenu(int IdUsuario)
        {
            MenuContexto contextoMenu = new MenuContexto();
            int IdArea = 0;
            string Titulo = "";

            for (int i = 0; i < RepeaterAsignacionReporte.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)RepeaterAsignacionReporte.Items[i].FindControl("ChekAreaReporte");
                Label id = (Label)RepeaterAsignacionReporte.Items[i].FindControl("LabId");
                Label nombreArea = (Label)RepeaterAsignacionReporte.Items[i].FindControl("LabNombreArea");

                if (chk.Checked)
                {
                    IdArea = int.Parse(id.Text);
                    Titulo = nombreArea.Text;
                    if (MenuExiste(Titulo, IdUsuario) == 0)
                    {
                        MenuOperaciones modelo = new MenuOperaciones()
                        {
                            Titulo = Titulo,
                            Url = "/AlmaBI/ReportesForms/VerReportesBI?Area=" + IdArea,
                            Categoria = "Menu",
                            IdUsuario = IdUsuario,
                            Estado = 1,
                            FechaCreacion = DateTime.Now,
                            CreadoPor = Session["Nombres"].ToString(),
                            IdArea = int.Parse(id.Text)
                        };
                        contextoMenu.GuardarMenuOperaciones(modelo);
                    }
                }

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
                             IdUsuario = MenuOperacion.IdUsuario,
                         }).ToList();

            Contador = query.Where(op => op.Operacion == Titulo).Where(Id => Id.IdUsuario == IdUsuario).Count();
            return Contador;
        }

        public void GuardarUsuarioReporte(int IdUsuario)
        {
            MenuContexto contextoMenu = new MenuContexto();

            for (int i = 0; i < RepeaterAsignacionReporte.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)RepeaterAsignacionReporte.Items[i].FindControl("ChekAreaReporte");
                Label idReporte = (Label)RepeaterAsignacionReporte.Items[i].FindControl("LabIdReporte");

                if (chk.Checked)
                {
                    UsuarioReporte modelo = new UsuarioReporte()
                    {
                        IdReporte = int.Parse(idReporte.Text),
                        IdUsuario = IdUsuario,
                        FechaActualizaion = DateTime.Now,
                        CreadoPor = Session["Nombres"].ToString()
                    };
                    contextoUsuario.GuardarUsuarioReporte(modelo);
                }

            }
        }

        public void VaciarCampos()
        {
            TxtNombreCompleto.Text = "";
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";
            DropArea.SelectedIndex = 0;
            DropTipoPerfil.SelectedIndex = 0;
            DropTipoAcceso.SelectedIndex = 0;
        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdUsuario") as Label).Text);
                string Nombre = (item.FindControl("TxtNombreCompleto") as TextBox).Text.Trim();
                string Usuario = (item.FindControl("TxtNombreUsuario") as TextBox).Text.Trim();
                int IdCargo = int.Parse((item.FindControl("DropCambiarCargo") as DropDownList).SelectedValue) == 0 ? int.Parse((item.FindControl("LabCargoAnterior") as Label).Text) : int.Parse((item.FindControl("DropCambiarCargo") as DropDownList).SelectedValue);
                string Operacion = (item.FindControl("DropCambiarOperacion") as DropDownList).SelectedValue == "0" ?(item.FindControl("LabOperacionAnterior") as Label).Text : (item.FindControl("DropCambiarOperacion") as DropDownList).SelectedValue;
                int IdPerfil = int.Parse((item.FindControl("DropCambioPerfi") as DropDownList).SelectedValue) == 0 ? int.Parse((item.FindControl("LabIdPerfilAnterior") as Label).Text) : int.Parse((item.FindControl("DropCambioPerfi") as DropDownList).SelectedValue);
                string Telefono = (item.FindControl("TxtTelefono") as TextBox).Text.Trim();
                int Estado = (item.FindControl("ChkTipoUsuarioCambio") as CheckBox).Checked ? 1 : 0;


                Usuarios modelo = new Usuarios()
                {
                    Id = Id,
                    Nombres = Nombre,
                    Usuario = Usuario,
                    IdCargo = IdCargo,
                    IdOperacion = Operacion,
                    IdPerfil = IdPerfil,
                    TelContacto = Telefono,
                    IdEstado = Estado
                };
                contextoUsuario.ActualizarUsuario(modelo);
                GuardarLog("Actualizacion de Usuario: " + TxtNombreCompleto.Text.Trim());

                ObtenerUsuarios();

                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Usuario actualizado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','" + ex.Message + "');", true);
            }
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int IdUsuario = int.Parse((item.FindControl("LabIdUsuario") as Label).Text);

            MenuContexto contextoMenu = new MenuContexto();
            List<MenuOperaciones> ListMenu = contextoMenu.ObtenerMenuOperaciones();

            try
            {
                contextoMenu.ElimuarUsuarioMenu(IdUsuario);
                contextoUsuario.EliminarUsuarioMenu(IdUsuario);
                contextoUsuario.EliminarUsuario(IdUsuario);

                ObtenerUsuarios();

                GuardarLog("Eliminacion de Usuario: " + TxtNombreCompleto.Text.Trim());

                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-success");
                LabMensajeAlerta.Text = "Usuario eliminado exitosamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", true);
            }
            catch (Exception ex)
            {
                DivAlert.Visible = true;
                DivAlert.Attributes.Add("class", "alert alert-danger");
                LabMensajeAlerta.Text = ex.ToString();
            }

            
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Buttons
            item.FindControl("LnkEditar").Visible = !isEdit;
            item.FindControl("BtnActualizar").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabNombreCompleto").Visible = !isEdit;
            item.FindControl("LabNombreUsuario").Visible = !isEdit;
            item.FindControl("Labcargo").Visible = !isEdit;
            item.FindControl("LabOperacion").Visible = !isEdit;
            item.FindControl("LabTelefono").Visible = !isEdit;
            item.FindControl("LabPerfil").Visible = !isEdit;
            //item.FindControl("LabTipoAcceso").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("TxtNombreCompleto").Visible = isEdit;
            item.FindControl("TxtNombreUsuario").Visible = isEdit;
            item.FindControl("DropCambiarCargo").Visible = isEdit;
            item.FindControl("DropCambiarOperacion").Visible = isEdit;
            item.FindControl("TxtTelefono").Visible = isEdit;
            item.FindControl("DropCambioPerfi").Visible = isEdit;
            //item.FindControl("DropCambioTipoAcceso").Visible = isEdit;
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCambiarCargo = (e.Item.FindControl("DropCambiarCargo") as DropDownList);

                var query = (from Cargo in ListCargos
                             select new
                             {
                                 Id = Cargo.Id,
                                 Nombres = Cargo.Nombre
                             }).ToList();

                ListItem item = new ListItem();
                item.Value = "0";
                item.Text = "Seleccionar...";

                ddlCambiarCargo.DataSource = query.ToList();
                ddlCambiarCargo.DataTextField = "Nombres";
                ddlCambiarCargo.DataValueField = "Id";
                ddlCambiarCargo.DataBind();
                ddlCambiarCargo.Items.Insert(0, item);

                DropDownList ddlCambiarOperacion = (e.Item.FindControl("DropCambiarOperacion") as DropDownList);

                var queryOP = (from Operacion in ListOperaciones
                               select new
                               {
                                   Id = Operacion.Id,
                                   Nombres = Operacion.Nombre
                               }).ToList();

                ddlCambiarOperacion.DataSource = queryOP.ToList();
                ddlCambiarOperacion.DataTextField = "Nombres";
                ddlCambiarOperacion.DataValueField = "Nombres";
                ddlCambiarOperacion.DataBind();
                ddlCambiarOperacion.Items.Insert(0, item);

                DropDownList ddlCambiarPerfil = (e.Item.FindControl("DropCambioPerfi") as DropDownList);

                var queryPerfil = (from Perfil in ListPerfiles
                                   select new
                                   {
                                       Id = Perfil.Id,
                                       Nombres = Perfil.Nombre
                                   }).ToList();

                ddlCambiarPerfil.DataSource = queryPerfil.ToList();
                ddlCambiarPerfil.DataTextField = "Nombres";
                ddlCambiarPerfil.DataValueField = "Id";
                ddlCambiarPerfil.DataBind();
                ddlCambiarPerfil.Items.Insert(0, item);

                DropDownList ddlCambiarArea = (e.Item.FindControl("DropCambioArea") as DropDownList);

                var queryAreas = (from Area in ListAreas
                                  select new
                                  {
                                      Id = Area.Id,
                                      Nombres = Area.Nombre
                                  }).ToList();

                ddlCambiarArea.DataSource = queryAreas.ToList();
                ddlCambiarArea.DataTextField = "Nombres";
                ddlCambiarArea.DataValueField = "Id";
                ddlCambiarArea.DataBind();
                ddlCambiarArea.Items.Insert(0, item);
            }
        }

        protected void RepeaterAsignacionReporte_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                CheckBox chk = (e.Item.FindControl("ChekAreaReporte") as CheckBox);
                Label labId = (e.Item.FindControl("LabId") as Label);
                Label labNombreArea = (e.Item.FindControl("LabNombreArea") as Label);
                Label labIdReporte = (e.Item.FindControl("LabIdReporte") as Label);

                chk.InputAttributes["class"] = "form-check-input ms-auto";
                
                labId.Attributes.Add("style", "display: none");
                labNombreArea.Attributes.Add("style", "display: none");
                labIdReporte.Attributes.Add("style", "display: none");
            }
        }

        protected void RepeaterOperaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                CheckBox chk = (e.Item.FindControl("ChekOperaciones") as CheckBox);
                Label labIdOperacion = (e.Item.FindControl("LabIdOperacion") as Label);

                chk.InputAttributes["class"] = "form-check-input ms-auto";
                labIdOperacion.Attributes.Add("style", "display: none");

            }
        }

        protected void DropTipoAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.DropTipoAcceso.SelectedValue == "1")
            {
                DropCargo.Enabled = true;
            }
            else
            {
                DropCargo.Enabled = false;
            }
            
        }
    }
}