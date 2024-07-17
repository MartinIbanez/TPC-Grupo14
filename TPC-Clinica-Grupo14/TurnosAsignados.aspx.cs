using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Clinica_Grupo14
{
    public partial class TurnosAsignados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    //EspecialidadNegocio en = new EspecialidadNegocio();
                    //List<Especialidad> listaEspecialidades = new List<Especialidad>();
                    //listaEspecialidades = en.Listar();

                    ProfesionalNegocio pn = new ProfesionalNegocio();
                    List<Profesional> listaProfesionales = new List<Profesional>();
                    listaProfesionales = pn.Listar();

                    //PersonaNegocio personaNegocio = new PersonaNegocio();
                    //List<Persona> listaPacientes = new List<Persona>();
                    //listaPacientes = personaNegocio.ListarPacientes();

                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = new List<Turno>();
                    //listaTurnos = turnoNegocio.Listar();

                    //int idProfesional = int.Parse(DropDownListProfesionales.SelectedValue);

                    DropDownListProfesionales.DataSource = listaProfesionales;
                    DropDownListProfesionales.DataTextField = "Nombre";
                    DropDownListProfesionales.DataValueField = "IdProfesional";
                    DropDownListProfesionales.DataBind();
                    //Muestro el 1er profesional disponible
                    DropDownListProfesionales.SelectedIndex = 0;


                    listaTurnos = turnoNegocio.ListarTurnosAsignadosPorProfesional(listaProfesionales[0]);
                    if (listaTurnos != null)    //HAY TURNOS PARA PROFESIONAL SELECTED
                    {
                        Repeater1.DataSource = listaTurnos;
                        Repeater1.DataBind();
                        Repeater1.Visible = true;
                        lblProfNoDisp.Visible = false;
                    }
                    else
                    {
                        Repeater1.Visible = false;
                        lblProfNoDisp.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DropDownListProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            List<Turno> listaTurnosDeProfesional = new List<Turno>();

            ProfesionalNegocio pn = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = pn.Listar();

            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);


            Profesional prof = listaProfesionales.Find(x => x.IdProfesional == idProf);

            listaTurnosDeProfesional = turnoNegocio.ListarTurnosAsignadosPorProfesional(prof);


            if (listaTurnosDeProfesional != null)    //HAY TURNOS PARA PROFESIONAL SELECTED
            {
                Repeater1.DataSource = listaTurnosDeProfesional;
                Repeater1.DataBind();
                Repeater1.Visible = true;
                lblProfNoDisp.Visible = false;
            }
            else
            {
                Repeater1.Visible=false;
                lblProfNoDisp.Visible = true;
            }

        }
    }
}