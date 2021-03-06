﻿namespace Entidad {
    public class ClsEcorreo {
        public string Destinatario { get; private set; }
        public string Asunto { get; private set; }
        public string Mensaje { get; private set; }

        public static ClsEcorreo crear(string _destinatario, string _asunto, string _mensaje) {
            return new ClsEcorreo() {
                Destinatario = _destinatario,
                Asunto = _asunto,
                Mensaje = _mensaje
            };
        }
    }
}