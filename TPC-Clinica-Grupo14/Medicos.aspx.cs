using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Clinica_Grupo14
{
    public partial class Medicos : System.Web.UI.Page
    {
        private ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
        private EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaEspecialidades();
                cargarListaProfesionales();


            }
        }

        protected void cargarListaEspecialidades()
        {
            try
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> listaEspecialidades = especialidadNegocio.Listar();
                ddlEspecialidad.DataSource = listaEspecialidades;
                ddlEspecialidad.DataTextField = "Nombre"; // Asume que "Nombre" es el campo a mostrar
                ddlEspecialidad.DataValueField = "Id"; // Asume que "Id" es el campo de valor
                ddlEspecialidad.DataBind();

                // Agrega un ítem por defecto
                ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void cargarListaProfesionales()
        {
            dgvMedicos.DataSource = profesionalNegocio.Listar();
            dgvMedicos.DataBind();

        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }


        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }






        private void LimpiarCampos()
        {

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNacimiento.Text = "";
            txtDNI.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtActivo.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
        }
    }
}
