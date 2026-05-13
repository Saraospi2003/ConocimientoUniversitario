using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;
using System.ComponentModel.DataAnnotations;

  public class Acreditacion
    {
        [Key]
        public int Resolucion { get; set; }

        public string? Tipo { get; set; }
        public int? Calificacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public int? ProgramaId { get; set; }

        public Programa? Programa { get; set; }
    }