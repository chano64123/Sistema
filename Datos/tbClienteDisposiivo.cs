//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbClienteDisposiivo
    {
        public long idClienteDispositivo { get; set; }
        public string DniCliente { get; set; }
        public string SerieDispositivo { get; set; }
    
        public virtual tbClientes tbClientes { get; set; }
        public virtual tbDispositivos tbDispositivos { get; set; }
    }
}
