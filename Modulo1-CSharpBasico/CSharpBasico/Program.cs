public class Program
{
    //Todo programa possui o método main.
    static void Main(string[] args)
    {
        string origem = "Porto Alegre";
        string destino = "São Paulo";
        int duracao = 2;

        Console.WriteLine("O caminhão vai partir de " + origem + " para " + destino + " com duração de " + duracao + " dias.");

        //Interpolação de strings
        //Console.WriteLine($"O caminhão vai partir de {Origem} para {Destino} com duração de {duracao} dias.");
        Console.ReadLine();
    }
}

