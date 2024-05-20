using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAZENDA_URBANA_2
{
    public class Cliente
    {
        public string mensagem;
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Bairro { get; set; }
        public string Celular { get; set; }

        public Cliente(string nome, int idade, string email, string cpf, string bairro, string celular)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            CPF = cpf;
            Bairro = bairro;
            Celular = celular;
        }

        public string InserirCliente()
        {
            //conexao com banco de dados
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LSNVKAE\MSSQLSERVER01;Initial Catalog=BDGerenciadorDeFuncionarios;Integrated Security=True;Trust Server Certificate=True");
            con.Open();
            //criando a transacao que vai executar a insercao
            using (SqlTransaction sqlTran = con.BeginTransaction())
            {
                //criando a string do comando sql
                string sql = "INSERT INTO TBCLIENTES(nome_cliente, idade, email, cpf, bairro, celular) VALUES (@Nome, @Idade, @Email, @CPF, @Bairro, @Celular)";
                //criando o objeto que vai executar o sql, informando para ele qual eh o comando sql (sql), qual o objeto de conexao (con) e qual o objeto de transacao (sqlTran)
                SqlCommand comando = new SqlCommand(sql, con, sqlTran);

                //trocando as conts do comando sql pelas variaveis
                comando.Parameters.AddWithValue("@Nome", Nome);
                comando.Parameters.AddWithValue("@Idade", Idade);
                comando.Parameters.AddWithValue("@Email", Email);
                comando.Parameters.AddWithValue("@CPF", CPF);
                comando.Parameters.AddWithValue("@Bairro", Bairro);
                comando.Parameters.AddWithValue("@Celular", Celular);

                try
                {
                    comando.ExecuteNonQuery();
                    sqlTran.Commit();
                    return "Cadastro realizado com sucesso!";
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    return "Erro ao cadastrar: " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public SqlDataReader consultarClientes()
        {
            //conexao com banco de dados
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LSNVKAE\MSSQLSERVER01;Initial Catalog=BDGerenciadorDeFuncionarios;Integrated Security=True;Trust Server Certificate=True");

            try
            {
                //verificacao se o banco de dados está aberto, se nao estiver será conectado/aberto
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    //conectando/abrindo banco de dados
                    con.Open();
                    //criacao do objeto que executará o código sql
                    SqlCommand comando = new SqlCommand("Select * from TBCLIENTES", con);
                    //invocando a execucao do codigo sql
                    return comando.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao consultar: " + ex.Message;
                return null;
            }
            return null;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}, Email: {Email}, CPF: {CPF}, Bairro: {Bairro}, Celular: {Celular}";
        }
    }
}
