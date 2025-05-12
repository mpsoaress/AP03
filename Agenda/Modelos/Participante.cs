using System;

namespace Agenda.Models;

public class Participante
{
    public required string Nome { get; set; }
    public List<Compromisso> Compromissos { get; set; } = new();
    public void AdicionarCompromisso(Compromisso compromisso){
        if(!Compromissos.Contains(compromisso)){
            Compromissos.Add(compromisso);
            compromisso.AdicionarParticipante(this);
        }
    }
    public Participante(string nome)
    {
        Nome = nome;
    }
    
}
