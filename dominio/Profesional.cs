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

        
    }

}