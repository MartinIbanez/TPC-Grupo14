using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Turno
    {


        public int id { get; set; }
        public DateTime fechaHora { get; set; }
        public Paciente paciente { get; set; }
        public Profesional medico { get; set; }
        public string especialidad { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }


    }
}