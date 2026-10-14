public abstract class Meta
{
    protected string _nome;
    protected string _descricao;
    protected int _pontos;

    public Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public string Nome => _nome;
    public string Descricao => _descricao;
    public int Pontos => _pontos;

    public abstract int RegistrarEvento();
    public abstract bool EstaConcluido();
    public abstract string ObterRepresentacaoEmTexto();
    public abstract string ObterStringSalvamento();
}