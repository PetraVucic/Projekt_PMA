using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMA_Projekt_Brodovi.Areas.Identity.Data;

namespace PMA_Projekt_Brodovi.Data
{
    public class PMA_Projekt_BrodoviContext : IdentityDbContext<PMA_Projekt_BrodoviUser>
    {
        public PMA_Projekt_BrodoviContext(DbContextOptions<PMA_Projekt_BrodoviContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
