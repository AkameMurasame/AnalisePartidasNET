using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playground.Models
{
    public class DbContextMysql : DbContext
    {
        public DbContextMysql(DbContextOptions<DbContextMysql> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Invocador> Invocadores { get; set; }

        public DbSet<Partida> Partidas { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Spell> Spells { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=teste");
            }
        }
    }
}
