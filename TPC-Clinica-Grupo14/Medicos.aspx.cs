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
                cargarListaProfesionales();
                cargarListaEspecialidades();
                

            }
        }

        protected void cargarListaEspecialidades()
        {
            try
            {
                List<Especialidad> Lista = especialidadNegocio.Listar();
                ddlEspecialidad.DataSource = Lista;
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "Id";
                ddlEspecialidad.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de Especialidades: " + ex.Message);
            }

        }

        protected void cargarListaProfesionales()
        {
            try
            {
                List<Profesional> Lista = profesionalNegocio.Listar();
                dgvMedicos.DataSource = Lista;
                dgvMedicos.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de Medicos: " + ex.Message);
            }

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
            txtId.Text = "";
            txtIdProfesional.Text = "";
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
