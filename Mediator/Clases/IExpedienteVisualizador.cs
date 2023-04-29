using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediator.Clases
{
    public interface IExpedienteVisualizador
    {
        string Visualizar(List<string> datos);
    }
}