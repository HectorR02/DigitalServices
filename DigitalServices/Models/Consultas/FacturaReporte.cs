using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalServices.Models.Consultas
{
    public class FacturaReporte
    {
        public FacturaC Encabezado { get; set; }

        public List<FacturaDetalles> Detalle { get; set; }

        public FacturaReporte()
        {
            Detalle = new List<FacturaDetalles>();
        }
    }
}