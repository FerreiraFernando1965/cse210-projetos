public class Quadrado : Forma
{
    private double _lado;

    public Quadrado(string cor, double lado) : base(cor)
    {
        _lado = lado;
    }

    public override double ObterArea()
    {
        return _lado * _lado;
    }
}