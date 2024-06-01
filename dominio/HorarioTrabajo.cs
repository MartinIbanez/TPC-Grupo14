using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class HorarioTrabajo
    {
        public int id { get; set; }
        public string diaSemana { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public string medico { get; set; }
   
    }
}