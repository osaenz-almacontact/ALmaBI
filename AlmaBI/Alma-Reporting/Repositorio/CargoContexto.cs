using Alma_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alma_Reporting.Repositorio
{
    public class CargoContexto
    {
        public List<Cargos> ObtenerCargos()
        {
            using (Entities contexto = new Entities())
            {
                return contexto.Cargos.AsNoTracking().ToList();
            }
        }

        public void GuardarCargo(Cargos modelo)
        {
            try
            {
                using (Entities contexto = new Entities())
                {
                    contexto.Cargos.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElimiarCargo(int idCargo)
        {
            using (Entities contexto = new Entities())
            {
                var IdCargo = new Cargos { Id = idCargo };
                contexto.Entry(IdCargo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        internal void ActualizarCargo(Cargos modelo)
        {
            using (Entities contexto = new Entities())
            {
                Alma_Reporting.Model.Cargos cargo = (from car in contexto.Cargos
                                                    where car.Id == modelo.Id
                                                    select car).First();
                cargo.Nombre = modelo.Nombre;
                cargo.Estado = modelo.Estado;

                contexto.SaveChanges();
            }
        }
    }
}