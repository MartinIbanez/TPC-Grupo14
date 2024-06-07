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
            PersonaNegocio pn = new PersonaNegocio();
            List<Persona> listaPersonas = new List<Persona>();
            listaPersonas = pn.Listar();
            RolNegocio rn = new RolNegocio();
            List<Rol> listaRoles= new List<Rol>();
            listaRoles = rn.Listar();

            if (!IsPostBack)
            {
                GridPruebaRoles.DataSource = listaRoles;
                GridPruebaRoles.DataBind();

                GridPruebaPersonas.DataSource = listaPersonas;
                GridPruebaPersonas.DataBind();
            }
        }
    }
}