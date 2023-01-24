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
        var valorFrete = calcularValorFrete(150, TipoProduto.NaoPereciveis);
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias. Veja o valor do frete abaixo:");
        Console.WriteLine($"O valor do frete será {valorFrete} reais.");
    }

    static decimal calcularValorFrete(decimal distancia)
    {
        decimal valorKm = 120;
        return (distancia * valorKm);
    }

    static decimal calcularValorFrete(decimal distancia, TipoProduto tipoProduto)
    {
        decimal valorKm = 0;
        if (tipoProduto == TipoProduto.Combustiveis)
        {
            valorKm = 500;
        }
        if (tipoProduto == TipoProduto.Pereciveis)
        {
            valorKm = 100;
        }
        if (tipoProduto == TipoProduto.NaoPereciveis)
        {
            valorKm = 55.9M;
        }

        return (distancia * valorKm);
    }
}

public enum TipoProduto
{
    Combustiveis = 1,
    Pereciveis = 2,
    NaoPereciveis = 3
}