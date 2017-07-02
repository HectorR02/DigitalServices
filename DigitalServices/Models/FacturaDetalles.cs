using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class FacturaDetalles
    {
        [Key]
        public int Id { get; set; }

        public int IdFactura { get; set; }

        public int IdServicio { get; set; }

        public int Cantidad { get; set; }

        public double Monto { get; set; }

        public FacturaDetalles()
        {

        }
    }
}