// A classe Ciclismo herda de Atividade
public class Ciclismo : Atividade
{
    
    private double _velocidade;

    
    public Ciclismo(string data, int minutos, double velocidade) : base(data, minutos)
    {
        _velocidade = velocidade;
    }

    
    public override double ObterDistancia() => (_velocidade * ObterMinutos()) / 60;

    
    public override double ObterVelocidade() => _velocidade;

    
    public override double ObterRitmo() => 60 / _velocidade;
}