using System;

namespace Agenda.Models;

public class Local
{
    public required string Nome { get; set; }    
    public int CapacidadeDePessoas { get; set; }
    public Local(string nome, int capacidade)
    {
        Nome = nome;
        CapacidadeDePessoas = capacidade;
    }
}
