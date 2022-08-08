using M2S10Ex4.Models;
using M2S10Ex4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace M2S10Ex4.Controllers
{
    [ApiController]
    [Route("api/artistas")]
    public class ArtistasController : ControllerBase
    {



        private readonly ArtistaRepositorio _artistaRepositorio;
        public ArtistasController(ArtistaRepositorio repositorio)
        {
            _artistaRepositorio = repositorio;
        }
        //GET api/artista?nome
        [HttpGet]
        public ActionResult<Artista> Get(
            [FromQuery] string filtro
            )
        {
            return Ok(_artistaRepositorio.ObterTodos(filtro));
        }

        [HttpPost]

        public ActionResult<Artista> Post(
            [FromBody] Artista novoArtista
            )
        {
            var artista = _artistaRepositorio.Criar(novoArtista);
            return Created("/artistas", artista);
        }

        //PUT api/artistas/{id}
        [HttpPut("{idArtista}")]
        public ActionResult<Artista> Put(
            [FromBody] Artista artista,
            [FromRoute] int idArtista
        )
        {
            var artistaEditado = _artistaRepositorio.Atualizar(idArtista, artista);

            return Ok(artistaEditado);
        }

        //DELETE api/artistas/{id}
        [HttpDelete("{idArtista}")]
        public ActionResult<Artista> Delete(

            [FromRoute] int idArtista
        )
        {
            _artistaRepositorio.Remover(idArtista);

            return NoContent();
        }
    }
}