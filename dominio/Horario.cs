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
        public int IdProfesional { get; set; }

        public DayOfWeek Dia { get; set; }      //es un enum para los 7 dias de la semana, es compatible con Datetime
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
            
        public List<string> ObtenerHoras()
        {
            List<int> horas=new List<int>();
            for (int i = this.HoraInicio; i < this.HoraFin; i++) 
            {
                horas.Add(i);
            }
            
            List<string> listHorasString = new List<string>();

            foreach (int h in horas)
            {
                listHorasString.Add(h.ToString("D2") + ":00");  //paso el int hora a formato hora
            }
            return listHorasString;
        }

    }
}