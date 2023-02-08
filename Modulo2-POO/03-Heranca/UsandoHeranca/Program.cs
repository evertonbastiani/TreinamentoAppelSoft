using LibFrotaCerta.Classes;

namespace UsandoHeranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Veiculo veiculo = new Veiculo(TipoTransporte.Carro);
            veiculo.Marca = "Honda";
            veiculo.Modelo = "Civic";
            veiculo.Cor = "Branco";
            veiculo.Combustivel = "Gasolina";
            veiculo.Ano = 2023;

            veiculo.ShowMe();          
            veiculo.Mover();

            Console.WriteLine("-----------------------------------");

            veiculo = new Veiculo(TipoTransporte.Aviao);
            veiculo.Marca = "Boing";
            veiculo.Modelo = "737-200";
            veiculo.Cor = "Azul";
            veiculo.Combustivel = "Blue jet";
            veiculo.Ano = 2000;

            veiculo.ShowMe();
            veiculo.Mover();

            Console.WriteLine("-----------------------------------");

            veiculo = new Veiculo(TipoTransporte.Motocicletas);
            veiculo.Marca = "Harley Davidson";
            veiculo.Modelo = "Fat Boy";
            veiculo.Cor = "Preta";
            veiculo.Combustivel = "Gasolina";
            veiculo.Ano = 2000;

            veiculo.ShowMe();
            veiculo.Mover();

            Console.WriteLine("-----------------------------------");

            veiculo = new Veiculo(TipoTransporte.Onibus);
            veiculo.Marca = "Mercedez";
            veiculo.Modelo = "Bus Travel";
            veiculo.Cor = "Azul";
            veiculo.Combustivel = "Diesel";
            veiculo.Ano = 2000;

            veiculo.ShowMe();
            veiculo.Mover();


            Console.ReadLine();
        }
    }
}