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
            try
            {
                List<Persona> listaPacientes = personaNegocio.ListarPacientes();
                dgvPacientes.DataSource = listaPacientes;
                dgvPacientes.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar pacientes: " + ex.Message);
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
                txtGenero.SelectedValue = row.Cells[3].Text; // Asigna el valor correcto del género
                txtDNI.Text = row.Cells[4].Text;
                txtCorreo.Text = row.Cells[5].Text;
                txtTelefono.Text = row.Cells[6].Text;

                // Obtener datos adicionales del objeto persona basado en el Id
                Persona persona = personaNegocio.ObtenerPacientePorId(id);

                if (persona != null)
                {
                    txtActivo.SelectedValue = persona.Activo ? "true" : "false";
                }
            }
        }

        // Método para mostrar el nombre del género en la grilla
        protected void dgvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra la celda que contiene el Id del género
                TableCell generoCell = e.Row.Cells[3];

                // Obtén el Id del género
                string idGenero = generoCell.Text;


                switch (idGenero)
                {
                    case "1":
                        generoCell.Text = "Masculino";
                        break;
                    case "2":
                        generoCell.Text = "Femenino";
                        break;
                    case "3":
                        generoCell.Text = "Otro";
                        break;
                    default:
                        generoCell.Text = "Desconocido";
                        break;
                }
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el DNI está vacío
                if (string.IsNullOrWhiteSpace(txtDNI.Text))
                {
                    Response.Write("<script>alert('Error: El campo DNI no puede estar vacío');</script>");
                    return;
                }

                string numDoc = txtDNI.Text;

                // Verificar si ya existe un paciente con el mismo DNI
                List<Persona> listaPacientes = personaNegocio.ListarPacientes();
                if (listaPacientes.Any(p => p.NumDoc == numDoc))
                {
                    // Mostrar mensaje de error si ya existe un paciente con el mismo DNI
                    Response.Write("<script>alert('Error: Ya existe un paciente con ese DNI');</script>");
                    return;
                }


                // Crear una nueva instancia de Persona con los datos ingresados
                Persona persona = new Persona
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    IdGenero = Convert.ToInt32(txtGenero.SelectedValue),
                    NumDoc = txtDNI.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    // si no se ingreso la condicion de activo ponerlo por defecto como activo
                    Activo = txtActivo.Text.ToLower() == "sí",
                    IdRol = 4 // Asignar el rol de paciente
                };

                personaNegocio.AgregarPaciente(persona);
                CargarPacientes();
                LimpiarCampos();
                Response.Write("<script>alert('Paciente agregado con éxito');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("Error al agregar paciente: " + ex.Message);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el DNI está vacío
                if (string.IsNullOrWhiteSpace(txtDNI.Text))
                {
                    Response.Write("<script>alert('Error: El campo DNI no puede estar vacío');</script>");
                    return;
                }

                // Obtener los valores de los campos de texto
                int idPaciente = Convert.ToInt32(txtId.Text);
                string numDoc = txtDNI.Text;

                // Verificar si el paciente ya existe en la base de datos por su DNI
                List<Persona> listaPacientes = personaNegocio.ListarPacientes();
                if (listaPacientes.Any(p => p.NumDoc == numDoc && p.Id != idPaciente))
                {
                    // Mostrar mensaje de error si el paciente con el mismo DNI ya existe pero tiene un ID diferente
                    Response.Write("<script>alert('Error: Ya existe un paciente con ese DNI');</script>");
                    return;
                }

                // Crear una instancia de Persona con los nuevos datos
                Persona pacienteModificado = new Persona
                {
                    Id = idPaciente,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                    IdGenero = Convert.ToInt32(txtGenero.SelectedValue),
                    NumDoc = numDoc,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Activo = txtActivo.SelectedValue == "true",
                    IdRol = 4 // Asignar el rol de paciente
                };

                // Llamar al método para modificar el paciente en la base de datos
                personaNegocio.ModificarPaciente(pacienteModificado);

                // Recargar la lista de pacientes
                CargarPacientes();
                LimpiarCampos();
                Response.Write("<script>alert('Paciente modificado con éxito');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("Error al modificar el paciente: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener el ID del paciente a eliminar
                int idPaciente = Convert.ToInt32(txtId.Text);

                // Llamar al método para eliminar el paciente de la base de datos
                personaNegocio.EliminarPaciente(idPaciente);

                // Recargar la lista de pacientes
                CargarPacientes();
                LimpiarCampos();
                Response.Write("<script>alert('Paciente eliminado con éxito');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("Error al eliminar el paciente: " + ex.Message);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

  
        private void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtGenero.SelectedIndex = 0; // Resetear a la primera opción
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtActivo.SelectedIndex = 0; // Resetear a la primera opción
        }



    }
}
