using System;

public class Fracao
{
    // Atributos privados
    private int _numerador;
    private int _denominador;

    // Construtor 1: Sem parâmetros (inicializa como 1/1)
    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    // Construtor 2: Recebe apenas o numerador (inicializa o denominador como 1)
    public Fracao(int numeroInteiro)
    {
        _numerador = numeroInteiro;
        _denominador = 1;
    }

    // Construtor 3: Recebe o numerador e o denominador
    public Fracao(int numerador, int denominador)
    {
        _numerador = numerador;
        _denominador = denominador;
    }

    // Getters e Setters
    public int ObterNumerador()
    {
        return _numerador;
    }

    public void DefinirNumerador(int numerador)
    {
        _numerador = numerador;
    }

    public int ObterDenominador()
    {
        return _denominador;
    }

    public void DefinirDenominador(int denominador)
    {
        _denominador = denominador;
    }

    // Métodos para representação da fração
    public string ObterFracaoEmTexto()
    {
        return $"{_numerador}/{_denominador}";
    }

    public double ObterFracaoEmDecimal()
    {
        return (double)_numerador / _denominador;
    }
}