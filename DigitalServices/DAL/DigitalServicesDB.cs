using DigitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalServices.DAL
{
    public class DigitalServicesDB : DbContext
    {
        public DigitalServicesDB() : base("DigServices")
        {

        }

        public DbSet<Clientes> Cliente { get; set; }

        public DbSet<FacturaDetalles> FaturaDetalle { get; set; }

        public DbSet<Facturas> Factura { get; set; }

        public DbSet<Items> Items { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}