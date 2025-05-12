using System.Data.Common;
using Agenda.Models;

namespace Agenda;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite seu nome: ");
        string nomeUsuario = Console.ReadLine();

        List<Compromisso> compromissos = new List<Compromisso>();
        int opcao;
        
        do
        {
            Console.Clear();
            Console.WriteLine($"Olá, {nomeUsuario}!");
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1 - Registrar novo compromisso");
            Console.WriteLine("2 - Listar compromissos");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("Insira uma data (dd/mm/aaaa): ");
                    var dataLida = Console.ReadLine();
                    DateOnly data;
                    if(!DateOnly.TryParse(dataLida, out data)){
                        Console.WriteLine("Data inválida");
                        break;
                    }
                    Console.Write("Insira um horario (hh:mm): ");
                    var horaLida = Console.ReadLine();
                    TimeOnly hora;
                    if(!TimeOnly.TryParse(horaLida, out hora)){
                        Console.WriteLine("Horário inválido");
                        break; 
                    }
                    Console.Write("Insira um nome para o compromisso: ");
                    string descricao = Console.ReadLine();
                    Compromisso novo = new Compromisso(data, hora, descricao);
                    compromissos.Add(novo);
                    Console.WriteLine("Compromisso registrado com sucesso!");
                    break;

                case 2:
                    if (compromissos.Count == 0)
                    {
                        Console.WriteLine("Nenhum compromisso registrado.");
                    }
                    else
                    {
                        foreach (var c in compromissos)
                        {
                            Console.WriteLine($"- {c.Data}: {c.Hora}: {c.Descricao} em {c.Local}");
                            Console.WriteLine($"  Participantes: {string.Join(", ", c.Participantes)}");
                            Console.WriteLine($"  Anotações: {c.Anotacoes}");
                        }
                    }
                    break;

                case 0:
                    Console.WriteLine("Encerrando o programa.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();

        } while (opcao != 0);

    }
}
