using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escarolin_P2_AP1.Entidades
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public string DescripcionT { get; set; }
    }
}
