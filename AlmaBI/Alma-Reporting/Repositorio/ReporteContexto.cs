using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class ReporteContexto
    {
        public List<Reportes> ObtenerReportess()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Reportes.AsNoTracking().ToList();
            }
        }

        public void GuardarReporte(Reportes modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Reportes.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarReporte(Reportes modelo)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Reportes reporte = (from rep in contexto.Reportes
                                                       where rep.Id == modelo.Id
                                                       select rep).First();
                reporte.Nombre = modelo.Nombre;
                reporte.IdTipo = modelo.IdTipo;
                reporte.Ubicacion = modelo.Ubicacion;
                reporte.IdEstado = modelo.IdEstado;
                reporte.IdGrupo = modelo.IdGrupo;

                contexto.SaveChanges();
            }
        }

        public void EliminarReporte(int idReporte)
        {
            using (Entities contexto = new Entities())
            {
                //Alma_Reporting.Model.Reportes reporte = (from rep in contexto.Reportes
                //                                         where rep.Id == idReporte
                //                                         select rep).First();
                var IdReporte = new Reportes { Id = idReporte };
                //CargoContexto rptDelete = new contexto.
                contexto.Entry(IdReporte).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        internal void EliminarReportesPorGrupo(int idGrupo)
        {
            using (Entities contexto = new Entities())
            {
                var GrupoReporte = contexto.Reportes.Where(r => r.Id== idGrupo).FirstOrDefault();
                //CargoContexto rptDelete = new contexto.
                while (GrupoReporte  != null)
                {
                    contexto.Entry(GrupoReporte).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();

                    GrupoReporte = contexto.Reportes.Where(r => r.Id == idGrupo).FirstOrDefault();
                }
            }
        }
    }
}