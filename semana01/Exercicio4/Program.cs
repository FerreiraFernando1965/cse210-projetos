using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, Mundo! Este é o Projeto Exercicio4.");

        List<int> numeros = new List<int>();

        Console.WriteLine("Digite um número (positivos e negativos) ou Digite 0 para sair:");

        // Leitura dos números usando int.Parse
        while (true)
        {
            Console.Write("Digite um número: ");
            
            int numero = int.Parse(Console.ReadLine()); // Lê e converte para int
            
            if (numero == 0)
            {
                break; // encerra o loop
            }

            numeros.Add(numero);
        }

        if (numeros.Count == 0)
        {
            Console.WriteLine("Nenhum número foi inserido.");
            return;
        }

        int soma = 0;
        foreach (int n in numeros)
        {
            soma += n;
        }

       
        int media = soma / numeros.Count;

        int maior = numeros[0];
        foreach (int n in numeros)
        {
            if (n > maior)
            {
                maior = n;
            }
        }

        Console.WriteLine($"\nSoma: {soma}");
        Console.WriteLine($"Média: {media}");
        Console.WriteLine($"Maior número: {maior}");
    }
}