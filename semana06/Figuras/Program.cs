using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Forma> formas = new List<Forma>();

        Quadrado f1 = new Quadrado("Vermelho", 5.0);
        formas.Add(f1);

        Retangulo f2 = new Retangulo("Azul", 4.0, 6.0);
        formas.Add(f2);

        Circulo f3 = new Circulo("Verde", 3.09);
        formas.Add(f3);

        foreach (Forma f in formas)
        {
            string cor = f.ObterCor();
            double area = f.ObterArea();
            Console.WriteLine($"Cor: {cor}, Área: {area}");
        }
    }
}