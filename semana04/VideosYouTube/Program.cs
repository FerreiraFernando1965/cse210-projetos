using System;
using System.Collections.Generic;

public class Comentario
{
    private string _nome;
    private string _texto;

    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }

    public string GetNome()
    {
        return _nome;
    }

    public string GetTexto()
    {
        return _texto;
    }
}

public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracao;
    private List<Comentario> _comentarios;

    public Video(string titulo, string autor, int duracao)
    {
        _titulo = titulo;
        _autor = autor;
        _duracao = duracao;
        _comentarios = new List<Comentario>();
    }

    public string GetTitulo()
    {
        return _titulo;
    }

    public string GetAutor()
    {
        return _autor;
    }

    public int GetDuracao()
    {
        return _duracao;
    }

    public void AdicionarComentario(Comentario comentario)
    {
        _comentarios.Add(comentario);
    }

    public int NumComentario()
    {
        return _comentarios.Count;
    }
}

public class Program
{
    public static void Main()
    {
        // ==========================================
        // VÍDEO 1
        // ==========================================
        Video video1 = new Video("Que sabor", "Concy Pizzaz", 450);
        video1.AdicionarComentario(new Comentario("Godofredo", "Ótima apresentação das pizzas!"));
        video1.AdicionarComentario(new Comentario("Genoveva", "Deu água na boca só de ver as imagens!"));
        video1.AdicionarComentario(new Comentario("Epaminondas", "Preciso conferir pessoalmente! Que delícia!."));

        // ==========================================
        // VÍDEO 2
        // ==========================================
        Video video2 = new Video("Conhecendo a Europa", "Pelos quatro cantos do Mundo", 900);
        video2.AdicionarComentario(new Comentario("Gertrudes", "Que lugares incríveis!"));
        video2.AdicionarComentario(new Comentario("Rodolfo", "As dicas são maravilhosas!"));
        video2.AdicionarComentario(new Comentario("Guglielmo", "Não iamginava que era assim!"));

        // ==========================================
        // VÍDEO 3
        // ==========================================
        Video video3 = new Video("Todo atrapalhado", "Aventuras em Família", 1200);
        video3.AdicionarComentario(new Comentario("Dermival", "To rindo até agora! Eu sou mais ou menos desse jeito!"));
        video3.AdicionarComentario(new Comentario("Crotilde", "Não é possível uma pessoa ser tão atrapalhada!!!"));
        video3.AdicionarComentario(new Comentario("Clarisbina", "Caramba! Não sei como a pessoa saiu viva!"));

        // ==========================================
        // VÍDEO 4
        // ==========================================
        Video video4 = new Video("Adivinhe quem foi", "Mistérios de Sorocaba", 750);
        video4.AdicionarComentario(new Comentario("Artaxerxes", "Puxa! Não consegui descobrir o culpado!"));
        video4.AdicionarComentario(new Comentario("Florisvaldo", "Cheio de suspense!"));
        video4.AdicionarComentario(new Comentario("Filomena", "Eu descobri logo de cara!"));

        // ==========================================
        // EXIBIÇÃO DOS RESULTADOS
        // ==========================================
        List<Video> listaDeVideos = new List<Video> { video1, video2, video3, video4 };

        int contador = 1;
        foreach (Video v in listaDeVideos)
        {
            Console.WriteLine($"Vídeo {contador} | Autor: {v.GetAutor()} | Total de Comentários: {v.NumComentario()}");
            contador++;
        }
    }
}