using System;
using System.Collections.Generic;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontosTotais;

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontosTotais = 0;
    }

    private static void LimparTela()
    {
        if (!Console.IsOutputRedirected)
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
            }
        }
    }

    private static void AguardarContinuacao()
    {
        if (!Console.IsInputRedirected && Environment.UserInteractive)
        {
            Console.ReadKey();
        }
    }

    private static string LerTexto(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string valor = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(valor))
            {
                return valor.Trim();
            }

            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    private static bool TentarLerInteiro(string mensagem, out int valor)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out valor))
            {
                return true;
            }

            Console.WriteLine("Entrada inválida. Digite apenas números inteiros.");
        }
    }

    public void Iniciar()
    {
        int opcao = 0;
        do
        {
            LimparTela();
            Console.WriteLine($"Você tem {_pontosTotais} pontos.\n");
            Console.WriteLine("Opções do Menu:");
            Console.WriteLine("1. Criar Nova Meta");
            Console.WriteLine("2. Listar Metas");
            Console.WriteLine("3. Salvar Metas");
            Console.WriteLine("4. Carregar Metas");
            Console.WriteLine("5. Registrar Evento");
            Console.WriteLine("6. Sair");
            Console.Write("Selecione uma opção do menu: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        CriarMeta();
                        break;
                    case 2:
                        ListarMetas();
                        break;
                    case 3:
                        SalvarMetas();
                        break;
                    case 4:
                        CarregarMetas();
                        break;
                    case 5:
                        RegistrarEvento();
                        break;
                    case 6:
                        Console.WriteLine("\nSaindo do programa... Até logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para continuar.");
                        AguardarContinuacao();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nEntrada inválida. Pressione qualquer tecla para continuar.");
                AguardarContinuacao();
            }
        }
        while (opcao != 6);
    }

    private void CriarMeta()
    {
        Console.WriteLine("\nOs tipos de metas são:");
        Console.WriteLine("1. Meta Simples");
        Console.WriteLine("2. Meta Eterna");
        Console.WriteLine("3. Meta de Lista de Tarefas");

        if (!TentarLerInteiro("Escolha um tipo de meta: ", out int tipo) || (tipo < 1 || tipo > 3))
        {
            Console.WriteLine("\nTipo de meta inválido.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            AguardarContinuacao();
            return;
        }

        string nome = LerTexto("Qual é o nome da meta? ");
        string descricao = LerTexto("Descreva sua meta? ");

        if (!TentarLerInteiro("Quantos pontos para esta meta? ", out int pontos) || pontos < 0)
        {
            Console.WriteLine("\nPontuação inválida. A pontuação deve ser maior ou igual a zero.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            AguardarContinuacao();
            return;
        }

        if (tipo == 1)
        {
            _metas.Add(new MetaSimples(nome, descricao, pontos));
            Console.WriteLine("\nMeta Simples criada com sucesso!");
        }
        else if (tipo == 2)
        {
            _metas.Add(new MetaEterna(nome, descricao, pontos));
            Console.WriteLine("\nMeta Eterna criada com sucesso!");
        }
        else
        {
            if (!TentarLerInteiro("Quantas vezes essa meta deve ser realizada para ser concluída? ", out int total) || total <= 0)
            {
                Console.WriteLine("\nNúmero de vezes inválido. Deve ser maior que zero.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                AguardarContinuacao();
                return;
            }

            if (!TentarLerInteiro("Quantos pontos ao completar todas as vezes? ", out int bonus) || bonus < 0)
            {
                Console.WriteLine("\nBônus inválido. O bônus deve ser maior ou igual a zero.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                AguardarContinuacao();
                return;
            }

            _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus));
            Console.WriteLine("\nMeta de Lista de Tarefas criada com sucesso!");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        AguardarContinuacao();
    }

    private void ListarMetas()
    {
        Console.WriteLine("\n--- Lista de Metas ---");
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
        }
        else
        {
            for (int i = 0; i < _metas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_metas[i].ObterRepresentacaoEmTexto()}");
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        AguardarContinuacao();
    }

    private void RegistrarEvento()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("\nNão há metas cadastradas para registrar eventos.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            AguardarContinuacao();
            return;
        }

        Console.WriteLine("\nQual meta você concluiu:");
        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_metas[i].Nome}");
        }

        if (!TentarLerInteiro("Digite o número da meta: ", out int escolha) || escolha < 1 || escolha > _metas.Count)
        {
            Console.WriteLine("\nSeleção inválida.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            AguardarContinuacao();
            return;
        }

        Meta metaSelecionada = _metas[escolha - 1];
        int pontosGanhos = metaSelecionada.RegistrarEvento();
        _pontosTotais += pontosGanhos;

        Console.WriteLine($"\nParabéns! Evento registrado com sucesso. Você ganhou {pontosGanhos} pontos!");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        AguardarContinuacao();
    }

    private void SalvarMetas()
    {
        string nomeArquivo = LerTexto("\nDigite o nome do arquivo para salvar (ex: metas.txt): ");

        try
        {
            using (StreamWriter arquivoSaida = new StreamWriter(nomeArquivo))
            {
                arquivoSaida.WriteLine(_pontosTotais);
                foreach (var meta in _metas)
                {
                    arquivoSaida.WriteLine(meta.ObterStringSalvamento());
                }
            }
            Console.WriteLine("\nMetas salvas com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao salvar o arquivo: {ex.Message}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        AguardarContinuacao();
    }

    private void CarregarMetas()
    {
        string nomeArquivo = LerTexto("\nDigite o nome do arquivo para carregar (ex: metas.txt): ");

        if (!File.Exists(nomeArquivo))
        {
            Console.WriteLine("\nArquivo não encontrado.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            AguardarContinuacao();
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            if (linhas.Length == 0)
            {
                Console.WriteLine("\nArquivo vazio. Nenhuma meta foi carregada.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                AguardarContinuacao();
                return;
            }

            if (int.TryParse(linhas[0], out int pontosLidos))
            {
                _pontosTotais = pontosLidos;
            }
            else
            {
                _pontosTotais = 0;
            }

            _metas.Clear();

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                {
                    continue;
                }

                string[] partes = linhas[i].Split('|');
                if (partes.Length < 4)
                {
                    continue;
                }

                string tipo = partes[0];

                if (tipo == "MetaSimples")
                {
                    if (partes.Length < 5) continue;
                    string nome = partes[1];
                    string desc = partes[2];
                    int pontos = int.Parse(partes[3]);
                    bool concluida = bool.Parse(partes[4]);
                    _metas.Add(new MetaSimples(nome, desc, pontos, concluida));
                }
                else if (tipo == "MetaEterna")
                {
                    string nome = partes[1];
                    string desc = partes[2];
                    int pontos = int.Parse(partes[3]);
                    _metas.Add(new MetaEterna(nome, desc, pontos));
                }
                else if (tipo == "MetaDeListaDeTarefas")
                {
                    if (partes.Length < 7) continue;
                    string nome = partes[1];
                    string desc = partes[2];
                    int pontos = int.Parse(partes[3]);
                    int total = int.Parse(partes[4]);
                    int bonus = int.Parse(partes[5]);
                    int concluidas = int.Parse(partes[6]);
                    _metas.Add(new MetaDeListaDeTarefas(nome, desc, pontos, total, bonus, concluidas));
                }
            }

            Console.WriteLine("\nMetas e pontuação carregadas com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao ler o arquivo: {ex.Message}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        AguardarContinuacao();
    }
}