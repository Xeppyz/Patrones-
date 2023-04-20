using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Clases
{
    interface IMediator
    {
        void Notificar(string mensaje, object sender);
    }
}
