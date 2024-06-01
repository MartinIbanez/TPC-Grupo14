using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Paciente
    {
     

        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public List<Turno> turnos { get; set; }

        

   

    }
}