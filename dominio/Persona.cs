using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace dominio
{
    public class Persona
    {
        //Representa a todos los tipos de usuarios del sistema: Administrador, Recepcionista y Médico.
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        //public string Gen { get; set; } //clase!!
        public string NumDoc { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int Rol { get; set; } //enum???      //(1  Admin) (2  Recepcionista) (3  Profesional) (4  Paciente)
        //public string Role { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }


        // constructor con parametros 
        public Persona(int id, string nombre, string apellido, DateTime fechaNacimiento, int genero, string numDoc, string correo, string telefono, int rol, bool activo, string password)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            //IdGenero = idGenero;
            Genero = genero;
            NumDoc = numDoc;
            Correo = correo;
            Telefono = telefono;
            Rol = rol;
            //Role = role;
            Activo = activo;
            Password = password;
        }

        // constructor  por defecto: 
        public Persona()
        {
            Id = 0;
            Nombre = "";
            Apellido = "";
            FechaNacimiento = DateTime.Now;
            Genero = 0;
            //Gen = "";
            NumDoc = "";
            Correo = "";
            Telefono = "";
            Rol = 0;
            //Role = "";
            Activo = false;
            Password = "";
        }
    }






}