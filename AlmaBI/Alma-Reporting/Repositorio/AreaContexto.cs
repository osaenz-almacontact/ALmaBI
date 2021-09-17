using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class AreaContexto
    {
        public List<Areas> ObtenerAreas()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Areas.AsNoTracking().ToList();
            }
        }

        public void GuardarArea(Areas modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Areas.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElimiarArea(int idArea)
        {
            using (Entities contexto = new Entities())
            {
                var IdArea = new Areas { Id = idArea };
                contexto.Entry(IdArea).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void ActualizarArea(Areas modelo)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Areas area = (from ar in contexto.Areas
                                                     where ar.Id == modelo.Id
                                                     select ar).First();
                area.Nombre = modelo.Nombre;
                area.Estado = modelo.Estado;

                contexto.SaveChanges();
            }
        }
    }
}