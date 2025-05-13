using System.Net.NetworkInformation;
using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    private readonly ScreenSoundContext context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<Artista> Listar()
    {
        using var context = new ScreenSoundContext();

        return context.Artistas.ToList();
    }
    public void Adicionar(Artista artista)
    {
        using var context = new ScreenSoundContext();
        context.Artistas.Add(artista);
        context.SaveChanges();
    }
    public void Atualizar(Artista artista)
    {
        context.Artistas.Update(artista);
        context.SaveChanges();
    }
    public void Deletar(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }
    public Artista? RecuperarPeloNome(string nome)
    {
        return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));

    }
}
