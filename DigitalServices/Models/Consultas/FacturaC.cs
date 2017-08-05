using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models.Consultas
{
    public class FacturaC
    {
        [Key]
        public int IdFactura { get; set; }

        public string Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadItems { get; set; }

        public double SubTotal { get; set; }

        public double ITBIS { get; set; }

        public double TOTAL { get; set; }

        public int IdEmpleado { get; set; }

        public FacturaC()
        {

        }
    }
}