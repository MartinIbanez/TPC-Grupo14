using System;
using System.Collections.Generic;
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
    }
}