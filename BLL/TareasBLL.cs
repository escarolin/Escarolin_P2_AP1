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
    public class TareasBLL
    {
        public static List<Tareas> GetTareas()
        {
            List<Tareas> tareas = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                tareas = contexto.Tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tareas;
        }
    }
}