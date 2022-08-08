using M2S10Ex4.Models;

namespace M2S10Ex4.Repositories;
public class ArtistaRepositorio
{
    private static int _indiceId = 1;
    private static List<Artista> _artistas = new();

    public Artista Criar(Artista artista)
    {
        artista.Id = _indiceId;
        _indiceId++;

        _artistas.Add(artista);
        return artista;
    }

    public Artista Atualizar(int id, Artista artista)
    {
        var artistaExistente = _artistas
            .FirstOrDefault(artistaLista => artistaLista.Id == id);

        if (artistaExistente == null) return null;

        artistaExistente.Nome = artista.Nome;
        artistaExistente.Site = artista.Site;
        artistaExistente.EmAtividade = artista.EmAtividade;
        artistaExistente.Banda = artista.Banda;

        return artista;
    }
    public void Remover(int artistaId)
    {
        var artistaExistente = _artistas
            .FirstOrDefault(artistaLista => artistaLista.Id == artistaId);
        _artistas.Remove(artistaExistente);
    }

    public List<Artista> ObterTodos()
    {
        return _artistas;
    }


}

