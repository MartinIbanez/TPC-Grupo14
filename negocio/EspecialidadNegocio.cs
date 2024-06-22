using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;


namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Especialidad> lista = new List<Especialidad>();
            try
            {
                datos.SetearConsulta("select E.ID,E.Nombre  from Especialidades E");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = int.Parse(datos.Lector["ID"].ToString());
                    aux.Nombre = datos.Lector["Nombre"].ToString();

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void agregarEspecialidad(String nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into Especialidades VALUES ('" + nueva + "')");
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void eliminarEspecialidad(int idesp)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("DELETE FROM Especialidades where id= @Id");
                datos.SetearParametro("@Id", idesp);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void modificarEspecialidad(Especialidad editada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Especialidades SET Nombre = @Nombre WHERE Id = @Id");
                datos.SetearParametro("@Id", editada.Id);
                datos.SetearParametro("@Nombre", editada.Nombre);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.CerrarConexion(); }


        }

    }
}