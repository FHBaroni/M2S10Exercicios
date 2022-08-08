namespace M2S10Ex4.Models
{
    public class Musica
    {
        public string Nome { get; set; }
        public TimeSpan duracao { get; set; }
        public Album Album { get; set; }
        public Artista Artista { get; set; }
    }
}
