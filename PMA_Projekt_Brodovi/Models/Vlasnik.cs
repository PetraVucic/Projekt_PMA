using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMA_Projekt_Brodovi.Models
{
    public class Vlasnik
    {
        public int VlasnikId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Ime vlasnika:")]
        public string ImeVlasnika { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Prezime vlasnika:")]
        public string PrezimeVlasnika { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("OIB vlasnika:")]
        public int OibVlasnika { get; set; }
    }
}
