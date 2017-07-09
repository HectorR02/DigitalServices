using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nombres { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public int Tipo { get; set; }

        public Usuarios()
        {

        }
    }
}