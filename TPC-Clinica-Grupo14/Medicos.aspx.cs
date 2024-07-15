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
        private ProfesionalNegocio profesionalNegocio   = new ProfesionalNegocio();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                cargarListaProfesionales();


            }
        }


        protected void cargarListaProfesionales()
        {


            /// SI BIEN btnAgregar FUCIONA Y AGREGA A LA BASE DE DATOS, NO SE REFRESCA LA GRILLA.. REVISAR..
            dgvMedicos.DataSource = profesionalNegocio.Listar();
            dgvMedicos.DataBind();




        }



        // aca redirigimos a la pagina de detalle de profesional si es que quiero agregar uno nuevo
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleMedicos.aspx");
        }




        // aca redirigimos a la pagina de detalle de profesional si es que quiero modificar uno existente
        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del profesional seleccionado
            GridViewRow row = dgvMedicos.SelectedRow;

            // en la Db el idProfesional es un smallint 
            int idProfesional = Convert.ToInt32(row.Cells[0].Text);

            // Redirigir a la página de detalles del profesional
            Response.Redirect("DetalleMedicos.aspx?idProfesional=" + idProfesional);

        }

    }
}
