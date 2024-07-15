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
                    aux.ListHorariosDisponibles = new List<Horario>();
                    //---Datos que no muestro por ahora...---

                    // aux.ListHorariosDisponibles = new List<Horario>();   //Instancio la lista para poder cargarla
                    //aux.IdGenero = int.Parse(datos.Lector["IDGenero"].ToString());
                    //aux.Gen = datos.Lector["Gen"].ToString();
                    //aux.IdRol = int.Parse(datos.Lector["IDRol"].ToString());
                    //aux.Role = datos.Lector["Rol"].ToString();
                    //aux.Password = datos.Lector["Password"].ToString();


                    //Este bloque carga las especialidades de profesional en cuestion...
                    List<ProfesionalesXEspecialidad> listPxEFiltrados = listPxE.FindAll(x => x.IdProfesional == aux.IdProfesional);
                    foreach (ProfesionalesXEspecialidad p in listPxEFiltrados)
                    {
                        espAux = listEspecialidades.Find(x => x.Id == p.IdEspecialidad);

                        if (espAux != null)
                        {
                            aux.Especialidades.Add(espAux);
                        }
                    }
                    //Este bloque carga los horarios de profesional en cuestion
                    foreach (Horario h in listHorarios)
                    {
                        if (h.IdProfesional == aux.IdProfesional)
                        {
                            aux.ListHorariosDisponibles.Add(h);
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


        //REVISAR RESTO DE FUNCIONES ABM PROFESIONALES
        //REVISAR RESTO DE FUNCIONES ABM PROFESIONALES
        //REVISAR RESTO DE FUNCIONES ABM PROFESIONALES


        public Profesional ObtenerProfesinalPorID(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            EspecialidadNegocio en = new EspecialidadNegocio();
            List<Especialidad> listEspecialidades = en.Listar();  // cargar la lista de especialidades

            ProfesionalesXEspecialidadNegocio pxe = new ProfesionalesXEspecialidadNegocio();
            List<ProfesionalesXEspecialidad> listPxE = pxe.Listar();

            try
            {
                datos.SetearConsulta("SELECT PR.ID AS ID, P.Nombre, P.Apellido, P.FechaNac, P.NumDoc, P.Correo, P.Telefono, P.Activo FROM Profesionales PR INNER JOIN Personas P ON P.ID = PR.IdPersona WHERE PR.ID = @ID");
                datos.SetearParametro("@ID", id);
                datos.EjecutarLectura();

                Profesional profesional = new Profesional(); // instancio un profesional para cargar los datos
                if (datos.Lector.Read())
                {
                    profesional.IdProfesional = int.Parse((datos.Lector["ID"].ToString()));
                    profesional.Nombre = datos.Lector["Nombre"].ToString();
                    profesional.Apellido = (string)datos.Lector["Apellido"].ToString();
                    profesional.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    profesional.NumDoc = datos.Lector["NumDoc"].ToString();
                    profesional.Correo = datos.Lector["Correo"].ToString();
                    profesional.Telefono = datos.Lector["Telefono"].ToString();
                    profesional.Activo = (bool)datos.Lector["Activo"];
                    profesional.Especialidades = new List<Especialidad>();      // Instancio la lista para poder cargarla


                    // Cargar las especialidades del profesional
                    List<ProfesionalesXEspecialidad> listPxEFiltrados = listPxE.FindAll(x => x.IdProfesional == profesional.IdProfesional);
                    foreach (ProfesionalesXEspecialidad p in listPxEFiltrados)
                    {
                        // encuentro la especialidad en la lista de especialidades y si la encuentro la agrego a la lista de especialidades del profesional
                        Especialidad espAux = listEspecialidades.Find(x => x.Id == p.IdEspecialidad);
                        if (espAux != null)
                        {
                            // probable que haya medicos que uieran tener mas de una especialidad
                            profesional.Especialidades.Add(espAux);
                        }
                    }
                }
                return profesional;
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



        public void AgregarProfesional(Profesional nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Personas (Nombre, Apellido, FechaNac, Genero, NumDoc, Correo, Telefono, Rol, Activo) VALUES (@Nombre, @Apellido, @FechaNac, @Genero, @NumDoc, @Correo, @Telefono, @Rol, @Activo)");

                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Apellido", nuevo.Apellido);
                datos.SetearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.SetearParametro("@Genero", nuevo.Genero);
                datos.SetearParametro("@NumDoc", nuevo.NumDoc);
                datos.SetearParametro("@Correo", nuevo.Correo);
                datos.SetearParametro("@Telefono", nuevo.Telefono);
                datos.SetearParametro("@Rol", 3);
                datos.SetearParametro("@Activo", 1);
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


        // modificar profesional
        public void ModificarProfesional(Profesional nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, FechaNac = @FechaNac, Genero = @Genero, NumDoc = @NumDoc, Correo = @Correo, Telefono = @Telefono, Rol = @Rol, Activo = @Activo WHERE ID = @ID");

                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Apellido", nuevo.Apellido);
                datos.SetearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.SetearParametro("@Genero", nuevo.Genero);
                datos.SetearParametro("@NumDoc", nuevo.NumDoc);
                datos.SetearParametro("@Correo", nuevo.Correo);
                datos.SetearParametro("@Telefono", nuevo.Telefono);
                datos.SetearParametro("@Rol", 3);
                datos.SetearParametro("@Activo", nuevo.Activo);
                datos.SetearParametro("@ID", nuevo.IdProfesional);
                datos.EjecutarAccion();


            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();

            }


            

 


        }

        //eliminar  profesional
        public void EliminarProfesional(Profesional nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("DELETE FROM Personas WHERE ID = @ID");

                datos.SetearParametro("@ID", nuevo.IdProfesional);
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



    }
   
}