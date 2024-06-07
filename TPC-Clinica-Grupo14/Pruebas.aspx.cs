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
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Levanto datos Personas//
            PersonaNegocio pn = new PersonaNegocio();
            //List<Persona> listaPersonas = new List<Persona>();
            //listaPersonas = pn.Listar();
            //Levanto datos Roles//
            RolNegocio rn = new RolNegocio();
            List<Rol> listaRoles = new List<Rol>();
            listaRoles = rn.Listar();
            //Levanto datos Especialidades//
            EspecialidadNegocio en = new EspecialidadNegocio();
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            listaEspecialidades = en.Listar();
            try
            {
                if (!IsPostBack)
                {
                    GridPruebaRoles.DataSource = listaRoles;
                    GridPruebaRoles.DataBind();

                    DropDownListEspecialidades.DataSource = listaEspecialidades;
                    DropDownListEspecialidades.DataTextField = "Nombre";
                    DropDownListEspecialidades.DataValueField = "Id";
                    DropDownListEspecialidades.DataBind();

                    //GridPruebaPersonas.DataSource = listaPersonas;
                    //GridPruebaPersonas.DataBind();

                    //GridPruebasEspecialidades.DataSource = listaEspecialidades;
                    //GridPruebasEspecialidades.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}