using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Turno  //Homogeneizar tablas en BDs....
    {
        public int Id { get; set; }
        public DateTime FechaTurno { get; set; }
        
        public int HoraTurno { get; set; }
        public Persona PacienteTurno { get; set; }
        public Profesional ProfesionalTurno { get; set; }
        public Especialidad EspecialidadTurno { get; set; }
        public int EstadoTurno { get; set; }
        //public EstadoTurno Estado { get; set; }

        //-- ('ABIERTO')        0
        //-- ('CERRADO')        1
        //-- ('CANCELADO')      2
        //-- ('AUSENTE')        3


        public string Observaciones { get; set; }

        public Turno()
        {
            PacienteTurno = new Persona();
            ProfesionalTurno = new Profesional();
            EspecialidadTurno = new Especialidad();
        }

    }
}