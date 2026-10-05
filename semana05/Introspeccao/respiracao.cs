using System;

namespace Introspeccao
{
    public class Respiracao
    {
        private  Atividade _atividade;

        public Respiracao()
        {
            _atividade = new Atividade(
                "Respiração Guiada",
                "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente.");
        }

        public void Executar()
        {
            _atividade.ExibirMensagemInicial();

            DateTime horaInicial = DateTime.Now;
            DateTime horaFinal = horaInicial.AddSeconds(_atividade.Duracao);

            while (DateTime.Now < horaFinal)
            {
                Console.Write("\nInspire... ");
                _atividade.ExibirContagemRegressiva(4);

                Console.Write("Expire... ");
                _atividade.ExibirContagemRegressiva(6);
            }

            _atividade.ExibirMensagemFinal();
        }
    }
}