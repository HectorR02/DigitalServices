using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }

        public int IdCliente { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadItems { get; set; }

        public double SubTotal { get; set; }

        public double ITBIS { get; set; }

        public double TOTAL { get; set; }

        public int IdEmpleado { get; set; }

        public Facturas()
        {

        }
    }
}