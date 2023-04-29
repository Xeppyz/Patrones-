using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediator.Clases
{
    public class ExpedienteDocente : Expediente
    {
        private string nombre;
        private string edad;
        private string materia;

        public ExpedienteDocente(IExpedienteVisualizador visualizador, string nombre, string edad, string materia) : base(visualizador)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.materia = materia;
        }

        public override List<string> ObtenerDatos()
        {
            // Obtener los datos del expediente


            return new List<string> {
        "Nombre: " + nombre,
        "Edad: " + edad + " años",
        "Materia: " + materia
    };
        }
    }
}