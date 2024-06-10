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
            //PersonaNegocio pn = new PersonaNegocio();
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
            //Levato datos Profesionales
            ProfesionalNegocio pn = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = pn.Listar();
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
                    Session.Add("listaEspecialidades", listaEspecialidades);     //agrego a la sesion asi no vuelvo a abrir la BD

                    //DropDownListProfesionales.DataSource = listaProfesionales;
                    //DropDownListProfesionales.DataTextField = "Nombre";
                    //DropDownListProfesionales.DataValueField = "Id";
                    //DropDownListProfesionales.DataBind();
                    Session.Add("listaProfesionales", listaProfesionales);     //agrego a la sesion asi no vuelvo a abrir la BD

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

        protected void DropDownListEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedItem.Value);
            List<Profesional> listaProfesionalesAMostrar = new List<Profesional>();

            foreach (Profesional p in (List<Profesional>)Session["listaProfesionales"])
            {
                if (p.Especialidades.Find(x => x.Id == idEspecialidad) != null)
                {
                    listaProfesionalesAMostrar.Add(p);
                }
            }
            DropDownListProfesionales.DataSource = listaProfesionalesAMostrar;
            DropDownListProfesionales.DataTextField = "Nombre";
            DropDownListProfesionales.DataValueField = "Id";
            DropDownListProfesionales.DataBind();
        }
    }
}