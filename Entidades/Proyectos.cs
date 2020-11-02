using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Escarolin_P2_AP1.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public double TiempoTotal { get; set; }

        [ForeignKey("ProyectoId")]
        public virtual List<Proyectos_Detalle> Detalle { get; set; } = new List<Proyectos_Detalle>();
    }
}
