using Checkpoint2.Entidades.Enums;
using Checkpoint2.Entidades;

List<Produto> produtos = new List<Produto>();
List<Funcionario> funcionarios = new List<Funcionario>();
List<Pedido> pedidos = new List<Pedido>();

int opcao = 0;

do
{
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Cadastrar Funcionario");
    Console.WriteLine("3 - Efetuar Venda");
    Console.WriteLine("4 - Listar Produtos");
    Console.WriteLine("5 - Listar Funcionários");
    Console.WriteLine("6 - Listar Pedidos");
    Console.WriteLine("7 - Calcular Pagamento Funcionário");
    Console.WriteLine("8 - Sair");
    Console.Write("Opcao: ");

    opcao = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Cadastrar Produto");
            Produto produto = new Produto();

            Console.Write("Id: ");
            produto.Id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Valor: ");
            produto.Valor = double.Parse(Console.ReadLine());

            produtos.Add(produto);
            break;

        case 2:
            Console.WriteLine("Cadastrar Funcionário");
            Console.WriteLine("Qual é o tipo de funcionário? (V)endedor ou (G)erente");
            string tipo = Console.ReadLine();

            if(tipo == "V")
            {
                Vendedor vendedor = new Vendedor();

                Console.Write("Nome: ");
                vendedor.Nome = Console.ReadLine();

                Console.Write("Matrícula: ");
                vendedor.Matricula = Console.ReadLine();

                Console.Write("Salário: ");
                vendedor.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(vendedor);
            }
            else if (tipo == "G")
            {
                Gerente gerente = new Gerente();

                Console.Write("Nome: ");
                gerente.Nome = Console.ReadLine();

                Console.Write("Matrícula: ");
                gerente.Matricula = Console.ReadLine();

                Console.Write("Salário: ");
                gerente.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(gerente);
            }
            else
            {
                Console.WriteLine("Opção Inválida, digite (V) ou (G)");
            }
            
            break;



        case 3:
            Console.WriteLine("Efetuar Venda");
            Pedido pedido = new Pedido();

            Console.Write("Matricula do Funcionario: ");
            string matriculaFuncionario = Console.ReadLine();

            pedido.Funcionario = funcionarios.Find(funcionario => funcionario.Matricula == matriculaFuncionario);

            Console.WriteLine("informe quantos itens irão compor a venda");
            int qtdProduto = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdProduto; i++)
            {
                ItemPedido item = new ItemPedido();

                Console.WriteLine($"Id do produto {i + 1}: ");
                int idProduto = int.Parse(Console.ReadLine());

                item.Produto = produtos.Find(produto => produto.Id == idProduto);
                item.Valor = item.Produto.Valor;

                Console.WriteLine($"Quantidade do Produto {i + 1}: ");
                item.Quantidade = int.Parse(Console.ReadLine());

                item.SubTotal();
                pedido.AdicionarItem(item);
            }

            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Processando;

            pedidos.Add(pedido);

            break;

        case 4:
            Console.WriteLine("Listar Produtos");

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto);
            });

            break;

        case 5:
            Console.WriteLine("Listar Funcionários");

            funcionarios.ForEach(funcionario =>
            {
                Console.WriteLine(funcionario);
            });

            break;

        case 6:
            Console.WriteLine("Listar Pedidos");

            pedidos.ForEach(pedido =>
            {
                Console.WriteLine(pedido);
            });

            break;

        case 7:
            Console.WriteLine("Calcular Pagamento Funcionários");

            Console.WriteLine("Digite a matricula do funcionario");
            string resposta = Console.ReadLine();

            Funcionario funcionario = funcionarios.Find(func => func.Matricula == resposta);

            Console.WriteLine(funcionario.CalcularPagamento(pedidos));
            break;
    }

    Console.ReadKey();
    Console.Clear();

} while (opcao != 8);