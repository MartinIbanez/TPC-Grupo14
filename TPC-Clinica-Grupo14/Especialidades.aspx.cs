using System;
using System.Collections;
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
            
            try
            {
                string nuevaEspecialidad = "";
                nuevaEspecialidad = txtNombre.Text;
                List<Especialidad> Lista = especialidadNegocio.Listar();

                if (!existeEspecialidad(nuevaEspecialidad))
                {
                    if (!Lista.Any(especialidad => especialidad.Nombre == nuevaEspecialidad) && !string.IsNullOrEmpty(nuevaEspecialidad))
                    {
                        especialidadNegocio.agregarEspecialidad(nuevaEspecialidad);
                        cargarListaEspecialidades();
                        Clear();
                       
                        //agregar aca cartel de especialidad agregada con exito
                       
                    }

                }
                else
                {
                   //agregar aca un cartel que diga no se pudo agregar la especialidad ingresada

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar nueva especialidad: " + ex.Message);
            }




        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                int idEspecialidad = Convert.ToInt32(txtId.Text);
                string nuevaNombre = txtNombre.Text;

                if (!existeEspecialidad(nuevaNombre))
                {
                    Especialidad especialidadEditada = new Especialidad
                    {
                        Id = idEspecialidad,
                        Nombre = nuevaNombre
                    };

                    especialidadNegocio.modificarEspecialidad(especialidadEditada);


                    cargarListaEspecialidades();

                    Console.WriteLine("Modificado con exito " );

                    Clear();
                }
                else
                {
                    Console.WriteLine("Error al modificar la especialidad, ya existe ");
                     
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar la especialidad: " + ex.Message);
            }
        }

    

    protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProfesionalesXEspecialidadNegocio ProEsp = new ProfesionalesXEspecialidadNegocio();
                List<ProfesionalesXEspecialidad> ProEspLista = ProEsp.Listar();

                int idEsp = Convert.ToInt32(txtId.Text);
                bool especialidadAsignada = ProEspLista.Any(proxesp => proxesp.IdEspecialidad == idEsp);

                if (!especialidadAsignada)
                {
                    especialidadNegocio.eliminarEspecialidad(idEsp);
                    cargarListaEspecialidades(); 
                    Clear();
                    
                   
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar, existe algun medico asociado a esta especialidad");
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo eliminar especialidad");
            }
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

        private bool existeEspecialidad(string especialidad)
        {
            List<Especialidad> lista = especialidadNegocio.Listar();

            return lista.Any(e => e.Nombre.Equals(especialidad, StringComparison.OrdinalIgnoreCase));
        }
    }
}