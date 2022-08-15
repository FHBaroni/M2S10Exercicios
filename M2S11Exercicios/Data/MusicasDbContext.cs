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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artista>(entidade =>
            {
                entidade.ToTable("Artistas");

                entidade.HasKey(a => a.Id);

                entidade
                .Property(a => a.Nome)
                .HasMaxLength(120)
                .IsRequired();

                entidade
                .Property(a => a.NomeArtistico)
                .HasMaxLength(120);

                entidade
                .Property(a => a.FotoUrl)
                .HasMaxLength(80)
                .IsRequired();
            });

            modelBuilder.Entity<Album>(entidade =>
            {
                entidade.ToTable("Albuns");

                entidade.HasKey(a => a.Id);

                entidade
                .Property(a => a.Nome)
                .HasMaxLength(120)
                .IsRequired();

                entidade
                .Property(a => a.AnoLancamento)
                .IsRequired();

                entidade
                .Property(a => a.CapaUrl)
                .HasMaxLength(80);


                entidade
                .HasOne(album => album.Artista)
                .WithMany(artista => artista.Album)
                .HasForeignKey(album => album.ArtistaId);

            });

            modelBuilder.Entity<Musica>(entidade =>
            {
                entidade.ToTable("Musicas");

                entidade.HasKey(m => m.Id);

                entidade
                .Property(m => m.Nome)
                .HasMaxLength(120)
                .IsRequired();

                entidade
                .Property(m => m.Duracao)
                .IsRequired();
                               
                entidade
                .HasOne(musica => musica.Artista)
                .WithMany(artista => artista.Musicas)
                .HasForeignKey(musica => musica.ArtistaId);

                entidade
                .HasOne(musica => musica.Album)
                .WithMany(album => album.Musicas)
                .HasForeignKey(musica => musica.AlbumId);
            });
        }
    }
}
