using CSharpBasico.Enumeradores;

public class Program
{
    //Constructor
    static void Main(string[] args)
    {
        ExibirRota("Porto Alegre", "São Paulo", 2);
        ExibirRota("Porto Alegre", "São Paulo", 2, 150);

        Console.ReadLine();
    }

    static void ExibirRota(string origem, string destino, int duracao)
    {
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias.");
    }

    //Exemplo de Sobrecarga (Overload)
    static void ExibirRota(string origem, string destino, int duracao, decimal distancia)
    {
        var valorFrete = calcularValorFrete(150, TiposProdutos.NaoPereciveis);
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias. Veja o valor do frete abaixo:");
        Console.WriteLine($"O valor do frete será {valorFrete} reais para o tipo de produto {TiposProdutos.NaoPereciveis}");
    }

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

