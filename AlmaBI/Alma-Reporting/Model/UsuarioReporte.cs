//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alma_Reporting.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioReporte
    {
        public int Id { get; set; }
        public Nullable<int> IdReporte { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<System.DateTime> FechaActualizaion { get; set; }
        public string CreadoPor { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
