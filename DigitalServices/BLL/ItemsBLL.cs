using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalServices.Models;
using DigitalServices.DAL;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DigitalServices.BLL
{
    public class ItemsBLL
    {
        public static bool Guardar(Items item)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Items.Add(item);
                    if (conexion.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static Items Buscar(int? itemId)
        {
            Items item = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    item = conexion.Items.Find(itemId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return item;
        }
        public static bool Modificar(Items item)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(item).State = System.Data.Entity.EntityState.Modified;
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
        public static bool Eliminar(Items item)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(item).State = EntityState.Deleted;
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
        public static List<Items> Listar()
        {
            List<Items> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.Items.OrderBy(i => i.Descripcion).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? itemId)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    return Eliminar(Buscar(itemId));
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
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Items')", conexion);
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