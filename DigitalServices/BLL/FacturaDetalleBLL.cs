using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalServices.Models;
using DigitalServices.DAL;
using System.Data.Entity;

namespace DigitalServices.BLL
{
    public class FacturaDetalleBLL
    {
        public static bool Guardar(FacturaDetalles detalle)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.FaturaDetalle.Add(detalle);
                    if (conexion.SaveChanges() > 0)
                    {
                        var item = BLL.ItemsBLL.Buscar(detalle.IdItem);
                        if(item.EsArticulo == 1)
                        {
                            item.Existencia = item.Existencia - detalle.Cantidad;
                            return BLL.ItemsBLL.Modificar(item);
                        }
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
        public static FacturaDetalles Buscar(int? detalleId)
        {
            FacturaDetalles detail = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    detail = conexion.FaturaDetalle.Find(detalleId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detail;
        }
        public static bool Modificar(FacturaDetalles detalle)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    if(Buscar(detalle.Id) != null)
                    {
                        conexion.Entry(detalle).State = EntityState.Modified;
                        if (conexion.SaveChanges() > 0)
                            return true;
                    }
                    else
                    {
                        return Guardar(detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool Eliminar(FacturaDetalles detalle)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    var item = BLL.ItemsBLL.Buscar(detalle.IdItem);
                    int cant = detalle.Cantidad;

                    conexion.Entry(detalle).State = EntityState.Deleted;
                    if (conexion.SaveChanges() > 0)
                    {
                        if(item.EsArticulo == 1)
                        {
                            item.Existencia = item.Existencia + cant;
                            return BLL.ItemsBLL.Modificar(item);
                        }
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
        public static List<FacturaDetalles> Listar()
        {
            List<FacturaDetalles> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.FaturaDetalle.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static List<FacturaDetalles> Listar(int? facturaId)
        {
            List<FacturaDetalles> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.FaturaDetalle.
                        Where(d => d.IdFactura == facturaId).
                        OrderBy(d => d.Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Guardar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    foreach (FacturaDetalles detail in detalles)
                    {
                        resultado = Guardar(detail);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Modificar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (FacturaDetalles detail in detalles)
                {
                    resultado = Modificar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static bool Eliminar(int? detalleId)
        {
            try
            {
                return Eliminar(Buscar(detalleId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Eliminar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (var detail in detalles)
                {
                    resultado = Eliminar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}