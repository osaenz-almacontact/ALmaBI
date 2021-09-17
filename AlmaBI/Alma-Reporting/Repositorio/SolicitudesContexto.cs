using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class SolicitudesContexto
    {
        public List<Solicitudes> ObtenerSolicitudes()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Solicitudes.AsNoTracking().ToList();
            }
        }

        public void GuardarSolicitud(Solicitudes modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Solicitudes.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarSolicitud(Solicitudes modelo)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Solicitudes solicitud = (from solic in contexto.Solicitudes
                                                              where solic.Id == modelo.Id
                                                              select solic).First();
                solicitud.Estado = modelo.Estado;

                contexto.SaveChanges();
            }
        }
    }
}