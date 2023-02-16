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
			//Inicialização das Listas
			listNumeros.Add(1);
			listNumeros.Add(3);
			listNumeros.Add(5);
			listNumeros.Add(6);

			listNomes.Add("Alex");
			listNomes.Add("Ana");
			listNomes.Add("Pedro");

			Estrutura_For();
			Estrutura_ForEach();
			Estrutura_While();
			Estrutura_DoWhile();
			Console.ReadLine();
		}

		static void Estrutura_While()
		{
			Console.WriteLine("Estrutura While");
			int i = 0;
			while (arrayNomes.Length > i)
			{
				Console.WriteLine(arrayNomes[i]);
				i++;
			}

			i = 0;
			while (listNomes.Count > i)
			{
				Console.WriteLine(listNomes[i]);
				i++;
			}
		}

		static void Estrutura_For()
		{
			Console.WriteLine("Estrutura For com Arrays");
			for (int i = 0; i < arrayNumeros.Length; i++)
			{
				Console.WriteLine(arrayNumeros[i]);
			}

			for (int i = 0; i < arrayNomes.Length; i++)
			{
				Console.WriteLine(arrayNomes[i]);
			}

			Console.WriteLine();
			Console.WriteLine("Estrutura For com Listas");
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
			Console.WriteLine("Estrutura ForEach com Arrays");
			foreach (var numero in arrayNumeros)
			{
				Console.WriteLine(numero);
			}

			foreach (var nome in arrayNomes)
			{
				Console.WriteLine(nome);
			}

			Console.WriteLine();
			Console.WriteLine("Estrutura ForEach com Listas");
			foreach (var numero in listNumeros)
			{
				Console.WriteLine(numero);
			}

			foreach (var nome in listNomes)
			{
				Console.WriteLine(nome);
			}
		}

		static void Estrutura_DoWhile()
		{
			Console.WriteLine();
			Console.WriteLine("Estrutura Do While");
			var codicaoParada = "Pedro";
			int i = 0;
			do
			{
				Console.WriteLine(listNomes[i]);
				i++;

			} while (listNomes[i] != codicaoParada);
		}

	}
}
