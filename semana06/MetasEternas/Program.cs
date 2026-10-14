using System;

class Program
{ 
    public static void Main(string[] args)
    {
        Console.WriteLine("Olá, Mundo! Este é o Projeto MetasEternas.");
        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();
        gerenciador.Iniciar();
    }
}

// A classe Meta.cs é a classe base e define os métodos mas, não implementa, cabe a cada classe derivada fazer a implementação(polimorfismo).
// O programa Introspeccao.cs deu uma boa base para elaboração do código. A aplicação do polimorfismo, bem como a construção
// do menu de opções  quando começa o código e o registro em arquivo txt foi apresentado na tarefa da segunda 
//semana no programa Diario.cs, bem como a forma de obter as informações registradas, salvar, listar, etc.
// O encapsulamento pode ser observado nas classes derivadas quando é usado os modificadores de acesso private e
//na classe base é usado protected, permitindo somente o acesso das classes derivadas.
