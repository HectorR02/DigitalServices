using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalServices.Models
{
    public class EncabezadoDetalle
    {
        public Facturas Encabezado { get; set; }

        public List<FacturaDetalles> Detalle { get; set; }

        public EncabezadoDetalle()
        {
            Detalle = new List<FacturaDetalles>();
        }
    }
}