using ControlClientes.DAL;
using ControlClientes.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlClientes.BLL
{
    public class ClientesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Clientes.Any(e => e.ClienteId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;

        }
        public static bool Insertar(Clientes persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Add(persona) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }

        private static bool Modificar(Clientes cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                Clientes anterior = Buscar(cliente.ClienteId);

                foreach (var item in cliente.Direciones)
                {
                    if (item.Id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
                }

                foreach (var item in anterior.Direciones)
                {
                    if (!cliente.Direciones.Any(A => A.Id == item.Id))
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }

                db.Entry(cliente).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Clientes.Find(id);

                if (eliminar != null)
                {
                    db.Clientes.Remove(eliminar);
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();

            Clientes cliente;

            try
            {
                cliente = contexto.Clientes
                   .Where(e => e.ClienteId == id)
                   .Include(e => e.Direciones)
                   .FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Clientes.Where(criterio).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
