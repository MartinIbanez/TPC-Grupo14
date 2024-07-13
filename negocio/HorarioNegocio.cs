using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace negocio
{
    public class HorarioNegocio
    {
        public List<Horario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Horario> lista = new List<Horario>();

            try
            {
                datos.SetearConsulta("select H.Id as Id,H.IdProfesional as IdProfesional,H.DayOfWeek as Dia,H.HoraInicio as HoraInicio,H.HoraFin as HoraFin FROM Horarios H");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    //De cada Horario, es decir, de cada bloque horario, voy a cargar uno por cada hora.
                    //Ejemplo: horainicio = 9:00 ; horafin = 12:00  ==> se cargaran 3 horarios 9,10 y 11
                    //Este proceso lo hago en el for...

                    int Id = int.Parse(datos.Lector["Id"].ToString());
                    int IdProfesional = int.Parse(datos.Lector["IdProfesional"].ToString());
                    DayOfWeek Dia = (System.DayOfWeek)int.Parse(datos.Lector["Dia"].ToString());
                    int HoraInicio = int.Parse(datos.Lector["HoraInicio"].ToString());
                    int HoraFin = int.Parse(datos.Lector["HoraFin"].ToString());

                    for (int i = HoraInicio; i < HoraFin; i++)
                    {
                        Horario aux = new Horario();
                        aux.Id = Id;
                        aux.IdProfesional = IdProfesional;
                        aux.Dia = Dia;
                        aux.HoraInicio = i;
                        aux.HoraFin = i + 1;        //Aca defino que los turnos seran de 1 hora. Tocando este parametro achico o agrando la duracion de los turnos...
                        lista.Add(aux);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return lista;
        }
    }
}