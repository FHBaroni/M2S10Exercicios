using System.ComponentModel.DataAnnotations;

namespace M2S10Ex4.DTO
{
    public class AlbumDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Range(1500, 3000, ErrorMessage = "O ano de lançamento precisa ser válido.")]
        public int Ano { get; set; }
        public string Capa { get; set; }
        [Required(ErrorMessage = "O artista é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do artista precisa ser válido.")]
        public int ArtistaId { get; set; }
    }
}

