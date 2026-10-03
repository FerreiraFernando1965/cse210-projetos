using System;




class Program
{
    static void Main(string[] args)
    {
        // Teste da classe base Tarefa
        Tarefa tarefa = new Tarefa("Crotilde Bernardo", "Divisão");
        Console.WriteLine(tarefa.ObterResumo());

    

        // Teste da classe TarefaDeMatematica
        TarefaDeMatematica tarefaMatematica = new TarefaDeMatematica("Crovis Cardinal", "Interpolação", "317.3", "118-198");
        Console.WriteLine(tarefaMatematica.ObterResumo());
        Console.WriteLine(tarefaMatematica.ObterListaDeTarefas());

       

        // Teste da classe TarefaDeRedacao
        TarefaDeRedacao tarefaRedacao = new TarefaDeRedacao("Marineide Catarina", "História Europeia da Carochinha", "A Segunda Grande Guerra ");
        Console.WriteLine(tarefaRedacao.ObterResumo());
        Console.WriteLine(tarefaRedacao.ObterInformacoesDaRedacao());
    }
}