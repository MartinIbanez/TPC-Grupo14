using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace dominio
{
    /*Extiende de Usuario, incluye especialidades y turnos asignados*/

    public class Profesional : Persona
    {
        public int IdProfesional { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        //VER TURNOS...
        public List<Turno> turnos { get; set; }
        //VER HORARIOS...
        public List<HorarioTrabajo> horarios { get; set; }

       
    }
   
}