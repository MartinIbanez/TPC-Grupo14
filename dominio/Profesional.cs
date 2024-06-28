using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace dominio
{
    /*Extiende de Usuario, incluye especialidades y turnos asignados*/
    //ESTO NO Va. USUARIO NO TIENE TURNOS...EL TURNO TIENE USUARIOS(paciente y profesional entre otras cosas)

    public class Profesional : Persona
    {
        public int IdProfesional { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        //VER TURNOS...NO! el turno va a tener profesional y paciente, no al reves...
        public List<Horario> ListHorariosDisponibles { get; set; }

        //public List<string> MostrarHorarios()
        //{
        //    List<int> listHorasInt = new List<int>();
        //    List<string> listHorasString = new List<string>();
        //    foreach (Horario h in ListHorariosDisponibles)
        //    {

        //        listHorasInt.AddRange(h.ObtenerHoras());        //agrego cada lista de horarios transformada en int
        //    }

        //    foreach (int h in listHorasInt)
        //    {
        //        listHorasString.Add(h.ToString("D2") + ":00");  //paso el int hora a formato hora
        //    }
        //    return listHorasString;
        //}
    }

}