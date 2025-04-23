using System;
using System.Collections.Generic;
using System.Linq;
namespace testeconsole.models;
class Program
{
    
    static void Main()
    {
        // 1. Par ou Ímpar
        Console.Write("Digite um número: ");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine(numero % 2 == 0 ? "Par" : "Ímpar");

        // 2. Login Simples
        string usuario = "admin", senha = "1234";
        Console.Write("Usuário: ");
        string inputUsuario = Console.ReadLine();
        Console.Write("Senha: ");
        string inputSenha = Console.ReadLine();
        if (inputUsuario == usuario && inputSenha == senha)
            Console.WriteLine("Login bem-sucedido!");
        else
            Console.WriteLine("Usuário ou senha incorretos.");

        // 3. Fatorial
        Console.Write("Digite um número para fatorial: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Fatorial de {n} é {Fatorial(n)}");

        // 4. CRUD de Produtos
        
       var produtos = new List<Produtos>
        {
            new Produtos { Id = 1, Nome = "Teclado Gamer", Preco = 199.90 },
            new Produtos { Id = 2, Nome = "Mouse",         Preco =  59.90 },
            new Produtos { Id = 3, Nome = "Teclado",       Preco = 129.99 }
        };

        Console.WriteLine("\nProdutos cadastrados:");
        foreach (var p in produtos)
            Console.WriteLine($"{p.Id} - {p.Nome} - R${p.Preco}");
        Console.Write("\n Quantos produtos deseja cadastrar? ");
        int totalProdutos = int.Parse(Console.ReadLine());
        for(int i = 0; i < totalProdutos; i++)
        {
           
        
        Console.Write("\nDigite nome do novo produto: ");
        string nomeNovo = Console.ReadLine();
        Console.Write("Digite o preço: ");
        double precoNovo = double.Parse(Console.ReadLine());
        int novoId = produtos.Max(p => p.Id) + 1;
        produtos.Add(new Produtos { Id = novoId, Nome = nomeNovo, Preco = precoNovo });
        }
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

        Console.Write("\nDigite o ID do produto a ser removido: ");
        int idRemover = int.Parse(Console.ReadLine());
        produtos.RemoveAll(p => p.Id == idRemover);

        Console.WriteLine("\nProdutos atualizados:");
        foreach (var p in produtos)
            Console.WriteLine($"{p.Id} - {p.Nome} - R${p.Preco}");

        // 5. Cadastro de Alunos com média
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
            Console.WriteLine($"Aluno: {aluno.Nome}, Média: {media}, Situação: {(media >= 6 ? "Aprovado" : "Reprovado")}");
        }

        // 6. Calculadora com Switch
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
            default: Console.WriteLine("Operação inválida"); break;
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


class Aluno
{
    public string Nome { get; set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }
}
