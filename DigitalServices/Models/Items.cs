using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Existencia { get; set; }

        public int Duracion { get; set; }

        public int EsArticulo { get; set; }

        public Items()
        {

        }
    }
}