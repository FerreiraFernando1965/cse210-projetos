using System;

namespace Introspeccao
{
     public class Respiracao : Atividade   // o sinal : garante a herança entre as classes
    {
        public Respiracao() 
            : base(
                "Respiração Guiada", 
                "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração."
            )
        {
        }

        public void ExecutarRespiracao()
        {
            ExibirMensagemInicial();

            DateTime horaInicial = DateTime.Now;
            DateTime horaFinal = horaInicial.AddSeconds(_duracao);

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