namespace M2S11Exercicios.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TimeSpan Duracao { get; set; }
        public int? AlbumId { get; set; }
        public int ArtistaId { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artista Artista { get; set; }

    }
}
