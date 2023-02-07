namespace _04_EstruturasRepeticao
{
    internal class Program
    {
        //static int[] arrayNumeros = { 1, 3, 5, 6 };
        //static string[] arrayNomes = { "Alex", "Ana", "Pedro" };

        static List<int> listNumeros = new List<int>();
        static List<string> listNomes = new List<string>();

        static void Main(string[] args)
        {
            listNumeros.Add(1);
            listNumeros.Add(3);
            listNumeros.Add(5);
            listNumeros.Add(6);

           // listNumeros.AddRange(arrayNumeros);

            listNomes.Add("Alex");
            listNomes.Add("Ana");
            listNomes.Add("Pedro");

           
           // listNomes.AddRange(arrayNomes);

            Estrutura_For();
            Estrutura_ForEach();        
            Console.ReadLine();
        }

        static void Estrutura_For()
        {
            Console.WriteLine("Estrutura For");
            for (int i = 0; i < listNumeros.Count; i++)
            {
                Console.WriteLine(listNumeros[i]);
            }

            for (int i = 0; i < listNomes.Count; i++)
            {
                Console.WriteLine(listNomes[i]);
            }
        }

        static void Estrutura_ForEach()
        {
            Console.WriteLine();
            Console.WriteLine("Estrutura ForEach");
            foreach (var numero in listNumeros)
            {
                Console.WriteLine(numero);
            }

            foreach (var nome in listNomes)
            {
                Console.WriteLine(nome);
            }
        }

    }
}