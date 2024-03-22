using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SerieA.Models;

namespace SerieA.Data
{
    public class SerieAContext : DbContext
    {
        public SerieAContext (DbContextOptions<SerieAContext> options)
            : base(options)
        {
        }

        public DbSet<SerieA.Models.Squadra> Squadra { get; set; } = default!;
        public DbSet<SerieA.Models.Calciatore> Calciatore { get; set; } = default!;
    }
}
