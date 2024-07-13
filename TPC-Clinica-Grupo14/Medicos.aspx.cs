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
                ddlEspecialidad.DataSource = especialidadNegocio.Listar();
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "Id";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));
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
            GridViewRow row = dgvMedicos.SelectedRow;
            txtNombre.Text = row.Cells[1].Text;
            txtApellido.Text = row.Cells[2].Text;
            txtFechaNacimiento.Text = row.Cells[3].Text;
            txtDNI.Text = row.Cells[4].Text;
            txtCorreo.Text = row.Cells[5].Text;
            txtTelefono.Text = row.Cells[6].Text;

            
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
