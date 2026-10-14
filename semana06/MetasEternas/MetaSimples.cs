public class MetaSimples : Meta
{
    private bool _estaConcluida;

    public MetaSimples(string nome, string descricao, int pontos, bool estaConcluida = false) : base(nome, descricao, pontos)
    {
        _estaConcluida = estaConcluida;
    }

    public override int RegistrarEvento()
    {
        if (!_estaConcluida)
        {
            _estaConcluida = true;
            return _pontos;
        }
        return 0;
    }

    public override bool EstaConcluido()
    {
        return _estaConcluida;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        string status = _estaConcluida ? "[X]" : "[ ]";
        return $"{status} {_nome} ({_descricao})";
    }

    public override string ObterStringSalvamento()
    {
        return $"MetaSimples|{_nome}|{_descricao}|{_pontos}|{_estaConcluida}";
    }
}