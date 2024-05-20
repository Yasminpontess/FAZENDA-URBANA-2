using System;
using System.Collections.Generic;
public class Estoque
{
    private int tomateEmQuilos;
    private int alfaceEmQuilos;

    public Estoque(int tomate, int alface)
    {
        tomateEmQuilos = tomate;
        alfaceEmQuilos = alface;
    }

    public void ConsultarEstoque()
    {
        Console.WriteLine("Quantidade em estoque:\n");

        Console.WriteLine($"Tomate: {tomateEmQuilos} quilos");

        Console.WriteLine($"Alface: {alfaceEmQuilos} quilos\n");
    }

    public void AdicionarQuantidade(string produto, int quantidade)
    {
        switch (produto.ToLower())
        {
            case "tomate":
                tomateEmQuilos += quantidade;
                Console.WriteLine($"{quantidade} quilos de tomate adicionados ao estoque.\n");
                break;
            case "alface":
                alfaceEmQuilos += quantidade;
                Console.WriteLine($"{quantidade} quilos de alface adicionados ao estoque.\n");
                break;
            default:
                Console.WriteLine("Produto não encontrado.");
                break;
        }
    }

    public void RetirarQuantidade(string produto, int quantidade)
    {
        switch (produto.ToLower())
        {
            case "tomate":
                if (quantidade <= tomateEmQuilos)
                {
                    tomateEmQuilos -= quantidade;
                    Console.WriteLine($"{quantidade} quilos de tomate retirados do estoque.\n");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente de tomate em estoque.\n");
                }
                break;
            case "alface":
                if (quantidade <= alfaceEmQuilos)
                {
                    alfaceEmQuilos -= quantidade;
                    Console.WriteLine($"{quantidade} quilos de alface retirados do estoque.\n");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente de alface em estoque.\n");
                }
                break;
            default:
                Console.WriteLine("Produto não encontrado.");
                break;
        }
    }

    public void VenderProduto(string produto, int quantidade)
    {
        switch (produto.ToLower())
        {
            case "tomate":
                if (quantidade <= tomateEmQuilos)
                {
                    tomateEmQuilos -= quantidade;
                    Console.WriteLine($"{quantidade} quilos de tomate vendidos.\n");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente de tomate em estoque.\n");
                }
                break;
            case "alface":
                if (quantidade <= alfaceEmQuilos)
                {
                    alfaceEmQuilos -= quantidade;
                    Console.WriteLine($"{quantidade} quilos de alface vendidos.\n");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente de alface em estoque.\n");
                }
                break;
            default:
                Console.WriteLine("Produto não encontrado.");
                break;
        }
    }
}

//class Program
//{
    //static void Main()
    //{
    //    Estoque estoque = new Estoque(5000, 3000);

    //    while (true)
    //    {
    //        Console.WriteLine("1. Consultar Estoque\n");
    //        Console.WriteLine("2. Adicionar Quantidade\n");
    //        Console.WriteLine("3. Retirar Quantidade\n");
    //        Console.WriteLine("4. Vender Produto\n");
    //        Console.WriteLine("5. Sair\n");
    //        Console.Write("Escolha uma opção:\n ");

    //        int opcao = Convert.ToInt32(Console.ReadLine());

    //        switch (opcao)
    //        {
    //            case 1:
    //                estoque.ConsultarEstoque();
    //                break;
    //            case 2:
    //                Console.Write("Digite o produto (tomate ou alface): ");
    //                string produtoAdicionar = Console.ReadLine();
    //                Console.Write("Digite a quantidade a ser adicionada em quilos: ");
    //                int quantidadeAdicionar = Convert.ToInt32(Console.ReadLine());
    //                estoque.AdicionarQuantidade(produtoAdicionar, quantidadeAdicionar);
    //                break;
    //            case 3:
    //                Console.Write("Digite o produto (tomate ou alface): ");
    //                string produtoRetirar = Console.ReadLine();
    //                Console.Write("Digite a quantidade a ser retirada em quilos: ");
    //                int quantidadeRetirar = Convert.ToInt32(Console.ReadLine());
    //                estoque.RetirarQuantidade(produtoRetirar, quantidadeRetirar);
    //                break;
    //            case 4:
    //                Console.Write("Digite o produto (tomate ou alface): ");
    //                string produtoVender = Console.ReadLine();
    //                Console.Write("Digite a quantidade a ser vendida em quilos: ");
    //                int quantidadeVender = Convert.ToInt32(Console.ReadLine());
    //                estoque.VenderProduto(produtoVender, quantidadeVender);
    //                break;
    //            case 5:
    //                return;
    //            default:
    //                Console.WriteLine("Opção inválida!");
    //                break;
    //        }
    //    }
    //}
//}
