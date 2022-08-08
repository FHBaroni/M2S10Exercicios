using M2S10Ex4.DTO;
using M2S10Ex4.Models;
using M2S10Ex4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace M2S10Ex4.Controllers
{
    [ApiController]
    [Route("api/albuns")]
    public class AlbunsController : ControllerBase
    {
        private readonly AlbumRepositorio _albumRepositorio;
        private readonly ArtistaRepositorio _artistaRepositorio;
        private readonly MusicaRepositorio _musicaRepositorio;

        public AlbunsController(
            AlbumRepositorio albumRepositorio,
            ArtistaRepositorio artistaRepositorio,
            MusicaRepositorio musicaRepositorio
            )
        {
            _albumRepositorio = albumRepositorio;
            _artistaRepositorio = artistaRepositorio;
            _musicaRepositorio = musicaRepositorio;
        }

        [HttpGet]
        public ActionResult<Album> GET()
        {
            return Ok(_albumRepositorio.ObterTodos());
        }

        [HttpGet("{idAlbum}/musicas")]
        public ActionResult<Musica> GETMusicasPorIdAlbum(
            [FromRoute] int idAlbum
        )
        {
            return Ok(_musicaRepositorio.ObterPorAlbum(idAlbum));
        }

        [HttpPost]
        public ActionResult<Album> Post(
        [FromBody] AlbumDTO albumJson
    )
        {
            var artista = _artistaRepositorio.ObterPorId(albumJson.ArtistaId);

            var album = new Album(
                albumJson.Nome,
                albumJson.Ano,
                albumJson.Capa,
                artista
            );

            _albumRepositorio.Criar(album);

            return Ok(album);
        }
        //public ActionResult<Album> POST(
        //   [FromBody] AlbumDTO albumJson
        //)
        //{
        //    var artista = _artistaRepositorio.ObterPorId(albumJson.ArtistaId);

        //    var album = new Album(
        //        albumJson.Nome,
        //        albumJson.Ano,
        //        albumJson.Capa,
        //        artista
        //        );
        //    _albumRepositorio.Criar(album);

        //    return Ok(album);
        //}

        [HttpPut("{idAlbum}")]
        public ActionResult<Album> PUT(
            [FromBody] AlbumDTO albumJson,
            [FromRoute] int idAlbum
        )
        {
            var artista = _artistaRepositorio.ObterPorId(albumJson.ArtistaId);

            var albumExistente = _albumRepositorio.ObterPorId(idAlbum);


            var album = _albumRepositorio.Atualizar(
                idAlbum,
                    new Album(
                     albumJson.Nome,
                     albumJson.Ano,
                     albumJson.Capa,
                     artista
                 )
            );

            return Ok(album);
        }

        [HttpDelete("{idAlbum}")]
        public ActionResult DELETE(
            int idAlbum
        )
        {
            _albumRepositorio.Remover(idAlbum);
            return NoContent();
        }
    }
}
