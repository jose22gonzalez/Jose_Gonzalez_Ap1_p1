using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jose_Gonzalez_Ap1_p1.DAL;
using Jose_Gonzalez_Ap1_p1.Entidades;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Jose_Gonzalez_Ap1_p1.BLL
{
    public class ProductoBLL
    {
        public static bool Existe(int productoID)
        {
            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Productos.Any(l => l.Productoid == productoID);
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Productos.Add(productos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Productos productos)
        {
           
            if(!Existe(productos.Productoid))
                return Insertar(productos);
            else
                return Modificar(productos);
        }

        public static bool Modificar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int productoID)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var producto = contexto.Productos.Find(productoID);
                if(producto != null)
                {
                    contexto.Productos.Remove(producto);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Productos? Buscar(int productoID)
        {
            Contexto contexto = new Contexto();
            Productos? productos;
            try
            {
                productos = contexto.Productos.Find(productoID);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Productos> lista = new List<Productos>();
            try{
                lista = contexto.Productos.Where(criterio).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Productos> GetLista()
        {
            using(var contexto = new Contexto())
            {
                return contexto.Productos.ToList();
            }
        }

        
    }
}