using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }

        public string Nombres { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public Clientes()
        {

        }
    }
}