using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;

namespace negocio
{
    public class RolNegocio
    {

        public List<Rol> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Rol> lista = new List<Rol>();
            
            try
            {
                datos.SetearConsulta("select R.ID as Id, R.Nombre as Nombre from Roles R");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Rol aux = new Rol();
                    aux.Id =  int.Parse(datos.Lector["Id"].ToString());
                    aux.Nombre = datos.Lector["Nombre"].ToString();
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