using DigitalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalServices.DAL;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DigitalServices.BLL
{
    public class FacturasBLL
    {
        public static bool Guardar(EncabezadoDetalle factura)
        {
            bool resultado = false;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Factura.Add(factura.Encabezado);
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = BLL.FacturaDetalleBLL.Guardar(factura.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static EncabezadoDetalle Buscar(int? facturaId)
        {
            EncabezadoDetalle factura = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    factura = new EncabezadoDetalle()
                    {
                        Encabezado = conexion.Factura.Find(facturaId)
                    };
                    if (factura.Encabezado != null)
                    {
                        factura.Detalle =
                        BLL.FacturaDetalleBLL.Listar(factura.Encabezado.IdFactura);
                    }else
                    {
                        factura = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }
        public static bool Modificar(EncabezadoDetalle factura)
        {
            bool resultado = false;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(factura.Encabezado).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = FacturaDetalleBLL.Modificar(factura.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(EncabezadoDetalle factura)
        {
            bool resultado = false;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    if (BLL.FacturaDetalleBLL.Eliminar(factura.Detalle))
                    {
                        conexion.Entry(factura.Encabezado).State = EntityState.Deleted;
                        resultado = conexion.SaveChanges() > 0;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static List<Facturas> Listar()
        {
            List<Facturas> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.Factura.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static List<Facturas> Listar(int? clienteId)
        {
            List<Facturas> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.Factura.
                    Where(f => f.IdCliente == clienteId).
                    OrderBy(f => f.Fecha).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Eliminar(int? facturaId)
        {
            try
            {
                return Eliminar(Buscar(facturaId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Guardar(Facturas factura)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Factura.Add(factura);
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static Facturas BuscarEncabezado(int? facturaId)
        {
            Facturas factura = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    factura = conexion.Factura.Find(facturaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }
        public static bool EliminarEncabezado(int? facturaId)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(BuscarEncabezado(facturaId)).State = EntityState.Deleted;
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool ModificarEncabezado(int? facturaId)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(BuscarEncabezado(facturaId)).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static int Identity()
        {
            int identity = 0;
            string con =
            @"Data Source=elgenerico.database.windows.net;Initial Catalog=LaGenerica;User ID=engel;Password=Valores2017";
            using (SqlConnection conexion = new SqlConnection(con))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Facturas')", conexion);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }
    }
}