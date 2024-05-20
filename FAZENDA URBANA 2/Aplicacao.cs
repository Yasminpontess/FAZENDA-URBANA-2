using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAZENDA_URBANA_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //lembra só, vc pode criar um switch case para entrar no cliente ou no estoque
            //chamada do metodo de menus do cliente
            cadastroCliente();
        }

        static void cadastroCliente()
        {
            //aqui toma a decisao de listar ou inserir um cliente
            while (true)
            {
                Console.WriteLine("Aplicacao Crud");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        string nome;
                        int idade;
                        string email;
                        string cpf;
                        string bairro;
                        string celular;

                        while (true)
                        {
                            Console.Write("Digite o nome do cliente: ");
                            nome = Console.ReadLine();

                            Console.Write("Digite a idade do cliente: ");
                            idade = Convert.ToInt32(Console.ReadLine());
                            if (idade >= 18)
                                break;
                            Console.WriteLine("Idade inválida. O cliente deve ter 18 anos ou mais.\n");
                        }

                        Console.Write("Digite o email do cliente: ");
                        email = Console.ReadLine();

                        Console.Write("Digite o CPF do cliente: ");
                        cpf = Console.ReadLine();

                        Console.Write("Digite o bairro do cliente: ");
                        bairro = Console.ReadLine();

                        Console.Write("Digite o celular do cliente: ");
                        celular = Console.ReadLine();

                        String mensagem = adicionarCliente(nome, idade, email, cpf, bairro, celular);
                        Console.WriteLine(mensagem);
                        break;

                    case 2:
                        listarClientes();
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static string adicionarCliente(string nome, int idade, string email, string cpf, string bairro, string celular)
        {
            Cliente cliente = new Cliente(nome, idade, email, cpf, bairro, celular);
            return cliente.InserirCliente();
        }

        static void listarClientes()
        {
            Cliente cli = new Cliente("", 1, "", "", "", "");
            SqlDataReader teste = cli.consultarClientes();
            while (teste.Read())
            {
                string columnValue = Convert.ToString(teste["nome_cliente"]);
                Console.WriteLine(columnValue);
            }
        }
    }
}
