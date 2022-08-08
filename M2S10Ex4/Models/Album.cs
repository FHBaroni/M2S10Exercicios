namespace M2S10Ex4.Models
{
    public class Album
    {
        public int Id { get; set; }
        public Artista Artista { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Capa { get; set; }
    }
}
