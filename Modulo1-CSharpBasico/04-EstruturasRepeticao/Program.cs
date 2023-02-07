namespace _04_EstruturasRepeticao
{
    internal class Program
    {
        static int[] arrayNumeros = { 1, 3, 5, 6 };
        static string[] arrayNomes = { "Alex", "Ana", "Pedro" };

        static void Main(string[] args)
        {

            Estrutura_For();
            Estrutura_ForEach();
            Estrutura_DoWhile();
            Console.ReadLine();
        }

        static void Estrutura_For()
        {
            Console.WriteLine("Estrutura For");
            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                Console.WriteLine(arrayNumeros[i]);
            }

            for (int i = 0; i < arrayNomes.Length; i++)
            {
                Console.WriteLine(arrayNomes[i]);
            }
        }

        static void Estrutura_ForEach()
        {
            Console.WriteLine();
            Console.WriteLine("Estrutura ForEach");
            foreach (var numero in arrayNumeros)
            {
                Console.WriteLine(numero);
            }

            foreach (var nome in arrayNomes)
            {
                Console.WriteLine(nome);
            }
        }

        static void Estrutura_DoWhile()
        {
            Console.WriteLine();
            Console.WriteLine("Estrutura Do While");
            Console.Write("Informe o nome.");
            var nome = "Ana";

            do
            {
                Console.Write("Informe o nome: ");
                nome = Console.ReadLine();
                Console.WriteLine($"Condição de parada = Ana. Nome informado = {nome}");
              
            } while (nome != "Ana");
        }
    }
}