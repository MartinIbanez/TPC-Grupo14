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
                listaPacientes = personaNegocio.ListarPaciente();
                dgvPacientes.DataSource = listaPacientes;
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
            if (int.TryParse(dgvPacientes.DataKeys[row.RowIndex].Value.ToString(), out int id))
            {
                txtId.Text = id.ToString();
                txtNombre.Text = row.Cells[0].Text;
                txtApellido.Text = row.Cells[1].Text;
                txtFechaNacimiento.Text = row.Cells[2].Text;
                int Idgenero = Convert.ToInt32(row.Cells[3].Text);

                if (Idgenero == 1)
                {
                    txtGenero.Text = "Masculino";
                }
                else
                {
                    if (Idgenero == 2)
                    {
                        txtGenero.Text = "Femenino";
                    }
                    else
                    {
                        txtGenero.Text = "Otro";
                    }
                }

                txtDNI.Text = row.Cells[4].Text;
                txtCorreo.Text = row.Cells[5].Text;
                txtTelefono.Text = row.Cells[6].Text;

                // Obtener datos adicionales del objeto persona basado en el Id
                Persona persona = personaNegocio.ObtenerPacientePorId(id);

                if (persona != null)
                {

                    txtActivo.Text = persona.Activo ? "Sí" : "No";
                }
            }

        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.NumDoc = txtDNI.Text;
            persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            persona.IdRol = 4;

            try
            {
                personaNegocio.AgregarPaciente(persona);
                CargarPacientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.Message);
            }


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
            txtGenero.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtActivo.Text = string.Empty;
        }



    }
}
