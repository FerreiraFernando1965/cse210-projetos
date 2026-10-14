public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos) 
         : base(nome, descricao, pontos)
    {
    }

    public override int RegistrarEvento()
    {
        // Registra o progresso/hábito, mas nunca conclui definitivamente.
       return _pontos;
    }

    public override bool EstaConcluido()
    {
        return false; 
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"[∞] {_nome} ({_descricao})";
    }
    public override string ObterStringSalvamento()
    {
        return $"MetaEterna|{_nome}|{_descricao}|{_pontos}";
    }
}