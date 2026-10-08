using System;

namespace Introspeccao
{
    public class Respiracao : Atividade
    {
        public Respiracao() : base("Respiração Guiada", "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente.")
        {
        }

        public void Executar()
        {
            ExibirMensagemInicial();

            DateTime horaInicial = DateTime.Now;
            DateTime horaFinal = horaInicial.AddSeconds(Duracao);

            while (DateTime.Now < horaFinal)
            {
                Console.Write("\nInspire... ");
                ExibirContagemRegressiva(4);

                Console.Write("Expire... ");
                ExibirContagemRegressiva(6);
            }

            ExibirMensagemFinal();
        }
    }
}