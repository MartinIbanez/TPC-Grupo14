using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace negocio
{
    public class TurnoNegocio
    {
        //TO DO ...
        public List<Turno> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();
            try
            {   //Levanto Turno
                datos.SetearConsulta("select T.Id as Id,T.IdProfesional as IdProfesional,Per.Nombre as NombreProfesional,Per.Apellido as ApellidoProfesional,T.IdPaciente as IdPaciente,P.Nombre as NombrePaciente,P.Apellido as ApellidoPaciente,E.Nombre as EspecialidadTurno,T.Estado as Estado,T.FechaTurno as FechaTurno,T.HoraTurno as HoraTurno, T.Observaciones as Observaciones from Turnos T INNER JOIN Profesionales PRO ON PRO.ID=T.IdProfesional INNER JOIN Personas P ON P.ID=T.IdPaciente INNER JOIN Personas Per ON Per.ID=PRO.IdPersona INNER JOIN Especialidades E ON E.ID=T.IdEspecialidad");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    //INSTANCIAMOS CLASES INTERNAS en el constructor de Turno...
                    Turno aux = new Turno();
                    aux.Id = int.Parse((datos.Lector["Id"].ToString()));
                    aux.ProfesionalTurno.IdProfesional = int.Parse((datos.Lector["IdProfesional"].ToString()));
                    aux.ProfesionalTurno.Nombre = datos.Lector["NombreProfesional"].ToString();
                    aux.ProfesionalTurno.Apellido = datos.Lector["ApellidoProfesional"].ToString(); 
                    aux.PacienteTurno.Id = int.Parse(datos.Lector["IdPaciente"].ToString()); 
                    aux.PacienteTurno.Nombre = datos.Lector["NombrePaciente"].ToString(); 
                    aux.PacienteTurno.Apellido = datos.Lector["ApellidoPaciente"].ToString(); 
                    aux.EspecialidadTurno.Nombre = datos.Lector["EspecialidadTurno"].ToString();
                    aux.EstadoTurno = int.Parse(datos.Lector["Estado"].ToString()); 
                    aux.FechaTurno = DateTime.Parse(datos.Lector["FechaTurno"].ToString());
                    aux.HoraTurno= int.Parse(datos.Lector["HoraTurno"].ToString());
                    aux.Observaciones =datos.Lector["Observaciones"].ToString();

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

        public List<Turno> ListarTurnosAsignados(Profesional prof,DateTime fechaTurno)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();

            try
            {   //Levanto Turno
                datos.SetearConsulta("select T.Id as Id, T.IdProfesional as IdProfesional, Per.Nombre as NombreProfesional, Per.Apellido as ApellidoProfesional, T.IdPaciente as IdPaciente, P.Nombre as NombrePaciente, P.Apellido as ApellidoPaciente, E.Nombre as EspecialidadTurno, T.Estado as Estado, T.FechaTurno as FechaTurno, T.HoraTurno as HoraTurno,\r\nT.Observaciones as Observaciones from Turnos T INNER JOIN Profesionales PRO ON PRO.ID=T.IdProfesional INNER JOIN Personas P ON P.ID=T.IdPaciente INNER JOIN Personas Per ON Per.ID=PRO.IdPersona INNER JOIN Especialidades E ON E.ID=T.IdEspecialidad Where FechaTurno = @FechaTurno and Estado=0 and IdProfesional=@IdProfesional");
                datos.SetearParametro("@IdProfesional",prof.IdProfesional);
                datos.SetearParametro("@FechaTurno",fechaTurno.Date);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    //INSTANCIAMOS CLASES INTERNAS en el constructor de Turno...
                    Turno aux = new Turno();
                    aux.Id = int.Parse((datos.Lector["Id"].ToString()));
                    aux.ProfesionalTurno.IdProfesional = int.Parse((datos.Lector["IdProfesional"].ToString()));
                    aux.ProfesionalTurno.Nombre = datos.Lector["NombreProfesional"].ToString();
                    aux.ProfesionalTurno.Apellido = datos.Lector["ApellidoProfesional"].ToString();
                    aux.PacienteTurno.Id = int.Parse(datos.Lector["IdPaciente"].ToString());
                    aux.PacienteTurno.Nombre = datos.Lector["NombrePaciente"].ToString();
                    aux.PacienteTurno.Apellido = datos.Lector["ApellidoPaciente"].ToString();
                    aux.EspecialidadTurno.Nombre = datos.Lector["EspecialidadTurno"].ToString();
                    aux.EstadoTurno = int.Parse(datos.Lector["Estado"].ToString());
                    aux.FechaTurno = DateTime.Parse(datos.Lector["FechaTurno"].ToString());
                    aux.HoraTurno = int.Parse(datos.Lector["HoraTurno"].ToString());
                    aux.Observaciones = datos.Lector["Observaciones"].ToString();

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

        public void Agregar(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO Turnos(IdProfesional, IdPaciente, FechaTurno, HoraTurno, IdEspecialidad, Estado, Observaciones) VALUES(@IdProfesional,@IdPaciente,@FechaTurno,@HoraTurno,@IdEspecialidad,@Estado,@Observaciones)");
                datos.SetearParametro("@IdProfesional",nuevo.ProfesionalTurno.IdProfesional);
                datos.SetearParametro("@IdPaciente", nuevo.PacienteTurno.Id);
                datos.SetearParametro("@FechaTurno", nuevo.FechaTurno.Date);
                datos.SetearParametro("@HoraTurno", nuevo.HoraTurno);
                datos.SetearParametro("@IdEspecialidad", nuevo.EspecialidadTurno.Id);
                datos.SetearParametro("@Estado", nuevo.EstadoTurno);
                datos.SetearParametro("@Observaciones",nuevo.Observaciones);

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