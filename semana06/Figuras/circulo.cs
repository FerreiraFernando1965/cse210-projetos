public class Circulo : Forma
{
    private double _raio;

    public Circulo(string cor, double raio) : base(cor)
    {
        _raio = raio;
    }

    public override double ObterArea()
    {
        return Math.PI * _raio * _raio;
    }
}