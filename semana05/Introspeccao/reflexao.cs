using System;
using System.Collections.Generic;

namespace Introspeccao
{
    public class Reflexao
    {
        private  Atividade _atividade;
        private  List<string> _reflexoes;
        private  List<string> _perguntas;

        public Reflexao()
        {
            _atividade = new Atividade(
                "Atividade de Reflexão",
                "Esta atividade ajudará você a refletir sobre momentos da sua vida e ajudará você a reconhecer o poder que você tem!"
            );
            _reflexoes = new List<string>
            {
                "Pense em uma ocasião em que você defendeu outra pessoa.",
                "Pense em uma ocasião em que você fez algo realmente difícil.",
                "Pense em uma ocasião em que você ajudou alguém necessitado.",
                "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
            };

            _perguntas = new List<string>
            {
                "Por que essa experiência foi significativa para você?",
                "Você já fez algo assim antes?",
                "Como você começou?",
                "Como você se sentiu quando terminou?",
                "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
                "Qual é a sua coisa favorita sobre essa experiência?",
                "O que você pode aprender com essa experiência que se aplica a outras situações?",
            };
        }

        public void Executar()
        {
            _atividade.ExibirMensagemInicial();

            ExibirReflexoes();

            Console.WriteLine("\nQuando tiver algo em mente, pressione Enter para continuar.");
            Console.ReadLine();

            Console.WriteLine("\nAgora reflita sobre cada uma das seguintes perguntas em relação a essa experiência:");
            _atividade.ExibirContagemRegressiva(5);
            Console.Clear();

            ExibirPerguntas();

            _atividade.ExibirMensagemFinal();
        }

        public string ObterReflexoesAleatorias()
        {
            Random random = new Random();
            int index = random.Next(_reflexoes.Count);
            return _reflexoes[index];
        }

        public string ObterPerguntasAleatorias()
        {
            Random random = new Random();
            int index = random.Next(_perguntas.Count);
            return _perguntas[index];
        }

        public void ExibirReflexoes()
        {
            Console.WriteLine("\nConsidere a seguinte indicação:");
            Console.WriteLine($"--- {ObterReflexoesAleatorias()} ---");
        }

        public void ExibirPerguntas()
        {
            DateTime horaInicial = DateTime.Now;
            DateTime horaFinal = horaInicial.AddSeconds(_atividade.Duracao);

            while (DateTime.Now < horaFinal)
            {
                Console.Write($"\n> {ObterPerguntasAleatorias()} ");
                _atividade.ExibirProgresso(5);
            }
        }
    }
}