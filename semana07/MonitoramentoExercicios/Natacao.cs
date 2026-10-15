// A classe Natacao herda de Atividade
public class Natacao : Atividade
{
    
    private int _voltas;

   
    public Natacao(string data, int minutos, int voltas) : base(data, minutos)
    {
        _voltas = voltas;
    }

    
    public override double ObterDistancia() => (_voltas * 50.0) / 1000.0;

    
    public override double ObterVelocidade() => (ObterDistancia() / ObterMinutos()) * 60;

    
    public override double ObterRitmo() => ObterMinutos() / ObterDistancia();
}