using Alma_Reporting.Model;
using System.Collections.Generic;
using System.Linq;

namespace Alma_Reporting.Repositorio
{
    public class OperacionContexto
    {
        public List<Operaciones> ObtenerOperaciones()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Operaciones.AsNoTracking().ToList();
            }
        }
    }
}