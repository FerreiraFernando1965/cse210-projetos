using System;

namespace Introspeccao
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
                
                Console.WriteLine("1. Iniciar Atividade de Respiração");
                Console.WriteLine("2. Iniciar Atividade de Reflexão");
                Console.WriteLine("3. Iniciar Atividade de Listagem");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Respiracao respiracao = new Respiracao();
                        respiracao.ExecutarRespiracao();
                        break;
                    case "2":
                        Reflexao reflexao = new Reflexao();
                        reflexao.ExecutarReflexao();
                        break;
                    case "3":
                        Listagem listagem = new Listagem();
                        listagem.ExecutarListagem();
                        break;
                    case "4":
                        return;
                }
            }
        }
    }
}