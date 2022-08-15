namespace M2S11Exercicios.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnoLancamento { get; set; }
        public int CapaUrl { get; set; }
        public int ArtistaId { get; set; }
        public virtual Artista Artista { get; set; }
        public virtual List<Musica> Musicas { get; set; }

    }
}
