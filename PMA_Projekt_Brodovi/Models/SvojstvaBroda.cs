using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMA_Projekt_Brodovi.Models
{
    public class SvojstvaBroda
    {
        public int SvojstvaBrodaId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Marka broda:")]
        public string MarkaBroda { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Model broda:")]
        public string ModelBroda { get; set; }
        [Column(TypeName = "varchar(100)")]

        [DisplayName("Boja broda:")]
        public string Boja { get; set; }
    }
}
