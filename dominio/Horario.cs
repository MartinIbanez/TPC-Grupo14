using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Horario    //Los horarios de trabajo se van a cargar por dia. Puede haber mas de un horario por dia
    {
        //to do: al momento de dar de alta un horario, hay que mostrar
        //como horarios disponibles los que hayan quedado remanentes....es una validacion
        public int Id { get; set; }

        public DayOfWeek Dia { get; set; }      //es un enum para los 7 dias de la semana, es compatible con Datetime
        public int HoraEntrada { get; set; }
        public int HoraSalida { get; set; }
    }
}