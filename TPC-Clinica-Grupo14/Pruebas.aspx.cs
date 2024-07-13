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

                    PersonaNegocio personaNegocio = new PersonaNegocio();
                    List<Persona> listaPacientes = new List<Persona>();
                    listaPacientes = personaNegocio.ListarPacientes();

                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = new List<Turno>();
                    listaTurnos = turnoNegocio.Listar();

                    //GridPruebaRoles.DataSource = listaRoles;
                    //GridPruebaRoles.DataBind();

                    GridPruebaTurnos.DataSource = listaTurnos;
                    GridPruebaTurnos.DataBind();

                    DropDownListEspecialidades.DataSource = listaEspecialidades;
                    DropDownListEspecialidades.DataTextField = "Nombre";
                    DropDownListEspecialidades.DataValueField = "Id";
                    //Session.Add("listaEspecialidades", listaEspecialidades);     //agrego a la sesion asi no vuelvo a abrir la BD
                    //Session.Add("listaProfesionales", listaProfesionales);       //agrego a la sesion asi no vuelvo a abrir la BD
                    

                    DropDownListEspecialidades.DataBind();
                    DropDownListEspecialidades.SelectedIndex = 0;               //1er elemento

                    DropDownListPacientes.DataSource = listaPacientes;
                    DropDownListPacientes.DataTextField = "Nombre";
                    DropDownListPacientes.DataValueField = "Id";
                    DropDownListPacientes.DataBind();


                    //VER ESTO!BORRAR?
                    //Session.Add("listaPacientes", listaPacientes);


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
            ProfesionalNegocio profNegocio = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNegocio.Listar();

            int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedValue);
            
            List<Profesional> listaProfesionalesAMostrar = new List<Profesional>();

            foreach (Profesional p in listaProfesionales)
            {
                if (p.Especialidades.Find(x => x.Id == idEspecialidad) != null)
                {
                    //CARGO LA LISTA DE PROFESIONALES QUE TIENEN LA ESPECIALIDAD SELECCIONADA
                    listaProfesionalesAMostrar.Add(p);  
                }
            }
            //Revisar la posibilidad de vacias este elemento de la sesion y volverlo a cargar...por las dudas...
            //Session.Add("listaProfesionalesAMostrar", listaProfesionalesAMostrar);

            DropDownListProfesionales.DataSource = listaProfesionalesAMostrar;
            DropDownListProfesionales.DataTextField = "Nombre";
            DropDownListProfesionales.DataValueField = "IdProfesional";
            DropDownListProfesionales.DataBind();

            DropDownListProfesionales.SelectedIndex = 0;        //Muestro el 1er profesional disponible
            CalendarioTurnos.Visible = true;                    //Con esto lo habilito y se dispara el evento DayRender
            
           
            
            CardEspecialidad.Text=DropDownListEspecialidades.SelectedItem.ToString();
            CardProfesional.Text=DropDownListProfesionales.SelectedItem.ToString();
            DropDownListHorariosDisponibles.Visible = false;  //Porque debo volver a seleccionar el dia
        }

        protected void DropDownListProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfesionalNegocio profNegocio = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNegocio.Listar();

            //Levanto el profesional selected...
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);

            Profesional prof = new Profesional();
            
            prof = listaProfesionales.Find(x => x.IdProfesional == idProf);

            //int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedValue);

            //List<Profesional> listaProfesionalesAMostrar = new List<Profesional>();

            //foreach (Profesional p in listaProfesionales)  
            //{
            //    if (p.Especialidades.Find(x => x.Id == idEspecialidad) != null)
            //    {
            //        listaProfesionalesAMostrar.Add(p);  //CARGO LA LISTA DE PROFESIONALES QUE TIENEN LA ESPECIALIDAD SELECCIONADA
            //    }
            //}
            
            CardProfesional.Text = prof.Nombre;
            DropDownListHorariosDisponibles.Visible=false;  //Porque debo volver a seleccionar el dia
        }

        //
        //  VER ESTE EVENTO DIA NO PINTA LOS DIAS!
        //

        //ESTE EVENTO Y ESTE CONTROL NO VA MAS, USAMOS CALENDARIO...
        //protected void DropDownListDia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
        //    Profesional prof = new Profesional();
        //    prof = ((List<Profesional>)Session["listaProfesionalesAMostrar"]).Find(x => x.IdProfesional == idProf);     //Busco profesional...

        //    string DiaSeleccionado = DropDownListDia.SelectedValue;
        //    Horario h = new Horario();
        //    h = prof.ListHorariosDisponibles.Find(x => x.Dia.ToString() == DiaSeleccionado);

        //    DropDownListHorariosDisponibles.DataSource = h;
        //    DropDownListHorariosDisponibles.DataValueField = "Id";
        //    DropDownListHorariosDisponibles.DataTextField = "HoraInicio";
        //    DropDownListHorariosDisponibles.DataBind();

        //    Session.Add("listaHorasDisponibles", h);

        //    DropDownListHorariosDisponibles_SelectedIndexChanged(sender, e);             //comentada por estar en visible=false
        //}

        //
        //  VER ESTE EVENTO HORA NO PINTA LOS DIAS!
        //Este aparecera visible SOLO despues de seleccionar el dia
        //


        //POR ACA GONZOOO
        //MOSTRAR TODAY EN CALENDARIO Y PINTAR EN CONSECUENCIA!!


        protected void CalendarioTurnos_DayRender(object sender, DayRenderEventArgs ev)
        {
            //Selecciono el dia de hoy...
            DateTime today = DateTime.Now;
            CalendarioTurnos.SelectedDate = today;

            Profesional profSelected = new Profesional();
            ProfesionalNegocio profNeg = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNeg.Listar();

            //DropDownListProfesionales.DataSource = listaProfesionales;  //la inicio para la 1er carga
            //DropDownListProfesionales.DataTextField = "Nombre";
            //DropDownListProfesionales.DataValueField = "IdProfesional";
            //DropDownListProfesionales.DataBind();
            //DropDownListProfesionales.SelectedValue = null;

            //Levanto el profesional selected...
            if(DropDownListProfesionales.SelectedValue != "")
            {
                int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
                profSelected = listaProfesionales.Find(x=>x.IdProfesional==idProf);


                //List<Horario> Horarios = new List<Horario>();
                //List<DayOfWeek> DaysDisponibles = new List<DayOfWeek>();
                DateTime diaRender = ev.Day.Date;

                //Me quedo con los dias filtrados
                List<DayOfWeek> listaDiasFiltrada = profSelected.ListHorariosDisponibles.Select(x => x.Dia).Distinct().ToList();
            
                //FALTA PINTAR DE ROJO LOS DIAS TOTALMENTE OCUPADOS
                if((diaRender >= today))                    //Pregunto a partir de hoy en adelante, con hora real y todo, el pasado no interesa
                {
                    foreach(DayOfWeek d in listaDiasFiltrada)
                    {
                        if(diaRender.DayOfWeek == d)        //Si el dia a renderizar esta en los disponibles, pintar
                        {
                            ev.Cell.BackColor = System.Drawing.Color.LightGreen;
                            ev.Cell.ToolTip = "Dia Disponibleeeeee";
                        }
                    }
                }
            }
           // DropDownListHorariosDisponibles.Visible = true;    //Muestro horarios , primero debe seleccionar el dia...
        }

        
        protected void CalendarioTurnos_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = CalendarioTurnos.SelectedDate;
            DayOfWeek DiaSeleccionado = CalendarioTurnos.SelectedDate.DayOfWeek;

            Profesional profSelected = new Profesional();
            ProfesionalNegocio profNeg = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNeg.Listar();

            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
            profSelected = listaProfesionales.Find(x => x.IdProfesional == idProf);

            List<Horario> horariosAMostrar = new List<Horario>();
            
            foreach(Horario h in profSelected.ListHorariosDisponibles)
            {
                if(h.Dia == DiaSeleccionado)
                {
                    horariosAMostrar.Add(h);
                }
            }

            DropDownListHorariosDisponibles.DataSource = horariosAMostrar;
            DropDownListHorariosDisponibles.DataValueField = "Id";
            DropDownListHorariosDisponibles.DataTextField = "HoraInicio";
            DropDownListHorariosDisponibles.DataBind();
            DropDownListHorariosDisponibles.Visible = true;

        }

        protected void DropDownListHorariosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string especialidad_selected=DropDownListEspecialidades.SelectedItem.ToString();
            //string profesional_selected=DropDownListProfesionales.SelectedItem.ToString();
            //string dia_selected = CalendarioTurnos.SelectedDate.Day.ToString();
            ////string dia_selected = DropDownListDia.SelectedItem.ToString();
            //string hora_selected=(int.Parse((DropDownListHorariosDisponibles.SelectedItem).ToString())).ToString("D2") + ":00";
            
            //LabelInfoTurno.Text =
            //    "INFO:" +
            //    " Especialidad: " + especialidad_selected +
            //    " Profesional: " + profesional_selected +
            //    " Dia: " + dia_selected +
            //    " Hora: " + hora_selected;
        }
        protected void btnCrearTurno_Click(object sender, EventArgs e)
        {
            LabelTurnoCreado.Visible = true;
            TimerTurnoCreado.Enabled = true;    //Disparo el timer para mostrar confirmacion de turno!
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            Turno nuevo = new Turno();

            PersonaNegocio personaNegocio = new PersonaNegocio();
            List<Persona> listaPacientes = new List<Persona>();
            listaPacientes = personaNegocio.ListarPacientes();

            Profesional profSelected = new Profesional();
            ProfesionalNegocio profNeg = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNeg.Listar();

            EspecialidadNegocio en = new EspecialidadNegocio();
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            listaEspecialidades = en.Listar();

            //POR ACA GOOONNZOOOOO!!!
            //POR ACA GOOONNZOOOOO!!!
            //POR ACA GOOONNZOOOOO!!!
            //Funciona levantar la hora?
            nuevo.FechaTurno = CalendarioTurnos.SelectedDate;
            nuevo.HoraTurno = int.Parse(DropDownListHorariosDisponibles.SelectedValue.ToString());

            int idPaciente = int.Parse(DropDownListPacientes.SelectedValue);                                                        //id paciente seleccionado
            nuevo.PacienteTurno = listaPacientes.Find(x=>x.Id == idPaciente);                           //busco por id paciente

            int idProfesional = int.Parse(DropDownListProfesionales.SelectedValue);                                                 //id profesional seleccionado
            nuevo.ProfesionalTurno = listaProfesionales.Find(x=>x.IdProfesional == idProfesional);

            int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedValue);
            nuevo.EspecialidadTurno = listaEspecialidades.Find(x => x.Id == idEspecialidad);

            nuevo.EstadoTurno = 0;      //ABIERTO

            nuevo.Observaciones = "";

            turnoNegocio.Agregar(nuevo);
        }
        protected void DropDownListPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardPaciente.Text=DropDownListPacientes.SelectedItem.ToString();    //actualizo la ficha turno
        }

        protected void TimerTurnoCreado_Tick(object sender, EventArgs e)
        {
            LabelTurnoCreado.Visible = false;
            TimerTurnoCreado.Enabled = false;
        }

        //protected void dgvProfesionales_Load(object sender, EventArgs e)
        //{
        //    ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
        //    List<Profesional> lista = new List<Profesional>();

        //    lista = profesionalNegocio.Listar();

        //    dgvProfesionales.DataSource = lista;
        //    dgvProfesionales.DataBind();
        //}





        ////////////////////////////////////
        //ACA ESTAN LOS EVENTOS DE DATABOUND
        ////////////////////////////////////
        //protected void DropDownListEspecialidades_DataBound(object sender, EventArgs e)
        //{
        //    List<Especialidad> le = new List<Especialidad>();
        //    le = (List<Especialidad>)Session["listaEspecialidades"];        //Recupero la lista especialidades completa

        //    DropDownListEspecialidades.SelectedValue = le[0].Id.ToString(); //Muestro la 1era especialidad
        //    int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedItem.Value);


     
        //}

        //protected void DropDownListProfesionales_DataBound(object sender, EventArgs e)
        //{

        //}

        //protected void DropDownListHorariosDisponibles_DataBound(object sender, EventArgs e)
        //{

        //}
    }
}