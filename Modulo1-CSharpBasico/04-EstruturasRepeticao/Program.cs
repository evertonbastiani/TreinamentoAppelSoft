namespace EstruturasRepeticao
{
    internal class Program
    {
        //arrays
        static int[] arrayNumeros = { 1, 3, 5, 6 };
        static string[] arrayNomes = { "Alex", "Ana", "Pedro" };

        //listas
        static List<int> listNumeros = new List<int>();
        static List<string> listNomes = new List<string>();

        static void Main(string[] args)
        {

            EstruturasComArray();
            EstruturaComListas();
            Console.ReadLine();
        }

        static void EstruturaComListas()
        {
            //Inicialização das listas
            listNumeros.Add(1);
            listNumeros.Add(3);      
            listNumeros.Add(5); 
            listNumeros.Add(6);

            listNomes.Add("Alex");
            listNomes.Add("Ana");
            listNomes.Add("Pedro");

            //Estrutura For...
            Console.WriteLine("Estrutura For");
            for (int i = 0; i < listNumeros.Count; i++)
            {
                Console.WriteLine(listNumeros[i]);
            }

            for (int i = 0; i < listNomes.Count; i++)
            {
                Console.WriteLine(listNomes[i]);
            }

            //Estrutura ForEach...
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

            //Estrutura Do While
            Console.WriteLine();
            Console.WriteLine("Estrutura Do While");
            Console.Write("Informe o nome.");
            var condicaoParada = "Ana";

            do
            {
                Console.Write("Informe o nome: ");
                condicaoParada = Console.ReadLine();
                Console.WriteLine($"Condição de parada = Ana. Nome informado = {condicaoParada}");

            } while (condicaoParada != "Ana");


        }

        static void EstruturasComArray()
        {
            //Estrutura For...
            Console.WriteLine("Estrutura For");
            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                Console.WriteLine(arrayNumeros[i]);
            }

            for (int i = 0; i < arrayNomes.Length; i++)
            {
                Console.WriteLine(arrayNomes[i]);
            }

            //Estrutura ForEach...
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

            //Estrutura Do While
            Console.WriteLine();
            Console.WriteLine("Estrutura Do While");
            Console.Write("Informe o nome.");
            var condicaoParada = "Ana";

            do
            {
                Console.Write("Informe o nome: ");
                condicaoParada = Console.ReadLine();
                Console.WriteLine($"Condição de parada = Ana. Nome informado = {condicaoParada}");

            } while (condicaoParada != "Ana");


            //Estrutura_For();
            //Estrutura_ForEach();
            //Estrutura_DoWhile();
        }

        //static void Estrutura_For()
        //{
        //    Console.WriteLine("Estrutura For");
        //    for (int i = 0; i < arrayNumeros.Length; i++)
        //    {
        //        Console.WriteLine(arrayNumeros[i]);
        //    }

        //    for (int i = 0; i < arrayNomes.Length; i++)
        //    {
        //        Console.WriteLine(arrayNomes[i]);
        //    }
        //}

        //static void Estrutura_ForEach()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("Estrutura ForEach");
        //    foreach (var numero in arrayNumeros)
        //    {
        //        Console.WriteLine(numero);
        //    }

        //    foreach (var nome in arrayNomes)
        //    {
        //        Console.WriteLine(nome);
        //    }
        //}

        //static void Estrutura_DoWhile()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("Estrutura Do While");
        //    Console.Write("Informe o nome.");
        //    var nome = "Ana";

        //    do
        //    {
        //        Console.Write("Informe o nome: ");
        //        nome = Console.ReadLine();
        //        Console.WriteLine($"Condição de parada = Ana. Nome informado = {nome}");

        //    } while (nome != "Ana");
        //}

    }
}
