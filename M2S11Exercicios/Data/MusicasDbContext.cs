using M2S11Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace M2S11Exercicios.Data
{
    public class MusicasDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MusicasDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Album> albuns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DB_MUSICAS"));
        }
    }
}
