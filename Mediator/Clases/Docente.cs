using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediator.Clases
{
    public class Docente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        /*public Docente(string nombre, string direccion, string correo, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Correo = correo;
            this.Telefono = telefono;
        }*/
    }
}