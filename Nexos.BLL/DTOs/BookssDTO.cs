using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.BLL.DTOs
{
    public class BookssDTO
    {
        [Key]
        public int IdBook { get; set; }

        [Required]
        [Display(Name = "Titulo del libro")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Fecha de publicación")]
        public DateTime? Year { get; set; }

        [Required]
        [Display(Name = "Numero de paginas")]
        public int? Pages { get; set; }

        [Required]
        [Display(Name = "Autor")]
        public string? Author { get; set; }

    }
}
