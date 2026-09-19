using System;
using System.Collections.Generic;
using System.IO;

namespace DiarioPessoal
{
    // =========================================================================
    // CLASSE 1: Registro
    // Atributos: _data, _textoPergunta, _textoResposta (+ Mood/Humor extra)
    // Método: Exibir()
    // =========================================================================
    public class Registro
    {
        private string _data;
        private string _textoPergunta;
        private string _textoResposta;
        private string _humor;

        public string Data => _data;
        public string TextoPergunta => _textoPergunta;
        public string TextoResposta => _textoResposta;
        public string Humor => _humor;

        public Registro(string textoPergunta, string textoResposta, string humor, string data = null)
        {
            _textoPergunta = textoPergunta;
            _textoResposta = textoResposta;
            _humor = humor;
            _data = data ?? DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void Exibir()
        {
            Console.WriteLine($"Data: {_data} | Humor: {_humor}");
            Console.WriteLine($"Pergunta: {_textoPergunta}");
            Console.WriteLine($"Resposta: {_textoResposta}");
            Console.WriteLine(new string('-', 50));
        }

        public string ParaLinhaCsv()
        {
            return $"\"{EscaparCsv(_data)}\",\"{EscaparCsv(_humor)}\",\"{EscaparCsv(_textoPergunta)}\",\"{EscaparCsv(_textoResposta)}\"";
        }

        private string EscaparCsv(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return texto.Replace("\"", "\"\"");
        }

        public static Registro DeLinhaCsv(string linhaCsv)
        {
            List<string> valores = ParseLinhaCsv(linhaCsv);
            if (valores.Count >= 4)
            {
                return new Registro(
                    textoPergunta: valores[2],
                    textoResposta: valores[3],
                    humor: valores[1],
                    data: valores[0]
                );
            }
            return null;
        }

        private static List<string> ParseLinhaCsv(string linha)
        {
            List<string> resultado = new List<string>();
            bool emAspas = false;
            string atual = "";

            for (int i = 0; i < linha.Length; i++)
            {
                char c = linha[i];

                if (c == '"')
                {
                    if (emAspas && i + 1 < linha.Length && linha[i + 1] == '"')
                    {
                        atual += '"';
                        i++;
                    }
                    else
                    {
                        emAspas = !emAspas;
                    }
                }
                else if (c == ',' && !emAspas)
                {
                    resultado.Add(atual);
                    atual = "";
                }
                else
                {
                    atual += c;
                }
            }
            resultado.Add(atual);
            return resultado;
        }
    }

    // =========================================================================
    // CLASSE 2: GeradorDePerguntas
    // Atributo: _perguntas
    // Método: ObterPerguntaAleatoria()
    // =========================================================================
    public class GeradorDePerguntas
    {
        private List<string> _perguntas;
        private Random _random;

        public GeradorDePerguntas()
        {
            _random = new Random();
            _perguntas = new List<string>
            {
                "O que aconteceu de mais interessante hoje?",
                "Qual foi a melhor parte do meu dia?",
                "Como vi a mão do Senhor em minha vida hoje?",
                "Qual foi a emoção mais forte que senti hoje?",
                "O que faltou para meu dia ser completo?",
                "O que eu cumpri de meta planejada para esta semana?",
                "O que eu planejei para a próxima semana?"
            };
        }

        public string ObterPerguntaAleatoria()
        {
            int indice = _random.Next(_perguntas.Count);
            return _perguntas[indice];
        }
    }

    // =========================================================================
    // CLASSE 3: Diario
    // Atributo: _registros
    // Métodos: AdicionarRegistro(), ExibirTodos(), SalvarNoArquivo(), CarregarDoArquivo()
    // =========================================================================
    public class Diario
    {
        private List<Registro> _registros;

        public Diario()
        {
            _registros = new List<Registro>();
        }

        public void AdicionarRegistro(Registro novoRegistro)
        {
            _registros.Add(novoRegistro);
        }

        public void ExibirTodos()
        {
            if (_registros.Count == 0)
            {
                Console.WriteLine("\nO diário está vazio.");
                return;
            }

            Console.WriteLine("\n=== REGISTROS DO DIÁRIO ===");
            foreach (var registro in _registros)
            {
                registro.Exibir();
            }
        }

        public void SalvarNoArquivo(string arquivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(arquivo))
                {
                    writer.WriteLine("Data,Humor,Pergunta,Resposta");
                    foreach (var registro in _registros)
                    {
                        writer.WriteLine(registro.ParaLinhaCsv());
                    }
                }
                Console.WriteLine($"\nDiário salvo com sucesso no arquivo: {arquivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao salvar o arquivo: {ex.Message}");
            }
        }

        public void CarregarDoArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("\nArquivo não encontrado.");
                return;
            }

            try
            {
                _registros.Clear();
                string[] linhas = File.ReadAllLines(arquivo);

                for (int i = 1; i < linhas.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(linhas[i])) continue;

                    Registro registro = Registro.DeLinhaCsv(linhas[i]);
                    if (registro != null)
                    {
                        _registros.Add(registro);
                    }
                }
                Console.WriteLine($"\nDiário carregado com sucesso a partir de: {arquivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao carregar o arquivo: {ex.Message}");
            }
        }
    }

    // =========================================================================
    // CLASSE PRINCIPAL: Program
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Diario diario = new Diario();
            GeradorDePerguntas geradorDePerguntas = new GeradorDePerguntas();
            bool executando = true;

            Console.WriteLine("Bem-vindo ao Programa de Diário Pessoal!");

            while (executando)
            {
                Console.WriteLine("\nPor favor, escolha uma das seguintes opções:");
                Console.WriteLine("1. Escrever um novo registro");
                Console.WriteLine("2. Exibir o diário");
                Console.WriteLine("3. Carregar o diário a partir de um arquivo");
                Console.WriteLine("4. Salvar o diário em um arquivo");
                Console.WriteLine("5. Sair");
                Console.Write("O que você gostaria de fazer? ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        string pergunta = geradorDePerguntas.ObterPerguntaAleatoria();
                        Console.WriteLine($"\nPergunta: {pergunta}");
                        Console.Write("> ");
                        string resposta = Console.ReadLine();

                        Console.Write("Qual o seu humor/sentimento de hoje? (ex: Feliz, Produtivo, Cansado): ");
                        string humor = Console.ReadLine();

                        Registro novoRegistro = new Registro(pergunta, resposta, humor);
                        diario.AdicionarRegistro(novoRegistro);
                        Console.WriteLine("Registro adicionado com sucesso!");
                        break;

                    case "2":
                        diario.ExibirTodos();
                        break;

                    case "3":
                        Console.Write("Qual é o nome do arquivo a carregar? (ex: diario.csv): ");
                        string nomeCarregar = Console.ReadLine();
                        diario.CarregarDoArquivo(nomeCarregar);
                        break;

                    case "4":
                        Console.Write("Qual é o nome do arquivo para salvar? (ex: diario.csv): ");
                        string nomeSalvar = Console.ReadLine();

                        if (!nomeSalvar.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                        {
                            nomeSalvar += ".csv";
                        }

                        diario.SalvarNoArquivo(nomeSalvar);
                        break;

                    case "5":
                        executando = false;
                        Console.WriteLine("\nObrigado por usar o diário. Até logo!");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}