public class Program
{
    //Constructor
    static void Main(string[] args)
    {
        ExibirRota("Porto Alegre", "São Paulo", 2);
        ExibirRota("Porto Alegre", "São Paulo", 2, 150);

        Console.ReadLine();
    }

    //Método vazio, sem retorno.
    static void ExibirRota(string origem, string destino, int duracao)
    {
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias.");
    }

    //Exemplo de Sobrecarga (Overload). Vermos isto melhor quando iniciarmos o Módulo2: POO
    static void ExibirRota(string origem, string destino, int duracao, decimal distancia)
    {
        var valorFrete = calcularValorFrete(150);
        Console.WriteLine($"O caminhão vai partir de {origem} para {destino} com duração de {duracao} dias. Veja o valor do frete abaixo:");
        Console.WriteLine($"O valor do frete será {valorFrete} reais.");
    }

    //Método com retorno.
    static decimal calcularValorFrete(decimal distancia)
    {
        decimal valorKm = 120;
        return (distancia * valorKm);
    }
}