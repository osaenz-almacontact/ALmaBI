using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class LoginContexto
    {
        public List<Usuarios> ObtenerUsuarios()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Usuarios.AsNoTracking().ToList();
            }
        }

        public List<UsuarioReporte> ObtenerUsuarioReportes()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.UsuarioReporte.AsNoTracking().ToList();
            }
        }

        public void GuardarUsuario(Usuarios modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Usuarios.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void GuardarLog(Logs modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Logs.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarEstadoUsuario(Usuarios modeloEstadoUsuario)
        {

            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Usuarios usuario = (from usu in contexto.Usuarios
                                                         where usu.Usuario == modeloEstadoUsuario.Usuario
                                                         select usu).First();
                usuario.IdEstado = modeloEstadoUsuario.IdEstado;
                usuario.Salt = modeloEstadoUsuario.Salt;
                usuario.Password = modeloEstadoUsuario.Password;

                contexto.SaveChanges();
            }

        }

        public void ActualizarUsuario(Usuarios modeloUsuario)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Usuarios usuario = (from usu in contexto.Usuarios
                                                         where usu.Id == modeloUsuario.Id
                                                         select usu).First();
                usuario.Nombres = modeloUsuario.Nombres;
                usuario.Usuario = modeloUsuario.Usuario;
                usuario.IdCargo = modeloUsuario.IdCargo;
                usuario.IdOperacion = modeloUsuario.IdOperacion;
                usuario.IdPerfil = modeloUsuario.IdPerfil;
                usuario.TelContacto = modeloUsuario.TelContacto;
                usuario.IdEstado = modeloUsuario.IdEstado;

                contexto.SaveChanges();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (Entities contexto = new Entities())
            {
                var IdUsuario = new Usuarios { Id = idUsuario };
                contexto.Entry(IdUsuario).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void ActualizarPasswordUsuario(Usuarios modelo)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Usuarios usuario = (from usu in contexto.Usuarios
                                                         where usu.Id == modelo.Id
                                                         select usu).First();
                usuario.Password = modelo.Password;
                usuario.Salt = modelo.Salt;
                contexto.SaveChanges();

            }
        }

        public void GuardarUsuarioReporte(UsuarioReporte modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.UsuarioReporte.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarUsuarioMenu(int idUsuario)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    var IdUsuario = new UsuarioReporte { IdUsuario = idUsuario };
                    contexto.Entry(IdUsuario).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}
