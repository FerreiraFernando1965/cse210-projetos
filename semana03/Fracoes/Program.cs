using System;

class Fracao
{
    // Atributos privados (gavetas de dados)
    private int _numerador;
    private int _denominador;

    // Construtor 1: Padrão (Sem parâmetros -> 1/1)
    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    // Construtor 2: Recebe apenas um número inteiro (ex: 5 -> 5/1)
    public Fracao(int numeroInteiro)
    {
        _numerador = numeroInteiro;
        _denominador = 1;
    }

    // Construtor 3: Recebe numerador e denominador (ex: 3, 4 -> 3/4)
    public Fracao(int numerador, int denominador)
    {
        _numerador = numerador;
        _denominador = denominador == 0 ? 1 : denominador; // Impede divisão por zero
    }

    // Métodos para obter e alterar o Numerador
    public int ObterNumerador()
    {
        return _numerador;
    }

    public void DefinirNumerador(int numerador)
    {
        _numerador = numerador;
    }

    // Métodos para obter e alterar o Denominador
    public int ObterDenominador()
    {
        return _denominador;
    }

    public void DefinirDenominador(int denominador)
    {
        _denominador = denominador == 0 ? 1 : denominador; // Proteção contra zero
    }

    // Retorna a fração no formato em texto (ex: "3/4")
    public string ObterFracaoEmTexto()
    {
        return $"{_numerador}/{_denominador}";
    }

    // Calcula o valor real da fração em número decimal (ex: 3/4 -> 0.75)
    public double ObterFracaoEmDecimal()
    {
        if (_denominador == 0)
        {
            return 0;
        }

        return (double)_numerador / _denominador;
    }
}

// Execução principal
class Program
{
    static void Main(string[] args)
    {
        // Instância 1: usa o construtor padrão (1/1 = 1)
        Fracao f1 = new Fracao();
        Console.WriteLine(f1.ObterFracaoEmTexto());   // Imprime "1/1"
        Console.WriteLine(f1.ObterFracaoEmDecimal()); // Imprime "1"

        // Instância 2: usa o construtor de número inteiro (5/1 = 5)
        Fracao f2 = new Fracao(5);
        Console.WriteLine(f2.ObterFracaoEmTexto());   // Imprime "5/1"
        Console.WriteLine(f2.ObterFracaoEmDecimal()); // Imprime "5"

        // Instância 3: usa o construtor completo (3/4 = 0.75)
        Fracao f3 = new Fracao(3, 4);
        Console.WriteLine(f3.ObterFracaoEmTexto());   // Imprime "3/4"
        Console.WriteLine(f3.ObterFracaoEmDecimal()); // Imprime "0.75"

        // Instância 4: usa o construtor completo (1/3 = 0.333...)
        Fracao f4 = new Fracao(1, 3);
        Console.WriteLine(f4.ObterFracaoEmTexto());   // Imprime "1/3"
        Console.WriteLine(f4.ObterFracaoEmDecimal()); // Imprime "0.3333333333333333"
    }
}