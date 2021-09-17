using Alma_Reporting.Crypto;
using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Alma_Reporting.GestionDeUsuarios
{
    public partial class Perfil : System.Web.UI.Page
    {
        static LoginContexto contextoUsuarios = new LoginContexto();
        static OperacionContexto contextoOperaciones = new OperacionContexto();
        static CargoContexto contextoCargos = new CargoContexto();
        static PerfilContexto contextoPerfiles = new PerfilContexto();
        static ReporteContexto contextoReporte = new ReporteContexto();
        static AreaContexto contextoArea = new AreaContexto();
        static GrupoContexto contextoGrupo = new GrupoContexto();

        List<Usuarios> ListUsuarios = contextoUsuarios.ObtenerUsuarios();
        List<Perfiles> ListPerfiles = contextoPerfiles.ObtenerPerfiles();
        List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();
        List<Cargos> ListCargos = contextoCargos.ObtenerCargos();
        List<Reportes> ListReportes = contextoReporte.ObtenerReportess();
        List<Areas> ListArea = contextoArea.ObtenerAreas();
        List<Grupos> ListGrupos = contextoGrupo.ObtenerGrupos();

        int IdPerfil = 0;
        int IdUsuario = 0;
        string Operacion = "";
        string PerfilUsuario = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombres"] != null)
            {

                LabNombre.Text = Session["Nombres"].ToString();
                IdPerfil = int.Parse(Session["IdPerfil"].ToString());
                IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                Operacion = Session["IdOperacion"].ToString();
                PerfilUsuario = Session["Perfil"].ToString();

                LabNombreCompleto.Text = Session["Nombres"].ToString();
                ObtenerDatosUsuario();
                ObtnerReportes();
            }
            else
            {
                Response.Redirect("../Login/Login");
            }
        }

        public void ObtenerDatosUsuario()
        {
            var query = (from Usuario in ListUsuarios
                         //join Operacion in ListOperaciones on Usuario.IdOperacion equals Operacion.Id
                         join Cargo in ListCargos on Usuario.IdCargo equals Cargo.Id
                         join Perfil in ListPerfiles on Usuario.IdPerfil equals Perfil.Id
                         where Usuario.Id == IdUsuario
                         select new
                         {
                             IdUsuario = Usuario.Id,
                             Nombres = Usuario.Nombres,
                             Usuario = Usuario.Usuario,
                             Telefono = Usuario.TelContacto,
                             IdOperacion = "P",
                             Operacion = "P",
                             IdCargo = Cargo.Id,
                             Cargo = Cargo.Nombre,
                             Perfil = Perfil.Nombre,
                             IdPerfil = Perfil.Id,
                         }).FirstOrDefault();

            LabNombreCompleto.Text = query.Nombres.ToString();
            LabNombeDeUsuario.Text = query.Usuario.ToString();
            LabTelefono.Text = query.Telefono.ToString();
            LabOperacion.Text = query.Operacion.ToString();
            LabCargoAsignado.Text = query.Cargo.ToString();
            LabCargo.Text = query.Cargo.ToString();
        }

        public void ObtnerReportes()
        {
            var query = (from Reporte in ListReportes
                         select new
                         {
                             Id = Reporte.Id,
                             Nombres = Reporte.Nombre
                         }).ToList();

            //var query = (from Reporte in ListReportes
            //             join Operacion in ListOperaciones on Reporte.IdOperacion equals Operacion.Id
            //             join Usuario in ListUsuarios on Operacion.Id equals Usuario.IdOperacion
            //             select new
            //             {
            //                 Id = Reporte.Id,
            //                 Nombres = Reporte.Nombre,
            //                 IdUsuario = Usuario.Id
            //             }).Where(u => u.IdUsuario == IdUsuario).ToList();

            //Repeater Repeater1 = new Repeater();


            RepeaterVizualizacionReportes.DataSource = query.ToList();
            RepeaterVizualizacionReportes.DataBind();
        }

        protected void BtnGuardarPassword_Click(object sender, EventArgs e)
        {
            byte[] salt = Cryptographic.GenerateSalt();
            var hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(TxtNuevoPassword.Text.Trim()), salt);

            Usuarios modelo = new Usuarios()
            {
                Id = IdUsuario,
                Salt = salt,
                Password = hashedPassword
            };
            contextoUsuarios.ActualizarPasswordUsuario(modelo);
        }

        protected void RepeaterVizualizacionesAreas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCambiarTipoReporte = (e.Item.FindControl("DropCambioTipoReporte") as DropDownList);

                CheckBox chk = (e.Item.FindControl("ChekVizualizadoPor") as CheckBox);

                chk.InputAttributes["class"] = "form-check-input ms-auto";

                var query = (from Reporte in ListReportes
                             join Grupo in ListGrupos on Reporte.IdGrupo equals Grupo.Id
                             join Area in ListArea on Reporte.IdGrupo equals Area.Id 
                             join Usuario in ListUsuarios on Area.Id equals Usuario.IdArea 
                             select new
                             {
                                 Id = Reporte.Id,
                                 Nombres = Reporte.Nombre,
                                 NombeUsuario = (Usuario.Nombres == null) ? "0" : Usuario.Nombres,
                                 IdUsuario = (Usuario.Id == null) ? 0 : Usuario.Id,
                             }).Where(u => u.IdUsuario == IdUsuario).ToList();

                //var User = from U in Users
                //           join Uc in UserClients on U.Id equals Uc.UserId into Myuserwithclient
                //           from M in Myuserwithclient.DefaultIfEmpty()
                //           select new {
                //             Id = U.Id,
                //             FirstName = U.FirstName,
                //             LastName = U.LastName,
                //             UserId = M.UserId,
                //             MobileNo = (M.MobileNo == Null) ? "N/A" : M.MobileNo
                //            };

                for (int i = 0; i < query.Count; i++)
                {
                   if (query[i].IdUsuario == 0)
                    {
                        chk.Checked = false;
                    }
                   else
                    {
                        chk.Checked = true;
                    }
                }

                //foreach (RepeaterItem item in RepeaterVizualizacionReportes.Items)
                //{
                //    CheckBox chkdel = (CheckBox)item.FindControl("chkdel");//assume the ID of checkbox is 'chkdel'
                //    if (chkdel.Checked)
                //    {
                //        //do the delete process
                //    }
                //}
            }
        }
    }
}