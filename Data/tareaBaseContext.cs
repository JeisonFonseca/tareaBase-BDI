using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tareaBase.Modelo;

namespace tareaBase.Data
{
    public class tareaBaseContext : DbContext
    {
        public tareaBaseContext (DbContextOptions<tareaBaseContext> options)
            : base(options)
        {
        }

        public DbSet<tareaBase.Modelo.Zoologico> Zoologico { get; set; } = default!;
    }
}
