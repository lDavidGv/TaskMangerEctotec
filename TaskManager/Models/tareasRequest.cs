using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class tareasRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingresar el titulo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Ingresar la descripción")]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}