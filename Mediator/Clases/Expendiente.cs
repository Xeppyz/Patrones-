using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediator.Clases
{
   
        public abstract class Expediente
        {
            protected IExpedienteVisualizador visualizador;

            public Expediente(IExpedienteVisualizador visualizador)
            {
                this.visualizador = visualizador;
            }

            public abstract List<string> ObtenerDatos();

            public string Visualizar()
            {
                List<string> datos = ObtenerDatos();
                return visualizador.Visualizar(datos);
            }
        }
    }
