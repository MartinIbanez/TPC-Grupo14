using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Especialidad espAux = new Especialidad();

            ProfesionalesXEspecialidadNegocio pxe = new ProfesionalesXEspecialidadNegocio();
            List<ProfesionalesXEspecialidad> listPxE = pxe.Listar();

            HorarioNegocio hn = new HorarioNegocio();
            List<Horario> listHorarios = hn.Listar();

            try
            {   //Levanto nombre y apellido profesional
                datos.SetearConsulta("SELECT PR.ID AS ID, P.Nombre, P.Apellido, P.FechaNac, P.NumDoc, P.Correo, P.Telefono, P.Activo FROM Profesionales PR INNER JOIN Personas P ON P.ID = PR.IdPersona");
                datos.EjecutarLectura();    

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.IdProfesional = int.Parse((datos.Lector["ID"].ToString()));
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Apellido = (string)datos.Lector["Apellido"].ToString();
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.NumDoc = datos.Lector["NumDoc"].ToString();
                    aux.Correo = datos.Lector["Correo"].ToString();
                    aux.Telefono = datos.Lector["Telefono"].ToString();
                    aux.Activo = (bool)datos.Lector["Activo"];


                    aux.Especialidades = new List<Especialidad>();      //Instancio la lista para poder cargarla
                    //---Datos que no muestro por ahora...---

                   // aux.ListHorariosDisponibles = new List<Horario>();   //Instancio la lista para poder cargarla
                    //aux.IdGenero = int.Parse(datos.Lector["IDGenero"].ToString());
                    //aux.Gen = datos.Lector["Gen"].ToString();
                    //aux.IdRol = int.Parse(datos.Lector["IDRol"].ToString());
                    //aux.Role = datos.Lector["Rol"].ToString();
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
                    //Este bloque carga los horarios de profesional en cuestion
                  /*  foreach(Horario h in listHorarios)
                    {
                        if(h.IdProfesional == aux.IdProfesional)
                        {
                            aux.ListHorariosDisponibles.Add(h);
                        }
                    }*/

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