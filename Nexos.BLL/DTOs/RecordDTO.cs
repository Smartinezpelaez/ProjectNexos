using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.BLL.DTOs
{
    public class RecordDTO
    {
        [Key]
        public int IdRecord { get; set; }
        [Key]
        public int? IdBook { get; set; }
        [Key]
        public int? IdAuthor { get; set; }
    }
}
