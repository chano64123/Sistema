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
    
    public partial class tbSesiones
    {
        public long id { get; set; }
        public string usuario { get; set; }
        public static tbSesiones crear(string _usuario) {
            return new tbSesiones() {
                usuario = _usuario
            };
        }
    }
}
