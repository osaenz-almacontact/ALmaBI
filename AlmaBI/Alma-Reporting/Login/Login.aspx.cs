using Alma_Reporting.Crypto;
using Alma_Reporting.Model;
using Alma_Reporting.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Alma_Reporting.Login
{
    public partial class Login : System.Web.UI.Page
    {
        LoginContexto contextoUsuarios = new LoginContexto();
        OperacionContexto contextoOperaciones = new OperacionContexto();
        CargoContexto contextoCargos = new CargoContexto();
        PerfilContexto contextoPerfiles = new PerfilContexto();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ObtenerUsuarioDeBD(TxtUsuario.Text);
            if(ValidarPassword(TxtUsuario.Text, TxtPassword.Text))
            {
                GuardarLog();
                FormsAuthentication.RedirectFromLoginPage(TxtUsuario.Text, true);
            }
            else
            {
                LblMensaje.Text = "Usuario y/o password es incorrectos.";
                pnl_Mensaje.Visible = true;
            }

        }

        public void GuardarLog()
        {
            Logs modelo = new Logs()
            {
                Formulario = "Dashboard",
                Accion = "Ingreso a la aplicación",
                Fecha = DateTime.Now,
                IdUsuario = int.Parse(Session["IdUsuario"].ToString())
            };
            contextoUsuarios.GuardarLog(modelo);
           
        }

        private bool ValidarPassword(string Usuario, string Password)
        {
            UsuarioBE user = ObtenerUsuarioDeBD(Usuario);
            bool isValid = false;

            if (!string.IsNullOrEmpty(user.Usuario))
            {
                byte[] hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(Password), user.Salt);

                if (hashedPassword.SequenceEqual(user.Password))
                    isValid = true;
            }

            return isValid;

        }


        private UsuarioBE ObtenerUsuarioDeBD(string Usr)
        {
            List<Usuarios> ListUsuarios = contextoUsuarios.ObtenerUsuarios();
            List<Perfiles> ListPerfiles = contextoPerfiles.ObtenerPerfiles();
            List<Operaciones> ListOperaciones = contextoOperaciones.ObtenerOperaciones();
            List<Cargos> ListCargos = contextoCargos.ObtenerCargos();

            UsuarioBE user = new UsuarioBE();

            var query = (from Usuario in ListUsuarios
                         //join Operacion in ListOperaciones on Usuario.IdOperacion equals Operacion.Id
                         join Cargo in ListCargos on Usuario.IdCargo equals Cargo.Id
                         join Perfil in ListPerfiles on Usuario.IdPerfil equals Perfil.Id
                         where Usuario.Usuario == TxtUsuario.Text 
                         select new
                         {
                             IdUsuario = Usuario.Id,
                             Nombres = Usuario.Nombres,
                             IdOperacion = "P",
                             Operacion = "P",
                             IdCargo = Cargo.Id,
                             Cargo = Cargo.Nombre,
                             EstadoUsuario = Usuario.IdEstado,
                             Perfil = Perfil.Nombre,
                             IdPerfil = Perfil.Id,
                             Salt = Usuario.Salt,
                             Pass = Usuario.Password,
                             IdArea=Usuario.IdArea
                         }).ToList();

            var Retorno = query.Find(x => x.EstadoUsuario.HasValue);
            switch (query.Count)
            {
                case 0:
                    LblMensaje.Text = "Usuario y/o password es incorrecto.";
                    pnl_Mensaje.Visible = true;
                    break;
                case 1:
                    if (Retorno.EstadoUsuario == 1)
                    {
                        Session["IdUsuario"] = Retorno.IdUsuario.ToString();
                        Session["Nombres"] = Retorno.Nombres.ToString();
                        Session["Operacion"] = Retorno.Operacion.ToString();
                        Session["IdOperacion"] = Retorno.IdOperacion.ToString();
                        Session["Cargo"] = Retorno.Cargo.ToString();
                        Session["Estado"] = Retorno.EstadoUsuario.ToString();
                        Session["IdPerfil"] = Retorno.IdPerfil.ToString();
                        Session["Perfil"] = Retorno.Perfil.ToString();
                        Session["IdArea"] = Retorno.IdArea.ToString();

                        user.Usuario = Retorno.Nombres.ToString();
                        user.Password = (byte[])Retorno.Pass;
                        user.Salt = (byte[])Retorno.Salt;

                        break;
                    }
                    else
                    {
                        LblMensaje.Text = "Account has not been activated.";
                        pnl_Mensaje.Visible = true;
                    }
                    break;
                    //default:
                    //FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    //return RedirectToAction("Profile");
            }

            return user;
        }

    }
}