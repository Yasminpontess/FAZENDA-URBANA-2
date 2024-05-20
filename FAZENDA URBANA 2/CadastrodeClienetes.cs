using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Conexao;
using System.Runtime.Intrinsics.Arm;

namespace FAZENDA_URBANA_2
{
    public class Cliente2
    {
        private Conexao conexao;
        private SqlCommand cmd = new SqlCommand();
        public string mensagem;
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Bairro { get; set; }
        public string Celular { get; set; }

        public Cliente2(Conexao conexao, string nome, int idade, string email, string cpf, string bairro, string celular)
        {
            this.conexao = conexao;
            Nome = nome;
            Idade = idade;
            Email = email;
            CPF = cpf;
            Bairro = bairro;
            Celular = celular;
        }

        public void InserirCliente()
        {
            conexao.conectar();
            using (SqlTransaction sqlTran = conexao.transation())
            {
                cmd.CommandText = "INSERT INTO TBCLIENTES (nome_cliente, idade, email, cpf, bairro, celular) VALUES (@Nome, @Idade, @Email, @CPF, @Bairro, @Celular)";
                cmd.Transaction = sqlTran;

                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Idade", Idade);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Bairro", Bairro);
                cmd.Parameters.AddWithValue("@Celular", Celular);

                try
                {
                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();
                    mensagem = "Cadastro realizado com sucesso!";
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    mensagem = "Erro ao cadastrar: " + ex.Message;
                }
                finally
                {
                    conexao.desconectar();
                }
            }
        }

        public SqlDataReader consultarClientes()
        {
            //fazendo conexao
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LSNVKAE\MSSQLSERVER01;Initial Catalog=BDGerenciadorDeFuncionarios;Integrated Security=True;Trust Server Certificate=True");
            
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                    SqlCommand comando = new SqlCommand("Select * from TBCLIENTES", con);
                    return comando.ExecuteReader();
                }
            } catch (Exception ex)
            {
                mensagem = "Erro ao consultar: " + ex.Message;
                return null;
            }
            return null;
            //fim da conexao
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}, Email: {Email}, CPF: {CPF}, Bairro: {Bairro}, Celular: {Celular}";
        }
    }

    public class Conexao
    {
        private SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-LSNVKAE\MSSQLSERVER01;Initial Catalog=BDGerenciadorDeFuncionarios;Integrated Security=True;Trust Server Certificate=True";
        }

        public SqlConnection conectar()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-LSNVKAE\MSSQLSERVER01;Initial Catalog=BDGerenciadorDeFuncionarios;Integrated Security=True;Trust Server Certificate=True");
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                String mensagem = "Erro ao consultar: " + ex.Message;
                return null;
            }
            return con;
        }

        public SqlTransaction transation()
        {
            return con.BeginTransaction();
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    public class GerenciadorDeClientes
    {
        private List<Cliente2> clientes;

        public GerenciadorDeClientes()
        {
            clientes = new List<Cliente2>();
        }

        public void AdicionarCliente(string nome, int idade, string email, string cpf, string bairro, string celular)
        {
            Cliente2 cliente = new Cliente2(new Conexao(), nome, idade, email, cpf, bairro, celular);
            cliente.InserirCliente();
            clientes.Add(cliente);
            Console.WriteLine("Cadastro realizado com sucesso!\n");
        }

        public void ListarClientes()
        {
            Cliente2 cli = new Cliente2(new Conexao(), "", 1,"","","","");
            SqlDataReader teste = cli.consultarClientes();
            while (teste.Read()) {
                string columnValue = Convert.ToString(teste["nome_cliente"]);
                Console.WriteLine(columnValue);
                Console.WriteLine(teste.ToString());
            }
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        CadastroCliente2();
    //    }

    //    static void CadastroCliente2()
    //    {
    //        GerenciadorDeClientes gerenciador = new GerenciadorDeClientes();

    //        while (true)
    //        {
    //            Console.WriteLine("1. Adicionar Cliente");
    //            Console.WriteLine("2. Listar Clientes");
    //            Console.WriteLine("3. Sair");
    //            Console.Write("Escolha uma opção: ");

    //            int opcao = Convert.ToInt32(Console.ReadLine());

    //            switch (opcao)
    //            {
    //                case 1:
    //                    string nome;
    //                    int idade;
    //                    string email;
    //                    string cpf;
    //                    string bairro;
    //                    string celular;

    //                    while (true)
    //                    {
    //                        Console.Write("Digite o nome do cliente: ");
    //                        nome = Console.ReadLine();

    //                        Console.Write("Digite a idade do cliente: ");
    //                        idade = Convert.ToInt32(Console.ReadLine());
    //                        if (idade >= 18)
    //                            break;
    //                        Console.WriteLine("Idade inválida. O cliente deve ter 18 anos ou mais.\n");
    //                    }

    //                    Console.Write("Digite o email do cliente: ");
    //                    email = Console.ReadLine();

    //                    Console.Write("Digite o CPF do cliente: ");
    //                    cpf = Console.ReadLine();

    //                    Console.Write("Digite o bairro do cliente: ");
    //                    bairro = Console.ReadLine();

    //                    Console.Write("Digite o celular do cliente: ");
    //                    celular = Console.ReadLine();

    //                    gerenciador.AdicionarCliente(nome, idade, email, cpf, bairro, celular);
    //                    break;

    //                case 2:
    //                    gerenciador.ListarClientes();
    //                    break;

    //                case 3:
    //                    return;

    //                default:
    //                    Console.WriteLine("Opção inválida!");
    //                    break;
    //            }
    //        }
    //    }
    //}
}










//using System;
//using Microsoft.Data.SqlClient;

//namespace FAZENDA_URBANA_2
//{
//    public class Cliente
//    {
//        private Conexao conexao;
//        private SqlCommand cmd = new SqlCommand();
//        public string mensagem;
//        public string Nome { get; set; }
//        public int Idade { get; set; }
//        public string Email { get; set; }
//        public string CPF { get; set; }
//        public string Bairro { get; set; }
//        public string Celular { get; set; }

//        public Cliente(Conexao conexao, string nome, int idade, string email, string cpf, string bairro, string celular)
//        {
//            this.conexao = conexao;
//            Nome = nome;
//            Idade = idade;
//            Email = email;
//            CPF = cpf;
//            Bairro = bairro;
//            Celular = celular;
//        }

//        public void InserirCliente()
//        {
//            try
//            {
//                conexao.conectar();

//               // cmd.Connection = conexao.con1;

//                cmd.CommandText = "INSERT INTO Clientes (Nome, Idade, Email, CPF, Bairro, Celular) VALUES (@Nome, @Idade, @Email, @CPF, @Bairro, @Celular)";

//                cmd.Parameters.AddWithValue("@Nome", Nome);
//                cmd.Parameters.AddWithValue("@Idade", Idade);
//                cmd.Parameters.AddWithValue("@Email", Email);
//                cmd.Parameters.AddWithValue("@CPF", CPF);
//                cmd.Parameters.AddWithValue("@Bairro", Bairro);
//                cmd.Parameters.AddWithValue("@Celular", Celular);

//                cmd.ExecuteNonQuery();
//                mensagem = "Cadastro realizado com sucesso!";
//            }
//            catch (Exception ex)
//            {
//                mensagem = "Erro ao cadastrar: " + ex.Message;
//            }
//            finally
//            {
//                conexao.desconectar();
//            }
//        }
//    }

//    public class Conexao
//    {
//        private SqlConnection con = new SqlConnection();

//        public Conexao()
//        {
//            con.ConnectionString = @"Data Source=DESKTOP-LSNVKAE\MSSQLSERVER01;Initial Catalog=BDGerenciadorDeFuncionarios;Integrated Security=True;Trust Server Certificate=True";
//        }

//        public SqlConnection conectar()
//        {
//            if (con.State == System.Data.ConnectionState.Closed)
//            {
//                con.Open();
//            }
//            return con;
//        }

//        public void desconectar()
//        {
//            if (con.State == System.Data.ConnectionState.Open)
//            {
//                con.Close();
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Criar uma instância de Conexao
//            Conexao conexao = new Conexao();

//            // Passar a instância de Conexao para o construtor de Cliente
//            Cliente cliente = new Cliente(conexao, "João", 25, "joao@email.com", "123.456.789-00", "Centro", "9999-8888");
//            cliente.InserirCliente();
//            Console.WriteLine(cliente.mensagem);
//        }
//    }
//}


//executar comando
//desconectar
//mastrar mwnsagem de errp ou sucesso

//    public override string tostring()
//{
//    return $"nome: {nome}, idade: {idade}, email: {email}, cpf: {cpf}, bairro: {bairro}, celular: {celular}";
//}
//}

//public class gerenciadordeclientes
//{
//    private list<cliente> clientes;

//    public gerenciadordeclientes()
//    {
//        clientes = new list<cliente>();
//    }

//    public void adicionarcliente(string nome, int idade, string email, string cpf, string bairro, string celular)
//    {
//        cliente cliente = new cliente(nome, idade, email, cpf, bairro, celular);
//        clientes.add(cliente);
//        console.writeline("cadastro realizado com sucesso!\n");
//    }

//    public void listarclientes()
//    {
//        foreach (cliente cliente in clientes)
//        {
//            console.writeline(cliente);
//        }
//    }
//}

//class program
//{
//    static void cadastrocliente()
//    {
//        gerenciadordeclientes gerenciador = new gerenciadordeclientes();

//        while (true)
//        {
//            console.writeline("1. adicionar cliente");
//            console.writeline("2. listar clientes");
//            console.writeline("3. sair");
//            console.write("escolha uma opção: ");

//            int opcao = convert.toint32(console.readline());

//            switch (opcao)
//            {
//                case 1:
//                    string nome;
//                    int idade;
//                    string email;
//                    string cpf;
//                    string bairro;
//                    string celular;

//                    while (true)
//                    {
//                        console.write("digite o nome do cliente: ");
//                        nome = console.readline();

//                        console.write("digite a idade do cliente: ");
//                        idade = convert.toint32(console.readline());
//                        if (idade >= 18)
//                            break;
//                        console.writeline("idade inválida. o cliente deve ter 18 anos ou mais.\n");
//                    }

//                    console.write("digite o email do cliente: ");
//                    email = console.readline();

//                    console.write("digite o cpf do cliente: ");
//                    cpf = console.readline();

//                    console.write("digite o bairro do cliente: ");
//                    bairro = console.readline();

//                    console.write("digite o celular do cliente: ");
//                    celular = console.readline();

//                    gerenciador.adicionarcliente(nome, idade, email, cpf, bairro, celular);
//                    break;

//                case 2:
//                    gerenciador.listarclientes();
//                    break;

//                case 3:
//                    return;

//                default:
//                    console.writeline("opção inválida!");
//                    break;
//            }
//        }
//    }

