using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace dominio
{
    public class Usuario
    {
        //Representa a todos los tipos de usuarios del sistema: Administrador, Recepcionista y Médico.
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }  //  admin / Recepcionista / Medico

    }
}