using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace negocio
{
    public class PersonasNegocio
    {
        public List<Persona> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Persona> lista = new List<Persona>();

            try
            {
                datos.setearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
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
                datos.cerrarConexion();
            }
        }

        public void Agregar(Persona nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo, Password) " +
                                     "VALUES (@Nombre, @Apellido, @FechaNac, @IDGenero, @NumDoc, @Correo, @Telefono, @IDRol, @Activo, @Password)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@IDGenero", nuevo.IdGenero);
                datos.setearParametro("@NumDoc", nuevo.NumDoc);
                datos.setearParametro("@Correo", nuevo.Correo);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@IDRol", nuevo.IdRol);
                datos.setearParametro("@Activo", nuevo.Activo);
                datos.setearParametro("@Password", nuevo.Password);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Persona modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, FechaNac = @FechaNac, IDGenero = @IDGenero, NumDoc = @NumDoc, Correo = @Correo, Telefono = @Telefono, IDRol = @IDRol, Activo = @Activo, Password = @Password WHERE ID = @ID");
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Apellido", modificar.Apellido);
                datos.setearParametro("@FechaNac", modificar.FechaNacimiento);
                datos.setearParametro("@IDGenero", modificar.IdGenero);
                datos.setearParametro("@NumDoc", modificar.NumDoc);
                datos.setearParametro("@Correo", modificar.Correo);
                datos.setearParametro("@Telefono", modificar.Telefono);
                datos.setearParametro("@IDRol", modificar.IdRol);
                datos.setearParametro("@Activo", modificar.Activo);
                datos.setearParametro("@Password", modificar.Password);
                datos.setearParametro("@ID", modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Personas WHERE ID = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Persona Buscar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux = new Persona();
            try
            {
                datos.setearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID WHERE P.ID = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

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
                datos.cerrarConexion();
            }
        }

        public Persona Buscar(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux = new Persona();
            try
            {
                datos.setearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID WHERE P.Correo = @Correo");
                datos.setearParametro("@Correo", email);
                datos.ejecutarLectura();

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
                datos.cerrarConexion();
            }
        }

        public Persona Login(string email, string password)
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux = null;
            try
            {
                datos.setearConsulta("SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.IDGenero, G.Nombre as Gen, P.NumDoc, P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol, P.Activo, P.Password FROM Personas P INNER JOIN Generos G ON P.IDGenero = G.ID INNER JOIN Roles R ON P.IDRol = R.ID WHERE P.Correo = @Correo AND P.Password = @Password");
                datos.setearParametro("@Correo", email);
                datos.setearParametro("@Password", password);
                datos.ejecutarLectura();

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
                datos.cerrarConexion();
            }
        }
    }
}