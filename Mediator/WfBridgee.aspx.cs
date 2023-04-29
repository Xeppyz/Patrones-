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
    public partial class WfBridgee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.SelectedIndexChanged += GridView1_SelectedIndexChanged1;

            }
           
        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                // Obtenemos los valores de las celdas de la fila seleccionada
                string idValue = GridView1.SelectedRow.Cells[1].Text;
                string nombreValue = GridView1.SelectedRow.Cells[2].Text;
                string edadValue = GridView1.SelectedRow.Cells[3].Text;
                string materiaValue = GridView1.SelectedRow.Cells[4].Text;

                // Asignamos los valores a los TextBox correspondientes
                txtID.Text = idValue;
                txtNombre.Text = nombreValue;
                txtEdad.Text = edadValue;
                txtMateria.Text = materiaValue;
            }

        }


        private void LimpiarTextBox()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtMateria.Text = "";


        }


      
        

      

       

        protected void BtnAgregar_Click1(object sender, EventArgs e)
        {
            try
            {

                // Validar que los TextBox no estén vacíos
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtEdad.Text) || string.IsNullOrEmpty(txtMateria.Text))
                {
                    throw new Exception("Todos los campos son requeridos.");
                }

                OpInsert op = new OpInsert();

                string nombre, edad, materia;

                nombre = txtNombre.Text;
                edad = txtEdad.Text;
                materia = txtMateria.Text;

                if (op.InsertPersona(nombre, edad, materia))
                {
                    Response.Write("<script>windows.alert('Expediente Guardado correctamente')</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>windows.alert('Error al guardar')</script>");
                }
            }
            catch (Exception ex)
            {

                lblResultado.Text = "Error: " + ex.Message;
            }
        }

        protected void BtnLimpiar_Click1(object sender, EventArgs e)
        {
            LimpiarTextBox();
        }

        protected void BtnMostrar_Click1(object sender, EventArgs e)
        {
            // Crear un objeto ExpedienteDocente


            // Obtener los datos del expediente

            try{
                string nombre = txtNombre.Text;
                string edad = txtEdad.Text;
                string materia = txtMateria.Text;



                Expediente expediente = new ExpedienteDocente(new VisualizadorTextoPlano(), nombre, edad, materia);
                Expediente expediente2 = new ExpedienteDocente(new VisualizadorPDF(), nombre, edad, materia);
                Expediente expediente3 = new ExpedienteDocente(new VisualizadorExcel(), nombre, edad, materia);
                // Mostrar el expediente en la etiqueta Label

                LabelMensaje.Text = expediente.Visualizar();
              
                
                // Mostrar mensaje de éxito
               
 

                // Mostrar mensaje de éxito
               
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                lblResultado.Text = "Error: " + ex.Message;
            }
            
          
            

        }
    }
}

