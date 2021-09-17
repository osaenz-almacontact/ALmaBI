using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class TipoReporteContexto
    {
        public List<TipoReporte> ObtenerTipoReportes()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.TipoReporte.AsNoTracking().ToList();
            }
        }
    }
}