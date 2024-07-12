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
                    Session.Add("listaEspecialidades", listaEspecialidades);     //agrego a la sesion asi no vuelvo a abrir la BD
                    Session.Add("listaProfesionales", listaProfesionales);       //agrego a la sesion asi no vuelvo a abrir la BD
                    

                    DropDownListEspecialidades.DataBind();
                    DropDownListEspecialidades.SelectedIndex = 0;               //1er elemento

                    DropDownListPacientes.DataSource = listaPacientes;
                    DropDownListPacientes.DataTextField = "Nombre";
                    DropDownListPacientes.DataValueField = "Id";
                    DropDownListPacientes.DataBind();
                    Session.Add("listaPacientes", listaPacientes);


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

            //foreach (Profesional p in (List<Profesional>)Session["listaProfesionales"])
            foreach (Profesional p in listaProfesionales)
            {
                if (p.Especialidades.Find(x => x.Id == idEspecialidad) != null)
                {
                    listaProfesionalesAMostrar.Add(p);  //CARGO LA LISTA DE PROFESIONALES QUE TIENEN LA ESPECIALIDAD SELECCIONADA
                }
            }
            //Revisar la posibilidad de vacias este elemento de la sesion y volverlo a cargar...por las dudas...
            //Session.Add("listaProfesionalesAMostrar", listaProfesionalesAMostrar);

            DropDownListProfesionales.DataSource = listaProfesionalesAMostrar;
            DropDownListProfesionales.DataTextField = "Nombre";
            DropDownListProfesionales.DataValueField = "IdProfesional";
            //DropDownListProfesionales.DataBind();

            //DropDownListProfesionales_SelectedIndexChanged(sender, e);          //Fuerzo el evento
            DropDownListProfesionales.SelectedIndex = 0;        //Muestro el 1er profesional disponible?
            DropDownListProfesionales.DataBind();


            DropDownListHorariosDisponibles.DataSource = listaProfesionalesAMostrar[0].ListHorariosDisponibles; //muestro el horario del 1er profesional?
            DropDownListHorariosDisponibles.DataValueField = "Id";
            DropDownListHorariosDisponibles.DataTextField = "HoraInicio";
            DropDownListHorariosDisponibles.DataBind();
            //DropDownListHorariosDisponibles.SelectedIndex = 0;
            
            CardEspecialidad.Text=DropDownListEspecialidades.SelectedItem.ToString();

        }

        protected void DropDownListProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
            List<Profesional> listaProf = new List<Profesional>();
            listaProf = (List<Profesional>)DropDownListProfesionales.DataSource;

            Profesional prof = new Profesional();
            //prof = ((List<Profesional>)Session["listaProfesionalesAMostrar"]).Find(x=>x.IdProfesional==idProf);
            prof = listaProf.Find(x => x.IdProfesional == idProf);

            //List<string> DiasDisponibles = new List<String>();      //aca defino la lista de DIAS
            List<Horario> DiasDisponibles = new List<Horario>();
            foreach (Horario h in prof.ListHorariosDisponibles)
            {
                DiasDisponibles.Add(h);                                 //CARGO LA LISTA DE DIAS DISPONIBLES EN BASE AL PROFESIONAL SELECCIONADO
            }

            DropDownListDia.DataSource = DiasDisponibles;
            DropDownListDia.DataBind();

            //Session.Add("listaDiasDisponibles",DiasDisponibles);

            CardProfesional.Text = prof.Apellido;

            //DropDownListDia_SelectedIndexChanged(sender, e);

            //LLAMO A ACTUALIZAR EL CALENDARIO??
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

            DropDownListHorariosDisponibles.DataSource = h;
            DropDownListHorariosDisponibles.DataValueField = "Id";
            DropDownListHorariosDisponibles.DataTextField = "HoraInicio";
            DropDownListHorariosDisponibles.DataBind();

            Session.Add("listaHorasDisponibles", h);

            DropDownListHorariosDisponibles_SelectedIndexChanged(sender, e);             //comentada por estar en visible=false
        }

        //
        //  VER ESTE EVENTO HORA NO PINTA LOS DIAS!
        //
        protected void DropDownListHorariosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidad_selected=DropDownListEspecialidades.SelectedItem.ToString();
            string profesional_selected=DropDownListProfesionales.SelectedItem.ToString();
            string dia_selected = CalendarioTurnos.SelectedDate.Day.ToString();
            //string dia_selected = DropDownListDia.SelectedItem.ToString();
            string hora_selected=(int.Parse((DropDownListHorariosDisponibles.SelectedItem).ToString())).ToString("D2") + ":00";
            
            LabelInfoTurno.Text =
                "INFO:" +
                " Especialidad: " + especialidad_selected +
                " Profesional: " + profesional_selected +
                " Dia: " + dia_selected +
                " Hora: " + hora_selected;
        }

        protected void DropDownListPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardPaciente.Text=DropDownListPacientes.SelectedItem.ToString();    //actualizo la ficha turno
        }

        protected void CalendarioTurnos_DayRender(object sender, DayRenderEventArgs ev)
        { 
            List<Horario> DiasDisponibles = new List<Horario>();
            //List<string> DiasOcupados = new List<string>();

            DiasDisponibles = (List<Horario>)DropDownListDia.DataSource;

            List<DayOfWeek> DaysDisponibles = new List<DayOfWeek>();
            //foreach(Horario h in DiasDisponibles)
            //{
            //    DaysDisponibles.Add(h.Dia);
            //}

            //DiasDisponibles = (List<string>)Session["listaDiasDisponibles"];        //Recupero los dias disponibles
                                                                                    //para volver a pintarlos
            if (DiasDisponibles == null)
            {
                //no hago nada porque aun no cargue opciones
            }
            else
            {
                foreach (Horario h in DiasDisponibles)
                {
                    DaysDisponibles.Add(h.Dia);
                }
            }
            if (DaysDisponibles.Contains(ev.Day.Date.DayOfWeek))
            {
                ev.Cell.BackColor = System.Drawing.Color.LightGreen;
                ev.Cell.ToolTip = "Dia Busyyyyyy";
            }
        }

        
        protected void CalendarioTurnos_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = CalendarioTurnos.SelectedDate;
            //string DiaSeleccionado = DropDownListDia.SelectedValue;
            DayOfWeek DiaSeleccionado = CalendarioTurnos.SelectedDate.DayOfWeek;
            //List<string> dd = (List<string>)Session["listaDiasDisponibles"];

            Profesional prof = new Profesional();
            Horario h = new Horario();
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);

            prof = ((List<Profesional>)DropDownListProfesionales.DataSource).Find(x => x.IdProfesional == idProf);  //busco profesional selected!

            
            h = prof.ListHorariosDisponibles.Find(x => x.Dia == DiaSeleccionado);


            if (DiaSeleccionado == h.Dia)
            {
                LabelTurnoSeleccionado.Text = fechaSeleccionada.Date.ToString("dd/MM/yyyy");    //Pido la fecha en este formato
                LabelInfoTurno.Text = "Usted a seleccionado : " + LabelTurnoSeleccionado.Text;
            }
            else
            {
                LabelTurnoSeleccionado.Text = "No aplica...";
                LabelInfoTurno.Text = "DIA NO DISPONIBLEEEE!!!";
            }

            DropDownListHorariosDisponibles.DataSource = null;
            DropDownListHorariosDisponibles.DataSource = prof.ListHorariosDisponibles;
            DropDownListHorariosDisponibles.DataBind();

            //Instancio un turno....
            Turno turnoAsignado = new Turno();
            turnoAsignado.Id = 0;
            turnoAsignado.FechaTurno = fechaSeleccionada;
            turnoAsignado.PacienteTurno = new Persona();
            turnoAsignado.PacienteTurno.Apellido = DropDownListPacientes.SelectedItem.ToString();
            turnoAsignado.ProfesionalTurno = new Profesional();
            turnoAsignado.ProfesionalTurno.Apellido = DropDownListProfesionales.SelectedItem.ToString();
            turnoAsignado.EspecialidadTurno = new Especialidad();
            turnoAsignado.EspecialidadTurno.Nombre = DropDownListEspecialidades.SelectedItem.ToString();
            turnoAsignado.EstadoTurno = 0;  //ABIERTO
            turnoAsignado.Observaciones = "Sin observaciones....";

            //turnoAsignado.PacienteTurno.Apellido = "Pepito ejemplo";
            //turnoAsignado.ProfesionalTurno.Apellido = "Bovazzi";
            //to do...resto de info del turno...

            CardIdTurno.Text = turnoAsignado.Id.ToString();
            CardFechaTurno.Text = turnoAsignado.FechaTurno.ToString();
            CardPaciente.Text = turnoAsignado.PacienteTurno.Apellido;
            CardProfesional.Text = turnoAsignado.ProfesionalTurno.Apellido;
            CardEspecialidad.Text = turnoAsignado.EspecialidadTurno.Nombre;
        }

        protected void btnCrearTurno_Click(object sender, EventArgs e)
        {
            LabelTurnoCreado.Visible = true;
            TimerTurnoCreado.Enabled = true;    //Disparo el timer para mostrar confirmacion de turno!
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            Turno nuevo = new Turno();

            nuevo.FechaTurno = CalendarioTurnos.SelectedDate;
            nuevo.HoraTurno = int.Parse(DropDownListHorariosDisponibles.SelectedValue);

            int idPaciente = int.Parse(DropDownListPacientes.SelectedValue);                                                        //id paciente seleccionado
            nuevo.PacienteTurno = ((List<Persona>)Session["listaPacientes"]).Find(x=>x.Id == idPaciente);                           //busco por id paciente

            int idProfesional = int.Parse(DropDownListProfesionales.SelectedValue);                                                 //id profesional seleccionado
            nuevo.ProfesionalTurno = ((List<Profesional>)Session["listaProfesionales"]).Find(x=>x.IdProfesional == idProfesional);

            int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedValue);
            nuevo.EspecialidadTurno = ((List<Especialidad>)Session["listaEspecialidades"]).Find(x => x.Id == idEspecialidad);

            nuevo.EstadoTurno = 0;      //ABIERTO

            nuevo.Observaciones = "";

            turnoNegocio.Agregar(nuevo);
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