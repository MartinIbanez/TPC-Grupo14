using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Especialidad
    {
     
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Medico> medicos { get; set; }
    }
}