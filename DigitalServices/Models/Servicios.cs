using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class Servicios
    {
        [Key]
        public int IdServicio { get; set; }

        public string Dimenciones { get; set; }

        public int Duracion { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public Servicios()
        {

        }
    }
}