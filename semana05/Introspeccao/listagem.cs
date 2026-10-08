using System;
using System.Collections.Generic;

namespace Introspeccao
{
    public class Listagem : Atividade
    {
        private int _contador;
        private readonly List<string> _perguntas;

        public Listagem() : base("Atividade de Listagem", "Esta atividade ajudará na sua reflexão, listando o máximo de coisas em um período de tempo")
        {
            _contador = 0;
            _perguntas = new List<string>
            {
                "Quem são as pessoas que você aprecia?",
                "Quais são seus pontos fortes pessoais?",
                "Quem são as pessoas que você ajudou esta semana?",
                "Quando você sentiu o Espírito Santo neste mês?",
                "Quem são alguns dos seus heróis pessoais?"
            };
        }

        public void Executar()
        {
            ExibirMensagemInicial();

            ObterPerguntaAleatoria();

            Console.WriteLine("\nVocê pode começar a digitar em:");
            ExibirContagemRegressiva(5);

            List<string> itensDigitados = ObterListaDoUsuario();
            _contador = itensDigitados.Count;

            Console.WriteLine($"\nVocê listou {_contador} itens!");

            ExibirMensagemFinal();
        }

        public void ObterPerguntaAleatoria()
        {
            Random random = new Random();
            int index = random.Next(_perguntas.Count);
            Console.WriteLine("\nConsidere a seguinte indicação:");
            Console.WriteLine($"--- {_perguntas[index]} ---");
        }

        public List<string> ObterListaDoUsuario()
        {
            List<string> lista = new List<string>();
            DateTime horaInicial = DateTime.Now;
            DateTime horaFinal = horaInicial.AddSeconds(Duracao);

            while (DateTime.Now < horaFinal)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    lista.Add(item);
                }
            }

            return lista;
        }
    }
}