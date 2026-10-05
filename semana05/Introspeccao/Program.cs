using System;

namespace Introspeccao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";

            while (opcao != "4")
            {
                Console.Clear();
                Console.WriteLine("=== Menu de Actividades de Introspecção ===");
                Console.WriteLine("1. Iniciar Respiração Guiada");
                Console.WriteLine("2. Iniciar Atividade de Reflexão");
                Console.WriteLine("3. Iniciar Atividade de Listagem");
                Console.WriteLine("4. Sair");
                Console.Write("\nEscolha uma opção: ");

                opcao = Console.ReadLine();

                Console.Clear();
                switch (opcao)
                {
                    case "1":
                        Respiracao respiracao = new Respiracao();
                        respiracao.Executar();
                        break;

                    case "2":
                        Reflexao reflexao = new Reflexao();
                        reflexao.Executar();
                        break;

                    case "3":
                        Listagem listagem = new Listagem();
                        listagem.Executar();
                        break;

                   
                }
            }
        }
    }
}