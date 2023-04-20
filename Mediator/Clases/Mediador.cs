using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Mediator.Clases
{
    public class Mediador : IMediator
    {
        private Label label1;
        private Label label2;
        private Button boton1;
        private Button boton2;

        public Mediador(Label label1, Label label2, Button boton1, Button boton2)
        {
            this.label1 = label1;
            this.label2 = label2;
            this.boton1 = boton1;
            this.boton2 = boton2;
        }

        public void Notificar(string mensaje, object sender)
        {
            if (sender == boton1)
            {
                label1.Text = mensaje;
            }
            else if (sender == boton2)
            {
                label2.Text = mensaje;
            }
        }
    }
}