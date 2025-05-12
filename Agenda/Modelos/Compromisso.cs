using System;

namespace Agenda.Models;

public class Compromisso
{
    public DateOnly Data { get; set; }
    public TimeOnly Hora { get; set; }
    public required string Descricao { get; set; }
    public Local? Local { get; set; }
    public List<Participante> Participantes = new();
    private List<Anotacao> _anotacoes = new();
    public IReadOnlyCollection<Anotacao> Anotacoes => _anotacoes.AsReadOnly();
    public void AdicionarParticipante(Participante participante){
        if(!Participantes.Contains(participante)){
            Participantes.Add(participante);
            participante.Compromissos.Add(this);
        }
    }
    public void AdicionarAnotacao(string texto){
        _anotacoes.Add(new Anotacao(texto));
    }
    protected bool DataEhValida(DateOnly data){
        if(data>=DateOnly.FromDateTime(DateTime.Now))
            return true;
        else
            return false;
    }
     protected bool HoraEhValida(TimeOnly hora){
        if(hora>TimeOnly.FromDateTime(DateTime.Now))
            return true;
        else
            return false;  
    }

    public Compromisso(DateOnly data, TimeOnly hora, string descricao )
    {
        if(DataEhValida(data)){
            Data = data;
        }
        else
        {
            throw new Exception("Data inválida. Insira uma data futura.");
        }
        if(HoraEhValida(hora)){
            Hora = hora;
        }
        else
        {
            throw new Exception("Hora inválida. Insira uma hora futura.");
        }

        Descricao = descricao;
    }
     public Compromisso(DateOnly data, TimeOnly hora, string descricao, Local local, string anotacao)
    {
        if(DataEhValida(data)){
            Data = data;
        }
        else
        {
            throw new Exception("Data inválida. Insira uma data futura.");
        }
        if(HoraEhValida(hora)){
            Hora = hora;
        }
        else
        {
            throw new Exception("Hora inválida. Insira uma hora futura.");
        }
        Descricao = descricao;
        Local = local;
        AdicionarAnotacao(anotacao);
    }
}
