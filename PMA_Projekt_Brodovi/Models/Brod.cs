using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMA_Projekt_Brodovi.Models
{
    public class Brod
    {
        public int BrodId { get; set; }
        public int SvojstvaBrodaId { get; set; }

        public int VlasnikId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [DisplayName("Ime broda:")]
        public string ImeBroda { get; set; }
        [Column(TypeName = "varchar(250)")]

        [DisplayName("Refistracijska oznaka:")]
        public string RegistracijskeOznake { get; set; }

        public SvojstvaBroda SvojstvaBroda { get; set; }

        public Vlasnik Vlasnik { get; set; }
    }
}
