
public class TarefaDeMatematica : Tarefa  //Aqui foi usado os dois pontos para indicar que
                                          // a classe TarefaDeMatematica é uma subclasse da classe Tarefa.
{
    private string _capitulo;
    private string _problemas;

    public TarefaDeMatematica(string nomeEstudante, string topico, string capitulo, string problemas)
        : base(nomeEstudante, topico) // aqui foi chamado  quatro parâmetros, mas somente os dois últimos estão discriminados
                                      // na classe TarefaDeMatematica, os dois primeiros são recebidos da classe base Tarefa.
    {
        _capitulo = capitulo;
        _problemas = problemas;
    }

    public string ObterListaDeTarefas()
    {
        return $"Capítulo {_capitulo} Problemas {_problemas}";
    }
}