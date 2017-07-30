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
    public class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Cliente.Add(cliente);
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
        public static Clientes Buscar(int? clienteId)
        {
            Clientes cliente = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    cliente =  conexion.Cliente.Find(clienteId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cliente;
        }
        public static bool Modificar(Clientes cliente)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(cliente).State = EntityState.Modified;
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
        public static bool Eliminar(Clientes cliente)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(cliente).State = EntityState.Deleted;
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
        public static List<Clientes> Listar()
        {
            List<Clientes> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.Cliente.OrderBy(c => c.Nombres).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? clienteId)
        {
            try
            {
                return Eliminar(Buscar(clienteId));
            }
            catch (Exception)
            {

                throw;
            }
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
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Clientes')", conexion);
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