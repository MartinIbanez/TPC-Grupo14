using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace negocio
{
    public class ProfesionalNegocio
    {
        public List<Profesional> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Profesional> lista = new List<Profesional>();

            EspecialidadNegocio en = new EspecialidadNegocio();
            List<Especialidad> listEspecialidades = en.Listar();  //cargo la lista de especialidades

            ProfesionalesXEspecialidadNegocio pxe = new ProfesionalesXEspecialidadNegocio();
            List<ProfesionalesXEspecialidad> listPxE = pxe.Listar();
            Especialidad espAux = new Especialidad();
            try
            {   //Levanto nombre y apellido profesional
                datos.SetearConsulta("select PR.ID as ID,P.Nombre as Nombre,P.Apellido as Apellido from Profesionales PR INNER JOIN Personas P ON P.ID=PR.IdPersona");
                datos.EjecutarLectura();    

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.IdProfesional = int.Parse((datos.Lector["ID"].ToString()));
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Apellido = (string)datos.Lector["Apellido"].ToString();
                    aux.Especialidades = new List<Especialidad>();  //Instancio la lista para poder cargarla
                    //---Datos que no muestro por ahora...---

                    //aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    //aux.IdGenero = int.Parse(datos.Lector["IDGenero"].ToString());
                    //aux.Gen = datos.Lector["Gen"].ToString();
                    //aux.NumDoc = datos.Lector["NumDoc"].ToString();
                    //aux.Correo = datos.Lector["Correo"].ToString();
                    //aux.Telefono = datos.Lector["Telefono"].ToString();
                    //aux.IdRol = int.Parse(datos.Lector["IDRol"].ToString());
                    //aux.Role = datos.Lector["Rol"].ToString();
                    //aux.Activo = (bool)datos.Lector["Activo"];
                    //aux.Password = datos.Lector["Password"].ToString();
                    

                    //Este bloque carga las especialidades de profesional en cuestion...
                    List<ProfesionalesXEspecialidad> listPxEFiltrados = listPxE.FindAll(x=>x.IdProfesional == aux.IdProfesional);
                    foreach(ProfesionalesXEspecialidad p in listPxEFiltrados)
                    {
                        espAux = listEspecialidades.Find(x => x.Id == p.IdEspecialidad);

                        if (espAux != null)
                        {
                            aux.Especialidades.Add(espAux);
                        }
                    }
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
    }
}