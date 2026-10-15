using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, Mundo! Este é o Projeto MonitoramentoExercicios.");

       
            
        List<Atividade> atividades = new List<Atividade>
        {
            new Corrida("03 Nov 2022", 30, 4.8),      
            new Ciclismo("03 Nov 2022", 40, 24.0),    
            new Natacao("03 Nov 2022", 25, 20)        
        };

        
        foreach (var atividade in atividades)
        {
            
            Console.WriteLine(atividade.ObterResumo());
        }
    }
}
    
