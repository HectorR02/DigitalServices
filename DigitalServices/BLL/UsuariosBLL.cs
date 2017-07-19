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
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Usuarios.Add(usuario);
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
        public static Usuarios Buscar(int? usuarioId)
        {
            Usuarios usuario = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    usuario = conexion.Usuarios.Find(usuarioId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return usuario;
        }
        public static bool Eliminar(Usuarios usuario)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(usuario).State = EntityState.Deleted;
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
        public static bool Modificar(Usuarios usuario)
        {
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    conexion.Entry(usuario).State = EntityState.Modified;
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
        public static List<Usuarios> Listar()
        {
            List<Usuarios> listado = null;
            using (var conexion = new DigitalServicesDB())
            {
                try
                {
                    listado = conexion.Usuarios.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? usuarioId)
        {
            try
            {
                return Eliminar(Buscar(usuarioId));
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
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Usuarios')", conexion);
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