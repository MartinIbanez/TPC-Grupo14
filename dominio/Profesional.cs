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
        public List<Horario> ListHorariosDispoibles { get; set; }
        //VER HORARIOS...
    }
   
}