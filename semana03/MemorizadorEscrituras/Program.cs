
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemorizadorDeEscrituras
{
    class Program
    {
        static void Main(string[] args)
        {
            Program2.Executar();
        }
    }

    class Program2
    {
        public static void Executar()
        {
            Referencia referencia = new Referencia("Provérbios", 3, 5, 6);
            string textoEscritura = "Confia no Senhor de todo o teu coração, e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas.";

            Escritura escritura = new Escritura(referencia, textoEscritura);

            Console.Clear();
            Console.WriteLine("=== MEMORIZADOR DE ESCRITURAS ===");
            Console.WriteLine("1. Modo Normal (Esconder palavras aos poucos)");
            Console.WriteLine("2. Modo Inverso (Start oculto e revelar palavras)");
            Console.Write("\nEscolha o modo (1 ou 2): ");
            string modoOpcao = Console.ReadLine()?.Trim();

            bool modoInverso = modoOpcao == "2";

            if (modoInverso)
            {
                escritura.OcultarTodasAsPalavras();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(escritura.ObterTextoFormatado());
                Console.WriteLine();

                if (modoInverso ? escritura.EstaCompletamenteVisivel() : escritura.EstaCompletamenteOculta())
                {
                    Console.WriteLine(modoInverso ? "Você revelou toda a escritura!" : "Todas as palavras foram escondidas!");
                    break;
                }

                string acaoTexto = modoInverso ? "revelar" : "esconder";
                Console.Write($"Pressione ENTER para {acaoTexto} palavras ou digite 'sair' para encerrar: ");
                string entrada = Console.ReadLine()?.Trim().ToLower();

                if (entrada == "sair")
                {
                    break;
                }

                if (modoInverso)
                {
                    escritura.RevelarPalavrasAleatorias(3);
                }
                else
                {
                    escritura.OcultarPalavrasAleatorias(3);
                }
            }
        }
    }

    public class Referencia
    {
        private string _livro;
        private int _capitulo;
        private int _versiculoInicial;
        private int _versiculoFinal;

        public Referencia(string livro, int capitulo, int versiculo)
        {
            _livro = livro;
            _capitulo = capitulo;
            _versiculoInicial = versiculo;
            _versiculoFinal = versiculo;
        }

        public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
        {
            _livro = livro;
            _capitulo = capitulo;
            _versiculoInicial = versiculoInicial;
            _versiculoFinal = versiculoFinal;
        }

        public string ObterTextoFormatado()
        {
            return _versiculoInicial == _versiculoFinal
                ? $"{_livro} {_capitulo}:{_versiculoInicial}"
                : $"{_livro} {_capitulo}:{_versiculoInicial}-{_versiculoFinal}";
        }
    }

    public class Palavra
    {
        private string _texto;
        private bool _estaOculta;

        public Palavra(string texto)
        {
            _texto = texto;
            _estaOculta = false;
        }

        public void Ocultar() => _estaOculta = true;
        public void Revelar() => _estaOculta = false;
        public bool EstaOculta() => _estaOculta;

        public string ObterTextoFormatado()
        {
            if (!_estaOculta) return _texto;

            char[] caracteresOcultos = new char[_texto.Length];
            for (int i = 0; i < _texto.Length; i++)
            {
                caracteresOcultos[i] = char.IsLetterOrDigit(_texto[i]) ? '_' : _texto[i];
            }

            return new string(caracteresOcultos);
        }
    }

    public class Escritura
    {
        private Referencia _referencia;
        private List<Palavra> _palavras;
        private Random _aleatorio;

        public Escritura(Referencia referencia, string texto)
        {
            _referencia = referencia;
            _palavras = new List<Palavra>();
            _aleatorio = new Random();

            string[] palavrasSeparadas = texto.Split(' ');
            foreach (string textoPalavra in palavrasSeparadas)
            {
                _palavras.Add(new Palavra(textoPalavra));
            }
        }

        public void OcultarTodasAsPalavras()
        {
            foreach (var palavra in _palavras)
            {
                palavra.Ocultar();
            }
        }

        public void OcultarPalavrasAleatorias(int quantidadeParaOcultar)
        {
            List<Palavra> palavrasVisiveis = _palavras.Where(p => !p.EstaOculta()).ToList();
            if (palavrasVisiveis.Count == 0) return;

            int quantidade = Math.Min(quantidadeParaOcultar, palavrasVisiveis.Count);
            for (int i = 0; i < quantidade; i++)
            {
                int indice = _aleatorio.Next(palavrasVisiveis.Count);
                palavrasVisiveis[indice].Ocultar();
                palavrasVisiveis.RemoveAt(indice);
            }
        }

        public void RevelarPalavrasAleatorias(int quantidadeParaRevelar)
        {
            List<Palavra> palavrasOcultas = _palavras.Where(p => p.EstaOculta()).ToList();
            if (palavrasOcultas.Count == 0) return;

            int quantidade = Math.Min(quantidadeParaRevelar, palavrasOcultas.Count);
            for (int i = 0; i < quantidade; i++)
            {
                int indice = _aleatorio.Next(palavrasOcultas.Count);
                palavrasOcultas[indice].Revelar();
                palavrasOcultas.RemoveAt(indice);
            }
        }

        public string ObterTextoFormatado()
        {
            string textoEscritura = string.Join(" ", _palavras.Select(p => p.ObterTextoFormatado()));
            return $"{_referencia.ObterTextoFormatado()} - \"{textoEscritura}\"";
        }

        public bool EstaCompletamenteOculta() => _palavras.All(p => p.EstaOculta());
        public bool EstaCompletamenteVisivel() => _palavras.All(p => !p.EstaOculta());
    }
}
