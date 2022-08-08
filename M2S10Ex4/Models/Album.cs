namespace M2S10Ex4.Models
{
    public class Album
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Capa { get; set; }
        public Artista Artista { get; set; }

        public Album(string nome, int ano, string capa, Artista artista)
        {
            Nome = nome;
            Ano = ano;
            Capa = capa;
            Artista = artista;
        }
    }
}
