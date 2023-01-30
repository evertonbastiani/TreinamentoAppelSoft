public class Program
{
    private static List<string> listFrota = new List<string>();
    static void Main(string[] args)
    {
        AdicionarLista();
    }

    static void AdicionarLista()
    {
        var sair = "s";     

        do
        {
            Console.WriteLine("1- Incluir veículo");
            Console.WriteLine("2- Listar veículos");
            Console.WriteLine("3- Sair");
            Console.WriteLine("Informe a opção:...");
            var opcao = Console.ReadLine();

            if(opcao == "1")
            {
                Console.WriteLine("Informe o veículo:");
                string veiculo = Console.ReadLine();
                listFrota.Add(veiculo);
            }
            if(opcao == "2")
            {
                Console.WriteLine("Lista dos veículos cadastrados:");
                foreach (var item in listFrota)
                {
                    Console.WriteLine(item);
                }
            }
            if(opcao == "3")
            {
                Environment.Exit(0);
            }
        } while (sair == "s");
    }


}

