using System;
using System.Collections.Generic;

class Program
{
         

class Cliente
{
    private string _nome;
    private Endereco endereco;

    public Cliente(string nome, Endereco endereco)
    {
        _nome = nome;
        this.endereco = endereco;
    }

    public string GetNome() { return _nome; }
    public Endereco GetEndereco() { return endereco; }
    public bool MoraEUA() { return endereco.MoraEUA(); }
}
class Endereco
{
    private string _rua;
    private string _cidade;
    private string _estado;
    private string _país;

    public Endereco(string rua, string cidade, string estado, string país)
    {
        _rua = rua; 
        _cidade = cidade; 
        _estado = estado; 
        _país = país;
    }

    public bool MoraEUA()
    {
        return _país == "EUA" || _país == "USA";
    }

    public string EndCompleto()
    {
        return _rua + "\n" + _cidade + ", " + _estado + "\n" + _país;
    }
}


class Produto
{
    private string _nome;
    private int _id, _quantidade;
    private double _preco;

    public Produto(string nome, int id, double preco, int quantidade)
    {
        _nome = nome; 
        _id = id; _preco = preco;
        _quantidade = quantidade;
    }

    public string GetNome() { return _nome; }
    public int GetId() { return _id; }
    public int GetQuantidade() { return _quantidade; }
    public double GetPreco() { return _preco; }
    public double CalValorTotal() { return _preco * _quantidade; }
}

class Pedido
{
    private Cliente _cliente;
    private List<Produto> _produto;

    public Pedido(Cliente cliente, List<Produto> produto)
    {
        _cliente = cliente;
        _produto = produto;
    }

    public double CalcularCustoTotal()
    {
        double total = _cliente.MoraEUA() ? 5.0 : 35.0; // Frete base
        foreach (Produto p in _produto)
        {
            total += p.CalValorTotal();
        }
        return total;
    }
    public string EtiqEndereco()
    {
        return "ETIQUETA DE ENVIO:\n" + _cliente.GetNome() + "\n" + _cliente.GetEndereco().EndCompleto();
    }

    public string EtiqEmbalagem()
    {
        string texto = "ETIQUETA DE EMBALAGEM:\n";
        foreach (Produto p in _produto)
        {
            texto += "- ID: " + p.GetId() + " | " + p.GetNome() + " | $" + p.GetPreco().ToString("F2") + " (Qtd: " + p.GetQuantidade() + " | " + p.CalValorTotal().ToString("F2") + ")\n";
        }
        return texto;
    }

}
    public static void Main(string[] args)
    {
        Endereco end1 = new Endereco("123 Main St", "Salt Lake City", "UT", "EUA");
        Cliente cli1 = new Cliente("John das Couve", end1);
        List<Produto> prods1 = new List<Produto>
        {
            new Produto("betoneira", 101, 150.50, 2),
            new Produto("colher de pedreiro", 102, 5.00, 8)
        };
        Pedido ped1 = new Pedido(cli1, prods1);

        Console.WriteLine("--- PEDIDO 1 ---");
        Console.WriteLine(ped1.EtiqEndereco());
        Console.WriteLine(ped1.EtiqEmbalagem());
        Console.WriteLine("Total: $" + ped1.CalcularCustoTotal().ToString("F2") + "\n");

      
        Endereco end2 = new Endereco("Rua do Sobe e Desce, 171", "Campinas", "SP", "Brasil");
        Cliente cli2 = new Cliente("Clarisbino Pederneiras", end2);
        List<Produto> prods2 = new List<Produto>
        {
            new Produto("carrinho de mão", 201, 130.00, 1),
            new Produto("Cabo de enxada", 202, 8.50, 5)
        };
        Pedido ped2 = new Pedido(cli2, prods2);

        Console.WriteLine("--- PEDIDO 2 ---");
        Console.WriteLine(ped2.EtiqEndereco());
        Console.WriteLine(ped2.EtiqEmbalagem());
        Console.WriteLine("Total: $" + ped2.CalcularCustoTotal().ToString("F2"));
  

        Endereco end3 = new Endereco("Avenida da Esquina, 11", "Campos Elíseos", "Coimbra", "Portugal");
        Cliente cli3 = new Cliente("Cremildo de Jesus", end3);
        List<Produto> prods3 = new List<Produto>
        {
            new Produto("martelo de borracha", 201, 10.00, 4),
            new Produto("desempenadeira de aço", 202, 12.50, 5)
        };
        Pedido ped3 = new Pedido(cli3, prods3);

        Console.WriteLine("--- PEDIDO 3 ---");
        Console.WriteLine(ped3.EtiqEndereco());
        Console.WriteLine(ped3.EtiqEmbalagem());
        Console.WriteLine("Total: $" + ped3.CalcularCustoTotal().ToString("F2"));
    }
}