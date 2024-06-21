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
        public int IdGenero { get; set; }
        public string Gen { get; set; } //clase!!
        public string NumDoc { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; } //enum???      //(1  Admin) (2  Recepcionista) (3  Profesional) (4  Paciente)
        public string Role { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }


        // constructor con parametros 
        public Persona(int id, string nombre, string apellido, DateTime fechaNacimiento, int idGenero, string gen, string numDoc, string correo, string telefono, int idRol, string role, bool activo, string password)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            IdGenero = idGenero;
            Gen = gen;
            NumDoc = numDoc;
            Correo = correo;
            Telefono = telefono;
            IdRol = idRol;
            Role = role;
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
            IdGenero = 0;
            Gen = "";
            NumDoc = "";
            Correo = "";
            Telefono = "";
            IdRol = 0;
            Role = "";
            Activo = false;
            Password = "";
        }
    }






}