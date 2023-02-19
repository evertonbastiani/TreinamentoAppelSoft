using Interfaces.Classes;
using Interfaces.Contracts;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IFrete frete = new Frete();
            var valor1 =  frete.CalcularFrete(150);
            var valor2 = frete.CalcularFrete(150, 3.2M);

            Console.WriteLine($"Valor frete1: {valor1}");
            Console.WriteLine($"Valor frete2: {valor2}");

            Console.ReadLine();

           
        }
    }
}