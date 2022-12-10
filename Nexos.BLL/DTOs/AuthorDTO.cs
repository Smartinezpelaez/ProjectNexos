using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.BLL.DTOs
{
    public class AuthorDTO
    {
        [Key]
        public int IdAuthor { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Cumpleaños")]
        public DateTime? Birthday { get; set; }


        [Required]
        [Display(Name = "Ciudad")]
        public string? City { get; set; }


        [Required]
        [Display(Name = "Correo Electronico")]
        public string? Mail { get; set; }
    }
}
