using System;

namespace Agenda.Models;

public class Usuario
{
    public required string Nome { get; set; }

    private List<Compromisso> _compromissos = new List<Compromisso>();
    public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

    public void AdicionarCompromisso(Compromisso compromisso){
        _compromissos.Add(compromisso);
    }
}
