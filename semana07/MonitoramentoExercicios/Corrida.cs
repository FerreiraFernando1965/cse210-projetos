// A classe Corrida herda de Atividade usando os dois pontos (:)
public class Corrida : Atividade
{
   
    private double _distancia;

    
    public Corrida(string data, int minutos, double distancia) : base(data, minutos)
    {
        _distancia = distancia;
    }

   
    public override double ObterDistancia() => _distancia;

    
    public override double ObterVelocidade() => (_distancia / ObterMinutos()) * 60;

    
    public override double ObterRitmo() => ObterMinutos() / _distancia;
}