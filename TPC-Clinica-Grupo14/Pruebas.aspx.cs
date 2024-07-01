using System;
using System.Collections.Generic;
using System.Globalization;
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
            try
            { 
                if (!IsPostBack)
                {

                    RolNegocio rn = new RolNegocio();
                    List<Rol> listaRoles = new List<Rol>();
                    listaRoles = rn.Listar();

                    EspecialidadNegocio en = new EspecialidadNegocio();
                    List<Especialidad> listaEspecialidades = new List<Especialidad>();
                    listaEspecialidades = en.Listar();

                    ProfesionalNegocio pn = new ProfesionalNegocio();
                    List<Profesional> listaProfesionales = new List<Profesional>();
                    listaProfesionales = pn.Listar();

                    GridPruebaRoles.DataSource = listaRoles;
                    GridPruebaRoles.DataBind();

                    

                    DropDownListEspecialidades.DataSource = listaEspecialidades;
                    DropDownListEspecialidades.DataTextField = "Nombre";
                    DropDownListEspecialidades.DataValueField = "Id";
                    Session.Add("listaEspecialidades", listaEspecialidades);     //agrego a la sesion asi no vuelvo a abrir la BD
                    Session.Add("listaProfesionales", listaProfesionales);       //agrego a la sesion asi no vuelvo a abrir la BD
                    
                    DropDownListEspecialidades.DataBind();
                    DropDownListEspecialidades.SelectedIndex = 0;               //1er elemento

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///////////////////////////////////////
        //ACA ESTAN LOS EVENTOS DE INDEX CHANGE
        ///////////////////////////////////////
        protected void DropDownListEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedItem.Value);
            
            List<Profesional> listaProfesionalesAMostrar = new List<Profesional>();

            foreach (Profesional p in (List<Profesional>)Session["listaProfesionales"])
            {
                if (p.Especialidades.Find(x => x.Id == idEspecialidad) != null)
                {
                    listaProfesionalesAMostrar.Add(p);  //CARGO LA LISTA DE PROFESIONALES QUE TIENEN LA ESPECIALIDAD SELECCIONADA
                }
            }
            //Revisar la posibilidad de vacias este elemento de la sesion y volverlo a cargar...por las dudas...
            Session.Add("listaProfesionalesAMostrar", listaProfesionalesAMostrar);

            DropDownListProfesionales.DataSource = listaProfesionalesAMostrar;
            DropDownListProfesionales.DataTextField = "Nombre";
            DropDownListProfesionales.DataValueField = "IdProfesional";
            DropDownListProfesionales.DataBind();

            DropDownListProfesionales_SelectedIndexChanged(sender, e);          //Fuerzo el evento
            //CalendarioTurnos_DayRender(sender, e);                            //Fuerzo el evento  

            //DropDownListDia.Items.Clear();
            //DropDownListHorariosDisponibles.Items.Clear();

            //DropDownListHorariosDisponibles.SelectedIndex = -1; //fuerzo el cambio
            //se necesita esto?

        }

        protected void DropDownListProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);

            Profesional prof = new Profesional();
            prof = ((List<Profesional>)Session["listaProfesionalesAMostrar"]).Find(x=>x.IdProfesional==idProf);

            List<string> DiasDisponibles = new List<String>();      //aca defino la lista de DIAS
            foreach (Horario h in prof.ListHorariosDisponibles)
            {
                DiasDisponibles.Add(h.Dia.ToString());              //CARGO LA LISTA DE DIAS DISPONIBLES EN BASE AL PROFESIONAL SELECCIONADO
            }

            DropDownListDia.DataSource = DiasDisponibles;
            DropDownListDia.DataBind();

            Session.Add("listaDiasDisponibles",DiasDisponibles);

            DropDownListDia_SelectedIndexChanged(sender, e);      
        }

        //
        //  VER ESTE EVENTO DIA NO PINTA LOS DIAS!
        //
        protected void DropDownListDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
            Profesional prof = new Profesional();
            prof = ((List<Profesional>)Session["listaProfesionalesAMostrar"]).Find(x => x.IdProfesional == idProf);     //Busco profesional...

            string DiaSeleccionado = DropDownListDia.SelectedValue;
            Horario h = new Horario();
            h = prof.ListHorariosDisponibles.Find(x => x.Dia.ToString() == DiaSeleccionado);

            List<string> horas = new List<string>();
            horas = h.ObtenerHoras();

            DropDownListHorariosDisponibles.DataSource = horas;
            DropDownListHorariosDisponibles.DataBind();

            Session.Add("listaHorasDisponibles", horas);

            //DropDownListHorariosDisponibles_SelectedIndexChanged(sender, e);             //comentada por estar en visible=false
        }

        //
        //  VER ESTE EVENTO HORA NO PINTA LOS DIAS!
        //
        protected void DropDownListHorariosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidad_selected=DropDownListEspecialidades.SelectedItem.ToString();
            string profesional_selected=DropDownListProfesionales.SelectedItem.ToString();
            string dia_selected = DropDownListDia.SelectedItem.ToString();
            string hora_selected=DropDownListHorariosDisponibles.SelectedItem.ToString();
            
            LabelInfoTurno.Text =
                "INFO:" +
                " Especialidad: " + especialidad_selected +
                " Profesional: " + profesional_selected +
                " Dia: " + dia_selected +
                " Hora: " + hora_selected;
        }

        protected void CalendarioTurnos_DayRender(object sender, DayRenderEventArgs e)
        { 
            List<string> DiasDisponibles = new List<string>();
            List<string> DiasOcupados = new List<string>();

            DiasDisponibles = (List<string>)Session["listaDiasDisponibles"];        //recupero los dias disponibles
            //DiasDisponibles = (List<string>)DropDownListDia.DataSource;
            if (DiasDisponibles == null)
            {
                //no hago nada porque aun no cargue opciones
            }
            else if (DiasDisponibles.Contains(e.Day.Date.DayOfWeek.ToString()))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Cell.ToolTip = "Dia Busyyyyyy";
            }

            /*
            Days.Add(DayOfWeek.Monday);
            Days.Add(DayOfWeek.Wednesday);
            Days.Add(DayOfWeek.Friday);

       
            if(Days.Contains(e.Day.Date.DayOfWeek))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Cell.ToolTip = "Dia Busi";
            }
            */
        }

        //De aca tengo que tomar la fecha
        //TODO
        //NO MANTIENE PINTADA LOS DIAS
        protected void CalendarioTurnos_SelectionChanged(object sender, EventArgs e)
        {
            //tengo que volver a pintar los dias
            CalendarioTurnos.DataBind();
            DateTime fechaSeleccionada = CalendarioTurnos.SelectedDate;
            LabelTurnoSeleccionado.Text = fechaSeleccionada.Date.ToString("dd/MM/yyyy");    //Pido la fecha en este formato
        }




        ////////////////////////////////////
        //ACA ESTAN LOS EVENTOS DE DATABOUND
        ////////////////////////////////////
        //protected void DropDownListEspecialidades_DataBound(object sender, EventArgs e)
        //{
        //    List<Especialidad> le = new List<Especialidad>();
        //    le = (List<Especialidad>)Session["listaEspecialidades"];        //Recupero la lista especialidades completa

        //    DropDownListEspecialidades.SelectedValue = le[0].Id.ToString(); //Muestro la 1era especialidad
        //    int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedItem.Value);


        //    //////POR ACA GONZOOOO
        //    //////POR ACA GONZOOOO
        //    //////POR ACA GONZOOOO!!!!!!
        //    //TODO BINDEAR EL RESTO DE LOS DDL
        //}

        //protected void DropDownListProfesionales_DataBound(object sender, EventArgs e)
        //{

        //}

        //protected void DropDownListHorariosDisponibles_DataBound(object sender, EventArgs e)
        //{

        //}
    }
}