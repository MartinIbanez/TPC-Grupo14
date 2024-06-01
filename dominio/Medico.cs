using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace dominio
{
    /*Extiende de Usuario, incluye especialidades y turnos asignados*/

    public class Medico : Usuario
    {
        public string especialidad { get; set; }
        public List<Turno> turnos { get; set; }

        public List<HorarioTrabajo> horarios { get; set; }

       
    }
   
}