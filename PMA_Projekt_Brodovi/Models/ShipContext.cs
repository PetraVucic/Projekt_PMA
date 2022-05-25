using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMA_Projekt_Brodovi.Models
{
    public class ShipContext:DbContext
    {
        public ShipContext(DbContextOptions<ShipContext> options):base(options)
        {

        }

        public DbSet<Brod> Brodovi { get; set; }

        public DbSet<SvojstvaBroda> SvojstvaBrodova { get; set; }

        public DbSet<Vlasnik> Vlasnici { get; set; }
    }
}
