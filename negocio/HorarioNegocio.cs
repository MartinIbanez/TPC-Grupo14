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
                    Horario aux = new Horario();
                    aux.Id = int.Parse(datos.Lector["Id"].ToString());
                    aux.IdProfesional = int.Parse(datos.Lector["IdProfesional"].ToString());
                    aux.Dia = (System.DayOfWeek)int.Parse(datos.Lector["Dia"].ToString());
                    aux.HoraInicio = int.Parse(datos.Lector["HoraInicio"].ToString());
                    aux.HoraFin = int.Parse(datos.Lector["HoraFin"].ToString());

                    lista.Add(aux);
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