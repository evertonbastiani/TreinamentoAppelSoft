 public class Program
{
    
    static void Main(string[] args)
    {       
        var sair = "s";
        do
        {
            Console.WriteLine("1 - Exibir Rota");
            Console.WriteLine("2 - Exibir Rota - Calcular Frete");
            Console.WriteLine("3 - Calcular Frete");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção desejada: ");

            var opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Console.Write("Informe a origem: ");
                var origem = Console.ReadLine();

                Console.Write("Informe o destino: ");
                var destino = Console.ReadLine();

                Console.Write("Informe o tempo de viagem (em dias): ");
                var duracao = Console.ReadLine();

                ExibirRota(origem, destino, Convert.ToInt32(duracao));
            }
            if (opcao == "2")
            {
                Console.Write("Informe a origem: ");
                var origem = Console.ReadLine();

                Console.Write("Informe o destino: ");
                var destino = Console.ReadLine();

                Console.Write("Informe o tempo de viagem (em dias): ");
                var duracao = Console.ReadLine();

                Console.Write("Informe a distância de viagem: ");
                var distancia = Console.ReadLine();

                ExibirRota(origem, destino, Convert.ToInt32( duracao), Convert.ToDecimal(distancia));

            }
            if (opcao == "3")
            {
                Console.Write("Informe a distância de viagem: ");
                var distancia = Console.ReadLine();

                Console.WriteLine("Informe o tipo de produto a ser transportado:");
                Console.WriteLine("1 - Combustíveis");
                Console.WriteLine("2 - Perecíveis");
                Console.WriteLine("3- Não Perecíveis");
                Console.Write("Tipo de Produto: ");

                var tipoProduto = Console.ReadLine();
                var valorFrente = calcularValorFrete(Convert.ToInt32(distancia), (TiposProdutos)Convert.ToInt32(tipoProduto));
                Console.WriteLine($"O valor do frete é: {valorFrente} reais");

              
            }
            if(opcao == "4")
            {
               Environment.Exit(0);
            }


        } while (sair == "s");
      
    }

    /// <summary>
    /// Exibe a rota da viagem
    /// </summary>
    /// <param name="origem">Origem da viagem</param>
    /// <param name="destino">Destino da viagem</param>
    /// <param name="duracao">Tempo de duração (dias)</param>
    static void ExibirRota(string origem, string destino, int duracao)
    {
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias.");
    }

    //Exemplo de Sobrecarga (Overload)
    /// <summary>
    /// Exibe a rota da viagem e calcula o frete.
    /// </summary>
    /// <param name="origem"></param>
    /// <param name="destino"></param>
    /// <param name="duracao"></param>
    /// <param name="distancia"></param>
    static void ExibirRota(string origem, string destino, int duracao, decimal distancia)
    {
        var valorFrete = calcularValorFrete(150, TiposProdutos.NaoPereciveis);
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias. Veja o valor do frete abaixo:");
        Console.WriteLine($"O valor do frete será {valorFrete} reais para o tipo de produto {TiposProdutos.NaoPereciveis}");
    }

    /// <summary>
    /// Calcula o frete
    /// </summary>
    /// <param name="distancia">Distância (Km)</param>
    /// <returns></returns>
    static decimal calcularValorFrete(decimal distancia)
    {
        decimal valorKm = 120;
        return (distancia * valorKm);
    }

    static decimal calcularValorFrete(decimal distancia, TiposProdutos tipoProduto)
    {
        decimal valorKm = 0;
        if (tipoProduto == TiposProdutos.Combustiveis)
        {
            valorKm = 500;
        }
        if (tipoProduto == TiposProdutos.Pereciveis)
        {
            valorKm = 100;
        }
        if (tipoProduto == TiposProdutos.NaoPereciveis)
        {
            valorKm = 55.9M;
        }

        return (distancia * valorKm);
    }
}