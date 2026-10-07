public abstract class Forma
{
    private string _cor;

    public Forma(string cor)
    {
        _cor = cor;
    }

    public string ObterCor()
    {
        return _cor;
    }

    public virtual double GetArea()
    {
        return 0;
    }

    public abstract double ObterArea();
}