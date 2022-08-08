using System.ComponentModel.DataAnnotations;

namespace M2S10Ex4.Models
{
    public class Artista
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "O nome do artista é obrigatório.")]
        public string Nome { get; set; }
        public string Banda { get; set; }
        public string Site { get; set; }
        public bool EmAtividade { get; set; }
    }
}
