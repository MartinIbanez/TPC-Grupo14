using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Clinica_Grupo14
{
    public partial class Pacientes : Page
    {
        private PersonaNegocio personaNegocio = new PersonaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }





        private void CargarPacientes()
        {
            List<Persona> listaPacientes = new List<Persona>();

            try
            {
                List<Persona> Lista = personaNegocio.Listar();

                // asigna en la listaPaciente  con IDRol = 4 ,solo los pacientes de la lista Lista.
                // Filtrar personas con IDRol = 4
                listaPacientes = Lista.Where(p => p.IdRol == 4).ToList();


                dgvPacientes.DataSource = listaPacientes;
                // filtraciones de datos para mostrar solo los pacientes
                dgvPacientes.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("error" + ex.Message);
            }

        }




        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvPacientes.SelectedRow;
            txtId.Text = row.Cells[0].Text;
            txtNombre.Text = row.Cells[1].Text;
            txtApellido.Text = row.Cells[2].Text;
            txtDNI.Text = row.Cells[3].Text;
            txtFechaNacimiento.Text = row.Cells[4].Text;
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

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarPacientes();


        }


        private void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
        }



    }
}
