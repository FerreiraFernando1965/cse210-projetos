using System;


public abstract class Atividade
{
    
    private string _data;
    private int _minutos;

    
    public Atividade(string data, int minutos)
    {
        _data = data;
        _minutos = minutos;
    }

    
    public string ObterData() => _data;
    public int ObterMinutos() => _minutos;

    
    public abstract double ObterDistancia();
    public abstract double ObterVelocidade();
    public abstract double ObterRitmo();

    
    public virtual string ObterResumo()
    {
        
        string tipoAtividade = this.GetType().Name;
        
        
        if (tipoAtividade == "Natacao") tipoAtividade = "Natação";

        
        double distancia = ObterDistancia();
        double velocidade = ObterVelocidade();
        double ritmo = ObterRitmo();

        
        return $"{ObterData()} {tipoAtividade} ({ObterMinutos()} min): " +
               $"Distância {distancia:F1} km, " +
               $"Velocidade: {velocidade:F1} km/h, " +
               $"Ritmo: {ritmo:F2} min por km";
    }
}