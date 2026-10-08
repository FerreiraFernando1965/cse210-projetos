using System;
using System.Collections.Generic;
using System.Threading;

namespace Introspeccao
{
    public class Atividade
    {
        private string _nome;
        private string _descricao;
        private int _duracao;

        public Atividade(string nome, string descricao)
        {
            _nome = nome;
            _descricao = descricao;
            _duracao = 0;
        }

        public Atividade(string descricao) : this("Atividade", descricao)
        {
        }

        public int Duracao => _duracao;

        public void ExibirMensagemInicial()
        {
            Console.WriteLine($"=== Bem-vindo à atividade: {_nome} ===");
            Console.WriteLine(_descricao);
            Console.WriteLine();
            Console.Write("Por favor, digite a duração da atividade em segundos: ");

            if (!int.TryParse(Console.ReadLine(), out _duracao) || _duracao <= 0)
            {
                _duracao = 30;
            }

            Console.WriteLine("\nPrepare-se para começar...");
            ExibirProgresso(3);
        }

        public void ExibirMensagemFinal()
        {
            Console.WriteLine(" Você concluiu a atividade.");
            Console.WriteLine($"Você completou {_duracao} segundos de {_nome}.");
            ExibirProgresso(3);
        }

        public void ExibirProgresso(int segundos)
        {
            List<string> animacao = new List<string> { "|", "/", "-", "\\" };
            DateTime horaInicial = DateTime.Now;
            DateTime horaFinal = horaInicial.AddSeconds(segundos);

            int i = 0;
            while (DateTime.Now < horaFinal)
            {
                string simbolo = animacao[i % animacao.Count];
                Console.Write(simbolo);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
            Console.WriteLine();
        }

        public void ExibirContagemRegressiva(int segundos)
        {
            for (int i = segundos; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}