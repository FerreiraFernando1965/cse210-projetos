
public class TarefaDeRedacao : Tarefa
{
    private string _titulo;

    public TarefaDeRedacao(string nomeEstudante, string topico, string titulo)
        : base(nomeEstudante, topico)
    {
        _titulo = titulo;
    }

    public string ObterInformacoesDaRedacao()
    {
        return $"{_titulo} por {ObterNomeEstudante()}";
    }
}