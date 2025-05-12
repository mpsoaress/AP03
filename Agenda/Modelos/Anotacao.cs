using System;

namespace Agenda.Models;

public class Anotacao
{
    public string? Texto { get; private set; }
    public DateTime DataDeCriacao { get; } = DateTime.Now;
    public Anotacao(string? texto)
    {
        Texto = texto;
    }
}
