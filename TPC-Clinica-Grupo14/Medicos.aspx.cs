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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaProfesionales();

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
    }
}