namespace TratamentoExcecoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Vamos dividir.");
                Console.Write("Valor a: ");
                var a = Convert.ToDecimal( Console.ReadLine());
                Console.Write("Valor b: ");
                var b = Convert.ToDecimal( Console.ReadLine());

                var result = Dividir(a,b);

                Console.WriteLine($"Resuldado da divisão {result}");
            }
            catch (DivideByZeroException erroDivisao)
            {
                Console.WriteLine($"{erroDivisao.Message} Divisão por zero não permitido.");
            }
            catch (Exception erro)
            {

                Console.WriteLine(erro.Message);
            }
           
            Console.ReadLine();

           
        }

        static decimal Dividir(decimal  a, decimal b)
        {
            return a/b;
        }


    }
}