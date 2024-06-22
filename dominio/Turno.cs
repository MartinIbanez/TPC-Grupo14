using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Turno  //Falta tabla en BD
    {
        public int Id { get; set; }
        public DateTime FechaTurno { get; set; }
        public Horario HorarioTurno { get; set; }       // VER...NO SE SI VA ESTO...QUIZAS con DATETIME FechaTurno ya alcance
        public Persona PacienteTurno { get; set; }
        public Profesional ProfesionalTurno { get; set; }
        public Especialidad EspecialidadTurno { get; set; }
        public EstadoTurno Estado { get; set; }
        public string Observaciones { get; set; }


    }
}