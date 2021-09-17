using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Repositorio
{
    public class PerfilContexto
    {
        public List<Perfiles> ObtenerPerfiles()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Perfiles.AsNoTracking().ToList();
            }
        }
    }
}