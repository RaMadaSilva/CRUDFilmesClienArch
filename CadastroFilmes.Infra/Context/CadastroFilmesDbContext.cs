using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Infra.EntityConfiguration;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Infra.Context
{
    public class CadastroFilmesDbContext : DbContext
    {
        public CadastroFilmesDbContext(DbContextOptions<CadastroFilmesDbContext> options )
            :base(options)
        { 
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Realizador> Realizadores { get; set;}

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Ignore<Notification>(); 
            base.OnModelCreating(mb);
            mb.ApplyConfiguration(new FilmeConfiguration()); 
            mb.ApplyConfiguration(new  RealizadorConfiguration());
        }
    }
}
