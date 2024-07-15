using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPC_Clinica_Grupo14
{
    public partial class DetalleMedicos : System.Web.UI.Page
    {
        private ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
        private EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEspecialidades();

                // Obtener el ID del profesional desde la query string
                int idProfesional;
                if (int.TryParse(Request.QueryString["idProfesional"], out idProfesional))
                {
                    cargarDetallesProfesional(idProfesional);
                }
            }
        }










        private void cargarDetallesProfesional(int idProfesional)
        {
            // Obtener la información del profesional basado en el ID de Personas
            Profesional profesional = profesionalNegocio.ObtenerProfesinalPorID(idProfesional);

            // Asignar la información a los controles de la página
            if (profesional != null)
            {
                txtNombre.Text = profesional.Nombre;
                txtApellido.Text = profesional.Apellido;
                txtFechaNacimiento.Text = profesional.FechaNacimiento.ToString("yyyy-MM-dd"); // Formato para un control de tipo fecha
                txtDNI.Text = profesional.NumDoc.ToString();
                txtCorreo.Text = profesional.Correo;
                txtTelefono.Text = profesional.Telefono;
                txtActivo.SelectedValue = profesional.Activo ? "1" : "2";

                // Si el profesional tiene una sola especialidad, seleccionarla en el dropdownlist y si tiene más de una, mostrar solo las que le corresponde al profesional en cuestion
                if (profesional.Especialidades.Count == 1)
                {
                    ddlEspecialidad.SelectedValue = profesional.Especialidades[0].Id.ToString();
                }
                else
                {
                    ddlEspecialidad.DataSource = profesional.Especialidades;
                    ddlEspecialidad.DataValueField = "ID";
                    ddlEspecialidad.DataTextField = "Nombre";
                    ddlEspecialidad.DataBind();
                }
            }
        }


        private void cargarEspecialidades()
        {
            List<Especialidad> especialidades = especialidadNegocio.Listar();
            ddlEspecialidad.DataSource = especialidades;
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataTextField = "Nombre";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Profesional profesional = new Profesional
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                NumDoc = txtDNI.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Activo = txtActivo.SelectedValue == "1"
            };



            //  ACA CHICOS, FALTA GESTIONAR LA ESPECIALIDAD DEL PROFESIONAL....

         

            // Agregar el profesional a la base de datos
            profesionalNegocio.AgregarProfesional(profesional);

            // Redirigir a la página de listado de profesionales
            Response.Redirect("Medicos.aspx"); ;

        }


        /// FALTA  AÑADIR LOGICA AL BOTON MODIFICAR Y ELIMINAR
        protected void btnModificar_Click(object sender, EventArgs e)
        {
           


        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
        
        }

        

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx");

        }






    }
}
