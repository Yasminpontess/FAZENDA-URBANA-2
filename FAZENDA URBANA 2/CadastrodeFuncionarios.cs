using System;
using System.Collections.Generic;

public class Funcionarios
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string ID { get; set; }
    public string Celular { get; set; }

    public Funcionarios(string nome, string email, string id, string celular)
    {
        Nome = nome;
        Email = email;
        ID = id;
        Celular = celular;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Email: {Email}, ID: {ID}, Celular: {Celular}";
    }
}

public class GerenciadorDeFuncionarios
{
    private List<Funcionarios> Funcionarios;

    public GerenciadorDeFuncionarios()
    {
        Funcionarios = new List<Funcionarios>();
    }

    public void AdicionaFuncionarios(string nome, string email, string id, string celular)
    {
        Funcionarios Funcionarios = new Funcionarios(nome, email, id, celular);
       // Funcionarios.(Funcionarios);
        Console.WriteLine("Cadastro realizado com sucesso!\n");

    }

    
    class Program
    {
        static void cadastrar ()
        {
            GerenciadorDeFuncionarios gerenciador = new GerenciadorDeFuncionarios();

            while (true)
            {
                Console.WriteLine("1. Adicionar Funcionarios");
                Console.WriteLine("2. Sair");


                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        string nome;
                        string email;
                        string id;
                        string celular;

                        Console.Write("Digite o nome do Funcionarios: ");
                        nome = Console.ReadLine();

                        Console.Write("Digite o email do Funcionarios: ");
                        email = Console.ReadLine();

                        Console.Write("Digite o CNPJ do Funcionarios: ");
                        id = Console.ReadLine();

                        Console.Write("Digite o celular do Funcionarios: ");
                        celular = Console.ReadLine();

                        gerenciador.AdicionarFuncionarios(nome, email, id, celular);
                        break;

                    case 2:
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }

    private void AdicionarFuncionarios(string? nome, string? email, string? id, string? celular)
    {
        throw new NotImplementedException();
    }
}
