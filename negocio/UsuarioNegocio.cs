using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.SetearConsulta("SELECT Id, Usuario, Pass,TipoUser, Email FROM Usuarios");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.User = (String)datos.Lector["Usuario"];
                    aux.Pass = (String)datos.Lector["Pass"];
                    aux.TipoUsuario = (TipoUsuario)datos.Lector["TipoUser"];
                    aux.Email = datos.Lector["Email"] != DBNull.Value ? (String)datos.Lector["Email"] : "Sin Correo";


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

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT Id, Usuario, Pass, TipoUser FROM Usuarios WHERE Usuario = @User AND Pass = @Pass");
                datos.SetearParametro("@User", usuario.User);
                datos.SetearParametro("@Pass", usuario.Pass);

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    if ((int)(datos.Lector["TipoUser"]) == 1)
                    {
                        usuario.TipoUsuario = TipoUsuario.Admin;
                    }
                    else if ((int)(datos.Lector["TipoUser"]) == 2)
                    {
                        usuario.TipoUsuario = TipoUsuario.Recepcionista;
                    }
                    else if ((int)(datos.Lector["TipoUser"]) == 3)
                    {
                        usuario.TipoUsuario = TipoUsuario.Profesional;
                    }
                    else if ((int)(datos.Lector["TipoUser"]) == 4)
                    {
                        usuario.TipoUsuario = TipoUsuario.Paciente;
                    }
                    else
                    {
                        usuario.TipoUsuario = TipoUsuario.Default;
                    }

                    return true;
                }
                return false;
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

        

