﻿namespace Entidad {
    public class ClsEempresa {
        public string RazonSocial { get; private set; }
        public string Telefonos { get; private set; }
        public string Estado { get; private set; }
        public string Direccion { get; private set; }

        public static ClsEempresa crear(string _razonSocial, string _telefonos, string _estado, string _direccion) {
            return new ClsEempresa() {
                RazonSocial = _razonSocial,
                Telefonos = _telefonos,
                Estado = _estado,
                Direccion = _direccion
            };
        }
    }
}