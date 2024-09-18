using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Tareas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Ingrese máximo 100 caracteres por favor.")]

        public string Titulo { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Ingrese máximo 500 caracteres por favor.")]

        public string Descripcion { get; set; }
        [Required]

        public DateTime FechaCreacion { get; set; }
        [Required]
        public bool Estado { get; set; }

    }
}