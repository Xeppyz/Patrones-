using Datos;
using Mediator.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mediator
{
    public partial class _Default : Page
    {
        private Mediador mediador;
        //List<Docente> datos;


        protected void Page_Load(object sender, EventArgs e)
        {
            mediador = new Mediador(Label1, Label2, Button1, Button2);
            //datos = new List<Docente>();

            if (!IsPostBack)
            {
                GridView1.SelectedIndexChanged += GridView1_SelectedIndexChanged;

            }

            // Mostramos los datos en la tabla cada vez que se carga la página
            /*GridView1.DataSource = datos;
            GridView1.DataBind();*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Operacion op = new Operacion();

            string nombre, direccion, correo, telefono;

            nombre = txtNombre.Text;
            direccion = txtDireccion.Text;
            correo = txtCorreo.Text;
            telefono = txtTelefono.Text;


            if (op.InsertDocente(nombre, direccion, correo, telefono))
            {
                Response.Write("<script>windows.alert('Expediente Guardado correctamente')</script>");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>windows.alert('Error al guardar')</script>");
            }

            /*string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;

            Docente docente = new Docente { Nombre = nombre, Direccion = direccion, Correo = correo, Telefono = telefono };

            //datos.Add(docente);

            //GridView1.DataSource = datos;
            //GridView1.DataBind();
            */
            mediador.Notificar("Datos guardados en la base de datos.", sender);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Aquí podríamos hacer algo con los datos guardados en la lista, como mostrarlos en una tabla, por ejemplo.
            // En este ejemplo, simplemente mostraremos un mensaje en el Label2.
            // Limpiamos los campos de texto
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";

            mediador.Notificar("Datos han sido  en la tabla.", sender);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                // Obtenemos los valores de las celdas de la fila seleccionada
                string idValue = GridView1.SelectedRow.Cells[1].Text;
                string nombreValue = GridView1.SelectedRow.Cells[2].Text;
                string direccion = GridView1.SelectedRow.Cells[3].Text;
                string correo = GridView1.SelectedRow.Cells[4].Text;
                string telefono = GridView1.SelectedRow.Cells[5].Text;

                // Asignamos los valores a los TextBox correspondientes
                txtId.Text = idValue;
                txtNombre.Text = nombreValue;
                txtDireccion.Text = direccion;
                txtCorreo.Text = correo;
                txtTelefono.Text = telefono;
            }
        }
    }
}