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
                txtGenero.Text = row.Cells[3].Text;
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

        // Método para mostrar el nombre del género en la grilla
        protected void dgvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Idgenero = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdGenero"));
                string nombreGenero = ObtenerNombreGenero(Idgenero);
                e.Row.Cells[3].Text = nombreGenero;
            }
        }


        // Método para obtener el nombre del género
        private string ObtenerNombreGenero(int idGenero)
        {
            switch (idGenero)
            {
                case 1:
                    return "Masculino";
                case 2:
                    return "Femenino";
                default:
                    return "Otro";
            }
        }



        // Método para obtener el Id del género
        private int ObtenerGeneroId(string genero)
        {
            switch (genero.ToLower())
            {
                case "masculino":
                    return 1;
                case "femenino":
                    return 2;
                default:
                    return 3; // Otro
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
            try
            {
                // Obtener los valores de los campos de texto
                int idPaciente = Convert.ToInt32(txtId.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                int idGenero = ObtenerGeneroId(txtGenero.Text);
                string numDoc = txtDNI.Text;
                string correo = txtCorreo.Text;
                string telefono = txtTelefono.Text;
                bool activo = txtActivo.Text.ToLower() == "sí";

                // Verificar si el paciente ya existe en la base de datos por su DNI
                List<Persona> listaPacientes = personaNegocio.ListarPaciente();
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
                    Nombre = nombre,
                    Apellido = apellido,
                    FechaNacimiento = fechaNacimiento,
                    IdGenero = idGenero,
                    NumDoc = numDoc,
                    Correo = correo,
                    Telefono = telefono,
                    Activo = activo,
                    IdRol = 4 // Asignar el rol de paciente
                };

                // Llamar al método para modificar el paciente en la base de datos
                personaNegocio.ModificarPaciente(pacienteModificado);

                // Recargar la lista de pacientes
                CargarPacientes();

                // Limpiar los campos de texto
                LimpiarCampos();

                // Mostrar mensaje de éxito
                Response.Write("<script>alert('Paciente modificado con éxito');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al modificar el paciente: " + ex.Message + "');</script>");
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

                // Limpiar los campos de texto
                LimpiarCampos();

                // Mostrar mensaje de éxito
                Response.Write("<script>alert('Paciente eliminado con éxito');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al eliminar el paciente: " + ex.Message + "');</script>");
            }

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
