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

                    GridPruebaTurnos.DataSource = listaTurnos;
                    GridPruebaTurnos.DataBind();

                    DropDownListEspecialidades.DataSource = listaEspecialidades;
                    DropDownListEspecialidades.DataTextField = "Nombre";
                    DropDownListEspecialidades.DataValueField = "Id";
                    DropDownListEspecialidades.DataBind();
                    DropDownListEspecialidades.SelectedIndex = 0;               //1er elemento             

                    DropDownListPacientes.DataSource = listaPacientes;
                    DropDownListPacientes.DataTextField = "Nombre";
                    DropDownListPacientes.DataValueField = "Id";
                    //1er elemento, es decir , primera especialidad de la lista de especialidades
                    DropDownListPacientes.SelectedIndex = 0;
                    DropDownListPacientes.DataBind();

                    //Cargo por 1era vez la lista de profesionales de la primera especialidad...
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

                    DropDownListProfesionales.DataSource = listaProfesionalesAMostrar;
                    DropDownListProfesionales.DataTextField = "Nombre";
                    DropDownListProfesionales.DataValueField = "IdProfesional";
                    DropDownListProfesionales.DataBind();
                    //Muestro el 1er profesional disponible
                    DropDownListProfesionales.SelectedIndex = 0;        

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


            DropDownListProfesionales.DataSource = listaProfesionalesAMostrar;
            DropDownListProfesionales.DataTextField = "Nombre";
            DropDownListProfesionales.DataValueField = "IdProfesional";
            DropDownListProfesionales.DataBind();

            DropDownListProfesionales.SelectedIndex = 0;        //Muestro el 1er profesional disponible
            //CalendarioTurnos.Visible = true;                    //Con esto lo habilito y se dispara el evento DayRender


            CardEspecialidad.Text = "Especialidad: " + DropDownListEspecialidades.SelectedItem.ToString();
            CardProfesional.Text = "Profesional: "  + DropDownListProfesionales.SelectedItem.ToString();
            CardFechaTurno.Text = "Fecha Turno: ";      //Pongo vacio en fecha y hora turno
            CardPaciente.Text ="Paciente: " + DropDownListPacientes.SelectedItem.ToString();

            dgvHorariosDisponibles.Visible = false;
        }

        protected void DropDownListProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfesionalNegocio profNegocio = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNegocio.Listar();

            PersonaNegocio personaNegocio = new PersonaNegocio();
            List<Persona> listaPacientes = personaNegocio.ListarPacientes();

            //Levanto el profesional selected...
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);

            Profesional prof = new Profesional();

            prof = listaProfesionales.Find(x => x.IdProfesional == idProf);

            CardProfesional.Text = "Profesional: " + prof.Nombre;
            CardFechaTurno.Text = "Fecha Turno: ";      //Pongo vacio en fecha y hora turno

            dgvHorariosDisponibles.Visible = false;
            
        }
        protected void DropDownListPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardPaciente.Text = "Paciente: " + DropDownListPacientes.SelectedItem.ToString();    //actualizo la ficha turno
            //Aca tengo que habilitar el calendario
        }


        protected void CalendarioTurnos_DayRender(object sender, DayRenderEventArgs ev)
        {
            //Selecciono el dia de hoy...
            DateTime today = DateTime.Now;
            DateTime diaRender = ev.Day.Date;
            CalendarioTurnos.SelectedDate = today;

            //Levanto el profesional selected...
            Profesional profSelected = new Profesional();
            ProfesionalNegocio profNeg = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNeg.Listar();
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
            profSelected = listaProfesionales.Find(x => x.IdProfesional == idProf);

            //Me quedo con los dias filtrados
            List<DayOfWeek> listaDiasFiltrada = profSelected.ListHorariosDisponibles.Select(x => x.Dia).Distinct().ToList();

            if ((diaRender >= today))
            {

                //Levanto el profesional selected...
                if (DropDownListProfesionales.SelectedValue != "")
                {

                    //FALTA PINTAR DE ROJO LOS DIAS TOTALMENTE OCUPADOS
                    foreach (DayOfWeek d in listaDiasFiltrada)
                    {
                        if (diaRender.DayOfWeek == d)        //Si el dia a renderizar esta en los disponibles, pintar
                        {
                            ev.Cell.BackColor = System.Drawing.Color.LightGreen;
                            ev.Cell.ToolTip = "Dia Disponibleeeeee";
                        }
                    }
                }
            }
        }


        protected void CalendarioTurnos_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = CalendarioTurnos.SelectedDate;

            DateTime today = DateTime.Now;

            //Levanto el profesional selected...
            Profesional profSelected = new Profesional();
            ProfesionalNegocio profNeg = new ProfesionalNegocio();
            List<Profesional> listaProfesionales = new List<Profesional>();
            listaProfesionales = profNeg.Listar();
            int idProf = int.Parse(DropDownListProfesionales.SelectedValue);
            profSelected = listaProfesionales.Find(x => x.IdProfesional == idProf);

            //Me quedo con los dias filtrados
            List<DayOfWeek> listaDiasFiltrada = profSelected.ListHorariosDisponibles.Select(x => x.Dia).Distinct().ToList();


            //Pregunto si selecciono algo valido...
            if (fechaSeleccionada >= DateTime.Now && listaDiasFiltrada.Contains(fechaSeleccionada.DayOfWeek))
            {
                DayOfWeek DiaSeleccionado = CalendarioTurnos.SelectedDate.DayOfWeek;

                List<Horario> horariosAMostrar = new List<Horario>();
                
                //btnVerHorariosDisponibles.Enabled = true;

                foreach (Horario h in profSelected.ListHorariosDisponibles)
                {
                    if (h.Dia == DiaSeleccionado)
                    {
                        horariosAMostrar.Add(h);
                    }
                }

                CardFechaTurno.Text = "Fecha Turno: " + fechaSeleccionada.Date.ToString("dd/MM/yyyy");
                CardEspecialidad.Text = "Especialidad: " + DropDownListEspecialidades.SelectedItem.ToString();
                CardProfesional.Text = "Profesional: " + DropDownListProfesionales.SelectedItem.ToString();
                CardPaciente.Text = "Paciente: " + DropDownListPacientes.SelectedItem.ToString();    //actualizo la ficha turno

                dgvHorariosDisponibles.DataSource = horariosAMostrar;
                dgvHorariosDisponibles.DataBind();
                dgvHorariosDisponibles.Visible = true;
            }
            else
            {
                CardFechaTurno.Text = "Fecha Turno: Dia no disponible";
            }
        }

        protected void dgvHorariosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string horaSeleccionada = int.Parse(dgvHorariosDisponibles.SelectedRow.Cells[1].Text).ToString("D2") + ":00";

            CardFechaTurno.Text = CalendarioTurnos.SelectedDate.ToString("dd/MM/yyyy") + "  ,  " + horaSeleccionada;
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

            nuevo.FechaTurno = CalendarioTurnos.SelectedDate.Date;

            //id paciente seleccionado
            int idPaciente = int.Parse(DropDownListPacientes.SelectedValue);                    
            nuevo.PacienteTurno = listaPacientes.Find(x => x.Id == idPaciente);

            //id profesional seleccionado
            int idProfesional = int.Parse(DropDownListProfesionales.SelectedValue);             
            nuevo.ProfesionalTurno = listaProfesionales.Find(x => x.IdProfesional == idProfesional);

            //id Especialidad seleccionada
            int idEspecialidad = int.Parse(DropDownListEspecialidades.SelectedValue);
            nuevo.EspecialidadTurno = listaEspecialidades.Find(x => x.Id == idEspecialidad);

            int horaTurno = int.Parse(dgvHorariosDisponibles.SelectedRow.Cells[1].Text);
            nuevo.HoraTurno = horaTurno;

            nuevo.EstadoTurno = 0;      //ABIERTO

            nuevo.Observaciones = "";

            turnoNegocio.Agregar(nuevo);

            //SACAR LA DISPONIBILIDAD ELEGIDA!!!
        }

        protected void TimerTurnoCreado_Tick(object sender, EventArgs e)
        {
            LabelTurnoCreado.Visible = false;
            TimerTurnoCreado.Enabled = false;
        }
    }
}