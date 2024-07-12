using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;


namespace negocio
{
    public class PersonaNegocio
    {
        public List<Persona> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Persona> lista = new List<Persona>();
            try
            {
                datos.SetearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.Id = int.Parse((datos.Lector["ID"].ToString()));
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Apellido = (string)datos.Lector["Apellido"].ToString();
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.IdGenero = int.Parse(datos.Lector["IDGenero"].ToString());
                    aux.Gen = datos.Lector["Gen"].ToString();
                    aux.NumDoc = datos.Lector["NumDoc"].ToString();
                    aux.Correo = datos.Lector["Correo"].ToString();
                    aux.Telefono = datos.Lector["Telefono"].ToString();
                    aux.IdRol = int.Parse(datos.Lector["IDRol"].ToString());
                    aux.Role = datos.Lector["Rol"].ToString();
                    aux.Activo = (bool)datos.Lector["Activo"];
                    

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

        public List<Persona> ListarPacientes()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Persona> lista = new List<Persona>();
            try
            {
                datos.SetearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, P.NumDoc, P.Correo, P.Telefono, P.IDRol, P.Activo FROM Personas P where IDrol = 4");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.Id = int.Parse(datos.Lector["ID"].ToString());
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Apellido = datos.Lector["Apellido"].ToString();
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.IdGenero = int.Parse(datos.Lector["IDGenero"].ToString());
                    aux.NumDoc = datos.Lector["NumDoc"].ToString();
                    aux.Correo = datos.Lector["Correo"].ToString();
                    aux.Telefono = datos.Lector["Telefono"].ToString();
                    aux.IdRol = int.Parse(datos.Lector["IDRol"].ToString());
                    aux.Activo = (bool)datos.Lector["Activo"];

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


        public Persona ObtenerPacientePorId(int id)
        {
            // logica para obtener el paciente por ID
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, P.NumDoc, P.Correo, P.Telefono, P.IDRol, P.Activo FROM Personas P WHERE P.ID = @ID");
                datos.SetearParametro("@ID", id);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.Id = int.Parse(datos.Lector["ID"].ToString());
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Apellido = datos.Lector["Apellido"].ToString();
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.IdGenero = int.Parse(datos.Lector["IDGenero"].ToString());
                    aux.NumDoc = datos.Lector["NumDoc"].ToString();
                    aux.Correo = datos.Lector["Correo"].ToString();
                    aux.Telefono = datos.Lector["Telefono"].ToString();
                    aux.IdRol = int.Parse(datos.Lector["IDRol"].ToString());
                    aux.Activo = (bool)datos.Lector["Activo"];

                    return aux;
                }
                return null;
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


        public void AgregarPaciente(Persona nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo) VALUES (@Nombre, @Apellido, @FechaNac, @IDGenero, @NumDoc, @Correo, @Telefono, @IDRol, @Activo)");
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Apellido", nuevo.Apellido);
                datos.SetearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.SetearParametro("@IDGenero", nuevo.IdGenero);
                datos.SetearParametro("@NumDoc", nuevo.NumDoc);
                datos.SetearParametro("@Correo", nuevo.Correo);
                datos.SetearParametro("@Telefono", nuevo.Telefono);
                datos.SetearParametro("@IDRol", nuevo.IdRol);
                datos.SetearParametro("@Activo", nuevo.Activo);
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


        public void ModificarPaciente(Persona nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, FechaNac = @FechaNac, IDGenero = @IDGenero, NumDoc = @NumDoc, Correo = @Correo, Telefono = @Telefono, IDRol = @IDRol, Activo = @Activo WHERE ID = @ID");
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Apellido", nuevo.Apellido);
                datos.SetearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.SetearParametro("@IDGenero", nuevo.IdGenero);
                datos.SetearParametro("@NumDoc", nuevo.NumDoc);
                datos.SetearParametro("@Correo", nuevo.Correo);
                datos.SetearParametro("@Telefono", nuevo.Telefono);
                datos.SetearParametro("@IDRol", nuevo.IdRol);
                datos.SetearParametro("@Activo", nuevo.Activo);
                datos.SetearParametro("@ID", nuevo.Id);
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

        public void EliminarPaciente(int idPaciente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM Personas WHERE ID = @ID");
                datos.SetearParametro("@ID", idPaciente);
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



        public void Agregar(Persona nuevo)  //Revisar!!!!!!!!!!!!
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo, Password) " +
                                     "VALUES (@Nombre, @Apellido, @FechaNac, @IDGenero, @NumDoc, @Correo, @Telefono, @IDRol, @Activo, @Password)");
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Apellido", nuevo.Apellido);
                datos.SetearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.SetearParametro("@IDGenero", nuevo.IdGenero);
                datos.SetearParametro("@NumDoc", nuevo.NumDoc);
                datos.SetearParametro("@Correo", nuevo.Correo);
                datos.SetearParametro("@Telefono", nuevo.Telefono);
                datos.SetearParametro("@IDRol", nuevo.IdRol);
                datos.SetearParametro("@Activo", nuevo.Activo);
                datos.SetearParametro("@Password", nuevo.Password);

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


        public void Modificar(Persona modificar)    //Revisar!!!!!!!!!!!!
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, FechaNac = @FechaNac, IDGenero = @IDGenero, NumDoc = @NumDoc, Correo = @Correo, Telefono = @Telefono, IDRol = @IDRol, Activo = @Activo, Password = @Password WHERE ID = @ID");
                datos.SetearParametro("@Nombre", modificar.Nombre);
                datos.SetearParametro("@Apellido", modificar.Apellido);
                datos.SetearParametro("@FechaNac", modificar.FechaNacimiento);
                datos.SetearParametro("@IDGenero", modificar.IdGenero);
                datos.SetearParametro("@NumDoc", modificar.NumDoc);
                datos.SetearParametro("@Correo", modificar.Correo);
                datos.SetearParametro("@Telefono", modificar.Telefono);
                datos.SetearParametro("@IDRol", modificar.IdRol);
                datos.SetearParametro("@Activo", modificar.Activo);
                datos.SetearParametro("@Password", modificar.Password);
                datos.SetearParametro("@ID", modificar.Id);

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

        public void Eliminar(int id)        //Revisar!!!!!!!!!!!!
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM Personas WHERE ID = @ID");
                datos.SetearParametro("@ID", id);
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

        public Persona Buscar(int id)   //Revisar!!!!!!!!!!!!
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux = new Persona();
            try
            {
                datos.SetearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID WHERE P.ID = @ID");
                datos.SetearParametro("@ID", id);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.IdGenero = (int)datos.Lector["IDGenero"];
                    aux.Gen = (string)datos.Lector["Gen"];
                    aux.NumDoc = (string)datos.Lector["NumDoc"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.IdRol = (int)datos.Lector["IDRol"];
                    aux.Role = (string)datos.Lector["Rol"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Password = (string)datos.Lector["Password"];
                }
                return aux;
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

        public Persona Buscar(string email)     //Revisar!!!!!!!!!!!!
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux = new Persona();
            try
            {
                datos.SetearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID WHERE P.Correo = @Correo");
                datos.SetearParametro("@Correo", email);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.IdGenero = (int)datos.Lector["IDGenero"];
                    aux.Gen = (string)datos.Lector["Gen"];
                    aux.NumDoc = (string)datos.Lector["NumDoc"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.IdRol = (int)datos.Lector["IDRol"];
                    aux.Role = (string)datos.Lector["Rol"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Password = (string)datos.Lector["Password"];
                }
                return aux;
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

        public Persona Login(string email, string password)     //Revisar!!!!!!!!!!!!
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux = null;
            try
            {
                datos.SetearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID WHERE P.Correo = @Correo AND P.Password = @Password");
                datos.SetearParametro("@Correo", email);
                datos.SetearParametro("@Password", password);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = new Persona();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.IdGenero = (int)datos.Lector["IDGenero"];
                    aux.Gen = (string)datos.Lector["Gen"];
                    aux.NumDoc = (string)datos.Lector["NumDoc"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.IdRol = (int)datos.Lector["IDRol"];
                    aux.Role = (string)datos.Lector["Rol"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Password = (string)datos.Lector["Password"];
                }
                return aux;
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