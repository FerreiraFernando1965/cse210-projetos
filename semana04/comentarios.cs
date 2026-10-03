

public class Comentario
{
    private string _nome;
    private string _texto;

    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }
}

public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracao; // em segundos
    private List<Comentario> _comentario;

    public Video(string titulo,string autor, int duracao)
    {
        _titulo = titulo;
        _autor = autor;
        _duracao = duracao;
        _comentario = new List<Comentario>();
    }

    public string GetAutor()
    {
        return _autor;
    }

    public void AdicionarComentario(Comentario comentario)
    {
        _comentario.Add(comentario);
    }

    public int NumComentario()
    {
        return _comentario.Count;
    }
}
