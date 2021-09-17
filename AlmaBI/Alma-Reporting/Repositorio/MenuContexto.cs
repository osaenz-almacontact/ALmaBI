using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Alma_Reporting.Repositorio
{
    public class MenuContexto
    {
        public List<MenuOperaciones> ObtenerMenuOperaciones()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.MenuOperaciones.AsNoTracking().ToList();
            }
        }

        public void GuardarMenuOperaciones(MenuOperaciones modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.MenuOperaciones.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElimuarUsuarioMenu(int idUsuario)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    var IdUsuario = new MenuOperaciones { IdUsuario = idUsuario };
                    contexto.Entry(IdUsuario).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }

        }

        internal void EliminarMenuPorGrupo(string grupo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {

                    var MenuGrupo = contexto.MenuOperaciones.Where(m => m.Titulo == grupo).FirstOrDefault();

                    while (MenuGrupo != null)
                    {
                        contexto.Entry(MenuGrupo).State = System.Data.Entity.EntityState.Deleted;
                        contexto.SaveChanges();

                        MenuGrupo = contexto.MenuOperaciones.Where(m => m.Titulo == grupo).FirstOrDefault();
                    }

                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}