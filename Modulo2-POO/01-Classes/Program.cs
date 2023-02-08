namespace Classes
{
    internal class Program
    {
        static Frota frota = new Frota();
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            do
            {
                Console.WriteLine("Selecione a opção desejada");
                Console.WriteLine("1 - Adicionar veículo a Frota");
                Console.WriteLine("2 - Exibir Frota");
                Console.WriteLine("3 - Calcular Frete");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção: ");
                var opcaoSelecionada = Console.ReadLine();
                switch (opcaoSelecionada)
                {
                    case "1":
                        {
                            AdicionarVeiculoFrota();
                            break;
                        }
                    case "2":
                        {
                            ListarVeiculosFrota();
                            break;
                        }
                    case "3":
                        {
                            CalcularFrete();
                            break;
                        }
                    case "4":
                        {
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opção inválida");
                            break;
                        }
                       
                }


            } while (true);
        }

        private static void CalcularFrete()
        {
            Console.Write("Informe a distância (Km): ");
            var distancia = Convert.ToDecimal( Console.ReadLine());
            var valorFrete = Frete.CalcularFrete(distancia);
            Console.WriteLine($"O valor do frete é {valorFrete}");
            Console.ReadLine();

        }

        static void AdicionarVeiculoFrota()
        {
            Veiculo veiculo = new Veiculo();

            Console.WriteLine("Informe os dados do Veículo");
            Console.Write("Marca: ");
            veiculo.Marca = Console.ReadLine();

            Console.Write("Modelo: ");
            veiculo.Modelo = Console.ReadLine();

            Console.Write("Ano: ");
            veiculo.Ano = Convert.ToInt16(Console.ReadLine());

            Console.Write("Placa: ");
            veiculo.Placa = Console.ReadLine();

            Console.Write("Cor: ");
            veiculo.Cor = Console.ReadLine();          

            frota.Descricao = "Frota de veíulos leves";
            frota.AdicionarVeiculo(veiculo);
        }

        static void ListarVeiculosFrota()
        {          
            List<Veiculo> listVeiculos = frota.ListarVeiculos();
            Console.WriteLine("Frota de veículos:");
            foreach (var veiculo in listVeiculos)
            {

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Marca: {veiculo.Marca}");
                Console.WriteLine($"Modelo: {veiculo.Modelo}");
                Console.WriteLine($"Ano: {veiculo.Ano}");
                Console.WriteLine($"Placa: {veiculo.Placa}");
                Console.WriteLine($"Cor: {veiculo.Cor}");
                Console.WriteLine("-----------------------------------------");
               
            }

            Console.ReadLine();
        }
    }
}