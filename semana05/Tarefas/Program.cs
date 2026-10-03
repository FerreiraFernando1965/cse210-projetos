using System;




class Program
{
    static void Main(string[] args)
    {
        // Teste da classe base Tarefa
        Tarefa tarefa = new Tarefa("Samuel Bennett", "Multiplicação");
        Console.WriteLine(tarefa.ObterResumo());

        Console.WriteLine();

        // Teste da classe TarefaDeMatematica
        TarefaDeMatematica tarefaMatematica = new TarefaDeMatematica("Roberto Rodriguez", "Frações", "7.3", "8-19");
        Console.WriteLine(tarefaMatematica.ObterResumo());
        Console.WriteLine(tarefaMatematica.ObterListaDeTarefas());

        Console.WriteLine();

        // Teste da classe TarefaDeRedacao
        TarefaDeRedacao tarefaRedacao = new TarefaDeRedacao("Mary Waters", "História Europeia", "A Segunda Guerra Mundial");
        Console.WriteLine(tarefaRedacao.ObterResumo());
        Console.WriteLine(tarefaRedacao.ObterInformacoesDaRedacao());
    }
}