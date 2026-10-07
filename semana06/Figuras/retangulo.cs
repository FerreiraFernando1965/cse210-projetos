public class Retangulo : Forma
{
    private double _altura;
    private double _largura;

    public Retangulo(string cor, double altura, double largura) : base(cor)
    {
        _altura = altura;
        _largura = largura;
    }

    public override double ObterArea()
    {
        return _altura * _largura;
    }
}