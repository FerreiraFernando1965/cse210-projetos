using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, Mundo! Este é o Projeto Exercicio3 com números aleatórios.");

        // Instancia a classe Random para gerar números aleatórios
        Random random = new Random();

        // Gera um número aleatório entre 1 e 100 (o limite superior 101 é exclusivo)
        int numeroMagico = random.Next(1, 101);

        Console.WriteLine("O número mágico foi gerado automaticamente! Tente adivinhar entre 1 e 100.");

        // Inicializamos o palpite com um valor inválido para garantir que o loop comece
        int palpite = -1; 

        // O loop continua até que o palpite seja IGUAL ao número mágico
        while (palpite != numeroMagico)
        {
            Console.Write("Qual é o seu palpite? ");
            palpite = int.Parse(Console.ReadLine());

            // Verifica a tentativa
            if (palpite < numeroMagico)
            { 
                Console.WriteLine("Mais alto!"); 
            } 
            else if (palpite > numeroMagico)
            { 
                Console.WriteLine("Mais baixo!");
            }
            else
            { 
                Console.WriteLine("Você adivinhou!");
            } 
        }
    }
}