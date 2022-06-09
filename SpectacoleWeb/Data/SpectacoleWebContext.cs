using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Data
{
    public class SpectacoleWebContext : DbContext
    {
        public SpectacoleWebContext (DbContextOptions<SpectacoleWebContext> options)
            : base(options)
        {
        }

        public DbSet<SpectacoleWeb.Models.Show>? Show { get; set; }

        public DbSet<SpectacoleWeb.Models.Ticket>? Ticket { get; set; }

        public DbSet<SpectacoleWeb.Models.User>? User { get; set; }
    }
}
