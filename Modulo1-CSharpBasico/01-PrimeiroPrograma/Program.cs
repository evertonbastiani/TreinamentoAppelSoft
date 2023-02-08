public class Program
{
    //Todo programa possui o método main.
    static void Main(string[] args)
    {
        string origem = "Porto Alegre";
        string destino = "São Paulo";
        int distancia = 1130;

        Console.WriteLine("O caminhão vai partir de " + origem + " para " + destino + ". A distância até o destino é de " + distancia + " kilômetros.");

        //Interpolação de strings
        //Console.WriteLine($"O caminhão vai partir de {Origem} para {Destino} com duração de {duracao} dias.");
        Console.ReadLine();
    }
}

