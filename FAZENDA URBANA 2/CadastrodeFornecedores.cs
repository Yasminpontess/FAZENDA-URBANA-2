using System;
using System.Collections.Generic;


public class Fornecedor
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CNPJ { get; set; }
    public string Bairro { get; set; }
    public string Celular { get; set; }

    public Fornecedor(string nome, string email, string cnpj, string bairro, string celular)
    {
        Nome = nome;
        Email = email;
        CNPJ = cnpj;
        Bairro = bairro;
        Celular = celular;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Email: {Email}, CNPJ: {CNPJ}, Bairro: {Bairro}, Celular: {Celular}";
    }
}

public class GerenciadorDeFornecedores
{
    private List<Fornecedor> fornecedores;

    public GerenciadorDeFornecedores()
    {
        fornecedores = new List<Fornecedor>();
    }

    public void AdicionarFornecedor(string nome, string email, string cnpj, string bairro, string celular)
    {
        Fornecedor fornecedor = new Fornecedor(nome, email, cnpj, bairro, celular);
        fornecedores.Add(fornecedor);
        Console.WriteLine("Cadastro realizado com sucesso!\n");

    }






    class Program
    {
        static void cadastrodeFuncionarios()
        {
            GerenciadorDeFornecedores gerenciador = new GerenciadorDeFornecedores();

            while (true)
            {
                Console.WriteLine("1. Adicionar Fornecedor");
                Console.WriteLine("2. Sair");


                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        string nome;
                        string email;
                        string cnpj;
                        string bairro;
                        string celular;

                        Console.Write("Digite o nome do fornecedor: ");
                        nome = Console.ReadLine();

                        Console.Write("Digite o email do fornecedor: ");
                        email = Console.ReadLine();

                        Console.Write("Digite o CNPJ do fornecedor: ");
                        cnpj = Console.ReadLine();

                        Console.Write("Digite o bairro do fornecedor: ");
                        bairro = Console.ReadLine();

                        Console.Write("Digite o celular do fornecedor: ");
                        celular = Console.ReadLine();

                        gerenciador.AdicionarFornecedor(nome, email, cnpj, bairro, celular);
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
}