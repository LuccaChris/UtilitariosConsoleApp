using System;
using System.Collections.Generic;
using System.Linq;
using testeconsole.models;


class Program
{
    
    static void Main()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Par ou Ímpar");
            Console.WriteLine("2 - Login Simples");
            Console.WriteLine("3 - Fatorial");
            Console.WriteLine("4 - CRUD de Produtos");
            Console.WriteLine("5 - Cadastro de Alunos com Média");
            Console.WriteLine("6 - Calculadora com Switch");
            Console.Write("Digite a opção desejada: ");

            int escolha = int.Parse(Console.ReadLine());
            
            switch (escolha)
            {
                case 1:
//------------- Par ou Ímpar
                    Console.WriteLine("Par ou Ímpar");
                    Console.Write("Digite um número: ");
                    int numero = int.Parse(Console.ReadLine());
                    Console.WriteLine(numero % 2 == 0 ? "Par" : "Ímpar");
                    break;
//------------- Login Simples
                case 2:
                    Console.WriteLine("Login Simples");
                    string usuario = "admin", senha = "1234";
                    Console.Write("Usuário: ");
                    string inputUsuario = Console.ReadLine();
                    Console.Write("Senha: ");
                    string inputSenha = Console.ReadLine();
                    Console.WriteLine(inputUsuario == usuario && inputSenha == senha
                        ? "Login bem-sucedido!"
                        : "Usuário ou senha incorretos.");
                    break;
//------------- Fatorial
                case 3:
                    Console.WriteLine("Fatorial");
                    Console.Write("Digite um número: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Fatorial de {n} é {Fatorial(n)}");
                    break;
//------------- CRUD de Produtos
                case 4:
    Console.WriteLine("CRUD de Produtos");

    var produtos = new List<Produtos>
    {
        new Produtos { Id = 1, Nome = "Teclado Gamer", Preco = 199.90 },
        new Produtos { Id = 2, Nome = "Mouse",         Preco =  59.90 },
        new Produtos { Id = 3, Nome = "Teclado",       Preco = 129.99 }
    };

    bool continuarCrud = true;
    while (continuarCrud)
    {
        Console.WriteLine("\nEscolha uma opção:");
        Console.WriteLine("1 - Listar produtos");
        Console.WriteLine("2 - Cadastrar produto");
        Console.WriteLine("3 - Alterar produto");
        Console.WriteLine("4 - Remover produto");
        Console.WriteLine("0 - Sair");

        Console.Write("Opção: ");
        int escolhaCrud = int.Parse(Console.ReadLine());

        switch (escolhaCrud)
        {
            case 1:
                Console.WriteLine("\nProdutos cadastrados:");
                foreach (var p in produtos)
                    Console.WriteLine($"{p.Id} - {p.Nome} - R${p.Preco}");
                break;

            case 2:
                Console.Write("\nQuantos produtos deseja cadastrar? ");
                int totalProdutos = int.Parse(Console.ReadLine());
                for (int i = 0; i < totalProdutos; i++)
                {
                    Console.Write("\nDigite nome do novo produto: ");
                    string nomeNovo = Console.ReadLine();
                    Console.Write("Digite o preço: ");
                    double precoNovo = double.Parse(Console.ReadLine());
                    int novoId = produtos.Max(p => p.Id) + 1;
                    produtos.Add(new Produtos { Id = novoId, Nome = nomeNovo, Preco = precoNovo });
                }
                break;

            case 3:
                Console.Write("\nDigite o ID do produto a ser alterado: ");
                int idAlterar = int.Parse(Console.ReadLine());
                var prodAlt = produtos.FirstOrDefault(p => p.Id == idAlterar);
                if (prodAlt != null)
                {
                    Console.Write("Novo nome: ");
                    prodAlt.Nome = Console.ReadLine();
                    Console.Write("Novo preço: ");
                    prodAlt.Preco = double.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
                break;

            case 4:
                Console.Write("\nDigite o ID do produto a ser removido: ");
                int idRemover = int.Parse(Console.ReadLine());
                produtos.RemoveAll(p => p.Id == idRemover);
                Console.WriteLine("Produto removido.");
                break;

            case 0:
                continuarCrud = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    break;
//------------- Cadastro de Alunos com Média
                case 5:
                    Console.WriteLine("Cadastro de Alunos com média");
                    List<Aluno> alunos = new List<Aluno>();
                    Console.Write("\nQuantos alunos deseja cadastrar? ");
                    int totalAlunos = int.Parse(Console.ReadLine());

                    for (int i = 0; i < totalAlunos; i++)
                    {
                        Console.Write("Nome do aluno: ");
                        string nome = Console.ReadLine();

                        double n1, n2;
                        do {
                            Console.Write("Nota 1 (0 a 10): ");
                            n1 = double.Parse(Console.ReadLine());
                        } while (n1 < 0 || n1 > 10);

                        do {
                            Console.Write("Nota 2 (0 a 10): ");
                            n2 = double.Parse(Console.ReadLine());
                        } while (n2 < 0 || n2 > 10);

                        alunos.Add(new Aluno { Nome = nome, Nota1 = n1, Nota2 = n2 });
                    }

                    foreach (var aluno in alunos)
                    {
                        double media = (aluno.Nota1 + aluno.Nota2) / 2;
                        string situacao = media >= 6 ? "Aprovado" : "Reprovado";
                        Console.WriteLine($"Aluno: {aluno.Nome}, Média: {media}, Situação: {situacao}");
                    }
                    break;
//------------- Calculadora com Switch
            case 6:
    bool continuarCalculadora = true;
    while (continuarCalculadora)
    {
        Console.WriteLine("Calculadora com Switch");
        Console.Write("\nDigite o primeiro número: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Digite a operação (+ - * /): ");
        char op = char.Parse(Console.ReadLine());
        Console.Write("Digite o segundo número: ");
        double b = double.Parse(Console.ReadLine());

        switch (op)
        {
            case '+': Console.WriteLine($"Resultado: {a + b}"); break;
            case '-': Console.WriteLine($"Resultado: {a - b}"); break;
            case '*': Console.WriteLine($"Resultado: {a * b}"); break;
            case '/':
                if (b != 0)
                    Console.WriteLine($"Resultado: {a / b}");
                else
                    Console.WriteLine("Erro: divisão por zero.");
                break;
            default:
                Console.WriteLine("Operação inválida");
                break;
        }

        Console.Write("\nDeseja fazer outra operação? (s/n): ");
        string resposta = Console.ReadLine().ToLower();
        if (resposta != "s")
            continuarCalculadora = false;
    }
    break;

            }
        }

        static int Fatorial(int n)
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
                resultado *= i;
            return resultado;
        }
    }