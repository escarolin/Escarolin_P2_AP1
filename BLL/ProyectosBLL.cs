using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Escarolin_P2_AP1.DAL;
using Escarolin_P2_AP1.Entidades;

namespace Escarolin_P2_AP1.BLL
{
    public class ProyectosBLL
    {
        
        
        public static bool Guardar(Proyectos proyectos)
        {
            bool paso;

            if (!Existe(proyectos.ProyectoId))
                paso = Insertar(proyectos);
            else
                paso = Modificar(proyectos);

            return paso;
        }
        //Insertar
        public static bool Insertar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                foreach (var item in proyectos.Detalle)
                {
                    contexto.Entry(item.tareas).State = EntityState.Modified;
                }

                contexto.Proyectos.Add(proyectos);
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
        //Modificar
        public static bool Modificar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From Proyectos_Detalle Where ProyectoId={proyectos.ProyectoId}");

                foreach (var item in proyectos.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(proyectos).State = EntityState.Modified;
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
        //Eliminar
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyectos = contexto.Proyectos.Find(id);
                if (proyectos != null)
                {
                    contexto.Proyectos.Remove(proyectos);
                    paso = contexto.SaveChanges() > 0;
                }
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
        //GetList
        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
        //Existe
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyectos.Any(p => p.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        //Buscar
        public static Proyectos Buscar(int id)
        {
            Proyectos proyectos = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyectos = contexto.Proyectos
                    .Where(p => p.ProyectoId == id)
                    .Include(p => p.Detalle)
                    .ThenInclude(t => t.tareas)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyectos;
        }
    }
}
