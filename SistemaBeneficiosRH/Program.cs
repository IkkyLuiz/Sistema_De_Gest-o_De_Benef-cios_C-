using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Funcionario> funcionarios = new List<Funcionario>();
    static int proximoId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("== Sistema de Gestão de Benefícios ==");
            Console.WriteLine("1. Cadastrar funcionário");
            Console.WriteLine("2. Atribuir benefício");
            Console.WriteLine("3. Listar funcionários");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CadastrarFuncionario(); break;
                case "2": AtribuirBeneficio(); break;
                case "3": ListarFuncionarios(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida!"); break;
            }

            Console.WriteLine();
        }
    }

    static void CadastrarFuncionario()
    {
        Console.Write("Digite o nome do funcionário: ");
        string nome = Console.ReadLine();
        funcionarios.Add(new Funcionario { Nome = nome, Id = proximoId++ });
        Console.WriteLine("Funcionário cadastrado com sucesso!");
    }

    static void AtribuirBeneficio()
    {
        Console.Write("ID do funcionário: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var funcionario = funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                Console.WriteLine("Funcionário não encontrado!");
                return;
            }

            Console.Write("Nome do benefício: ");
            string nomeBeneficio = Console.ReadLine();
            funcionario.Beneficios.Add(new Beneficio { Nome = nomeBeneficio });
            Console.WriteLine("Benefício atribuído com sucesso!");
        }
        else
        {
            Console.WriteLine("ID inválido!");
        }
    }

    static void ListarFuncionarios()
    {
        if (!funcionarios.Any())
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        foreach (var f in funcionarios)
        {
            Console.WriteLine($"ID: {f.Id}, Nome: {f.Nome}");
            Console.WriteLine("Benefícios:");
            if (f.Beneficios.Count == 0)
            {
                Console.WriteLine("Nenhum benefício atribuído.");
            }
            else
            {
                foreach (var b in f.Beneficios)
                {
                    Console.WriteLine($"- {b.Nome}");
                }
            }
            Console.WriteLine("-------------------------");
        }
    }
}