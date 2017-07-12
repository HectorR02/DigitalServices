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

        public int IdItem { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }

        public double Monto { get; set; }

        public FacturaDetalles()
        {

        }
    }
}