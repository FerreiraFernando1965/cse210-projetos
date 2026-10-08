using System;

namespace Introspeccao
{
    class Program
    {
        static void LimparTela()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
            }
        }

        static void Pausar()
        {
            if (Console.IsInputRedirected || Console.IsOutputRedirected)
            {
                return;
            }

            if (Environment.UserInteractive)
            {
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                LimparTela();
                Console.WriteLine("=== Programa de Introspecção ===");
                Console.WriteLine("1.  Respiração Guiada");
                Console.WriteLine("2.  Atividade de Reflexão");
                Console.WriteLine("3.  Atividade de Listagem");
                Console.WriteLine("4. Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcao))
                {
                    break;
                }

                LimparTela();

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

                    case "4":
                        continuar = false;
                        Console.WriteLine("Obrigado por usar o programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                if (opcao == "1" || opcao == "2" || opcao == "3")
                {
                    Pausar();
                }
            }
        }
    }
}