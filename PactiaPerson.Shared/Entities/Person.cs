using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PactiaPerson.Shared.Entities
{
    //Capa de dominio para generar las entidades
    public class Person
    {
        public int id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        public string? cedula { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        public string? nombre { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        public string? apellido { get; set;}
    }
}
