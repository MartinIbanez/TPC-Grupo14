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
    public partial class Especialidades : System.Web.UI.Page
    {
        private EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaEspecialidades();
            }
        }

        protected void cargarListaEspecialidades()
        {
            try
            {
                List<Especialidad> Lista = especialidadNegocio.Listar();
                dgvEspecialidades.DataSource = Lista;
                dgvEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de especialidades: " + ex.Message);
            }
        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvEspecialidades.SelectedRow;
                txtId.Text = HttpUtility.HtmlDecode(row.Cells[0].Text); 
                txtNombre.Text = HttpUtility.HtmlDecode(row.Cells[1].Text); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar la especialidad: " + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Código para agregar una nueva especialidad
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Código para modificar una especialidad existente
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Código para modificar una especialidad existente
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
    }
}