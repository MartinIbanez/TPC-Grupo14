using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace negocio
{
    public class ProfesionalesXEspecialidadNegocio
    {
        public List<ProfesionalesXEspecialidad> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<ProfesionalesXEspecialidad> lista = new List<ProfesionalesXEspecialidad>();
            try
            {
                datos.SetearConsulta("select PXE.IDProfesional as IdProfesional,PXE.IDEspecialidad as IdEspecialidad from Profesionales_x_Especialidad PXE");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    ProfesionalesXEspecialidad aux = new ProfesionalesXEspecialidad();
                    aux.IdProfesional = int.Parse(datos.Lector["IdProfesional"].ToString());
                    aux.IdEspecialidad = int.Parse(datos.Lector["IdEspecialidad"].ToString());
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