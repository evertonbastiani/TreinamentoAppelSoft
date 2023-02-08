namespace _04_EstruturasRepeticaoListas_2
{
    internal class Program
    {
        private static List<string> listFrota = new List<string>();
        static void Main(string[] args)
        {
            AdicionarLista();
        }

        static void AdicionarLista()
        {
            var sair = "s";



            //do
            //{
            //    Console.WriteLine("1- Incluir veículo");
            //    Console.WriteLine("2- Listar veículos");
            //    Console.WriteLine("3- Sair");
            //    Console.Write("Informe a opção:");
            //    var opcao = Console.ReadLine();

                  //Instrução de seleção if
            //    if (opcao == "1")
            //    {
            //        Console.Write("Informe o veículo:");
            //        string veiculo = Console.ReadLine();
            //        listFrota.Add(veiculo);
            //    }
            //    if (opcao == "2")
            //    {
            //        Console.WriteLine("Lista dos veículos cadastrados:");
            //        foreach (var item in listFrota)
            //        {
            //            Console.WriteLine(item);
            //        }
            //        if(listFrota.Count == 0)
            //        {
            //            Console.WriteLine("Nenhum veículo foi cadastrado.");
            //        }
            //    }
            //    if (opcao == "3")
            //    {
            //        Environment.Exit(0);
            //    }
            //} while (sair == "s");



            do
            {
                Console.WriteLine("1- Incluir veículo");
                Console.WriteLine("2- Listar veículos");
                Console.WriteLine("3- Sair");
                Console.Write("Informe a opção:");
                var opcao = Console.ReadLine();

                //Instrução de seleção switch
                switch (opcao)
                {
                    case "1":
                        {

                            Console.Write("Informe o veículo:");
                            string veiculo = Console.ReadLine();
                            listFrota.Add(veiculo);

                            break;
                        }
                        case "2":
                        {
                            Console.WriteLine("Lista dos veículos cadastrados:");
                            foreach (var item in listFrota)
                            {
                                Console.WriteLine(item);
                            }
                            if (listFrota.Count == 0)
                            {
                                Console.WriteLine("Nenhum veículo foi cadastrado.");
                            }

                            break;
                        }
                        case "3":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
              
            } while (sair == "s");
        }
    }
}