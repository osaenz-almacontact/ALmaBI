using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class GrupoContexto
    {
        public List<Grupos> ObtenerGrupos()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Grupos.AsNoTracking().ToList();
            }
        }

        public void GuardarGrupo(Grupos modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Grupos.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElimuarGrupo(int idGrupo)
        {
            using (Entities contexto = new Entities())
            {
                var IdGrupo = new Grupos { Id = idGrupo };
                contexto.Entry(IdGrupo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        internal void ActualizarGrupo(Grupos modelo)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Grupos grupo = (from grup in contexto.Grupos
                                                         where grup.Id == modelo.Id
                                                         select grup).First();
                grupo.Nombre = modelo.Nombre;
                grupo.IdEstado = modelo.IdEstado;

                contexto.SaveChanges();
            }
        }
    }
}