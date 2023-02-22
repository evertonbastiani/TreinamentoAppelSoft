
using Cuso.Application.Client.Classes;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Curso.Application
{
    internal class Program
    {
        const string urlBaseTipoVeiculo = "https://localhost:44348/TipoVeiculo/";
        static void Main(string[] args)
        {          
            Menu();

        }

        private static void Menu()
        {
            do
            {
                Console.WriteLine("Selecione a opção desejada");
                Console.WriteLine();

                Console.WriteLine("VEÍCULOS");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Cadastrar");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("4 - Buscar");
                Console.WriteLine("5 - Excluir");
                Console.WriteLine();

                Console.WriteLine("TIPOS DE VEÍCULO");
                Console.WriteLine("6 - Listar");
                Console.WriteLine("7 - Cadastrar");
                Console.WriteLine("8 - Atualizar");
                Console.WriteLine("9 - Excluir");

                Console.WriteLine("10- Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                var opcaoSelecionada = Console.ReadLine();
                switch (opcaoSelecionada)
                {
                    case "1":
                        {
                           // ListarVeiculos();
                            break;
                        }
                    case "2":
                        {
                            //CadastrarVeiculo();
                            //Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                           // AtualizarVeiculo();
                            break;
                        }
                    case "4":
                        {
                           // BuscarVeiculo();
                         //   Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                           // ExcluirVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            ListarTiposVeiculos();
                            //Console.ReadLine();
                            break;
                        }
                    case "7":
                        {
                            CadastrarTipoVeiculo();
                           Console.ReadLine();
                            break;
                        }
                    case "8":
                        {
                           // AtualizarTipoVeiculo();
                            break;
                        }
                    case "9":
                        {
                           // ExcluirTipoVeiculo();
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


        //private static void ExcluirVeiculo()
        //{
        //    try
        //    {
        //        Console.Write("Informe o código do veículo: ");
        //        var codigo = Convert.ToInt64(Console.ReadLine());

        //        var veiculo = BuscarVeiculo(codigo);
        //        if (veiculo != null && veiculo.Id > 0)
        //        {
        //            Console.WriteLine($"Tem certeza que deseja excluir o veículo {veiculo.Marca} {veiculo.Modelo} ? S/N: ");

        //            var opcao = Console.ReadLine().ToUpper();
        //            if (opcao == "S")
        //            {
        //                bool excluido = _veiculoService.Delete(veiculo.Id);
        //                if (excluido)
        //                {
        //                    Console.WriteLine("Veículo excluído com sucesso");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Operação cancelada");
        //            }

        //        }
        //        else
        //        {
        //            Console.WriteLine("Veículo não encontrado.");
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Error: {erro.Message}");
        //    }

        //}

        //private static void AtualizarVeiculo()
        //{
        //    try
        //    {
        //        Console.Write("Informe o código do veículo: ");
        //        var codigo = Convert.ToInt64(Console.ReadLine());
        //        var veiculo = BuscarVeiculo(codigo);
        //        if (veiculo != null && veiculo.Id > 0)
        //        {
        //            Console.Write("Placa: ");
        //            veiculo.Placa = Console.ReadLine();

        //            Console.Write("Marca: ");
        //            veiculo.Marca = Console.ReadLine();

        //            Console.Write("Modelo: ");
        //            veiculo.Modelo = Console.ReadLine();

        //            Console.Write("Cor: ");
        //            veiculo.Cor = Console.ReadLine();

        //            Console.Write("Ano: ");
        //            veiculo.Ano = Convert.ToInt16(Console.ReadLine());

        //            Console.WriteLine();
        //            Console.WriteLine("Selecione o tipo:");
        //            ListarTiposVeiculos();


        //            Console.Write("Tipo: ");
        //            var idTipo = Convert.ToInt64(Console.ReadLine());
        //            TipoVeiculoDTO tipoVeiculoDTO = BuscarTipoVeiculo(idTipo);
        //            veiculo.Tipo = tipoVeiculoDTO;

        //            veiculo = _veiculoService.Update(veiculo);
        //            if (veiculo.Id > 0)
        //            {
        //                Console.WriteLine($"Veículo atualizado com sucesso. {veiculo.Id} - {veiculo.Marca} {veiculo.Modelo}");
        //            }

        //        }
        //        else
        //        {
        //            Console.WriteLine("Veículo não encontrado.");
        //        }

        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Error: {erro.Message}");
        //    }

        //}

        //private static void CadastrarVeiculo()
        //{
        //    try
        //    {
        //        Console.WriteLine("CADASTRO DE VEÍCULO");
        //        VeiculoDTO veiculo = new VeiculoDTO();

        //        Console.Write("Placa: ");
        //        veiculo.Placa = Console.ReadLine();

        //        Console.Write("Marca: ");
        //        veiculo.Marca = Console.ReadLine();

        //        Console.Write("Modelo: ");
        //        veiculo.Modelo = Console.ReadLine();

        //        Console.Write("Cor: ");
        //        veiculo.Cor = Console.ReadLine();

        //        Console.Write("Ano: ");
        //        veiculo.Ano = Convert.ToInt16(Console.ReadLine());

        //        Console.WriteLine();
        //        Console.WriteLine("Selecione o tipo:");
        //        ListarTiposVeiculos();

        //        Console.WriteLine("Tipo: ");
        //        var idTipo = Convert.ToInt64(Console.ReadLine());
        //        veiculo.Tipo = BuscarTipoVeiculo(idTipo);

        //        veiculo = _veiculoService.Insert(veiculo);
        //        if (veiculo.Id > 0)
        //        {
        //            Console.WriteLine($"Veículo cadastrado com sucesso. {veiculo.Id} - {veiculo.Marca} {veiculo.Modelo}");
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Erro: {erro.Message}");
        //    }
        //}

        //private static void ListarVeiculos()
        //{
        //    try
        //    {
        //        List<VeiculoDTO> listVeiculoDto = _veiculoService.List();
        //        if (listVeiculoDto.Count == 0)
        //        {
        //            Console.WriteLine("Ainda não foi cadastrado nenhum veículo.");
        //        }
        //        foreach (var veiculo in listVeiculoDto)
        //        {
        //            Console.WriteLine("----------------------------------------------");
        //            Console.WriteLine($"Id: {veiculo.Id}");
        //            Console.WriteLine($"{veiculo.Marca} {veiculo.Modelo}");
        //            Console.WriteLine($"Placa: {veiculo.Placa}");
        //            Console.WriteLine($"Ano: {veiculo.Ano}");
        //            Console.WriteLine($"Cor: {veiculo.Cor}");
        //            Console.WriteLine($"Tipo: {veiculo.Tipo.Descricao}");
        //        }
        //        Console.ReadLine();
        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Erro: {erro.Message}");
        //    }
        //}

        //private static void BuscarVeiculo()
        //{
        //    try
        //    {
        //        Console.Write("Informe o código veiculo: ");
        //        var codigo = Convert.ToInt64(Console.ReadLine());
        //        var veiculo = BuscarVeiculo(codigo);

        //        if (veiculo != null && veiculo.Id == codigo)
        //        {
        //            Console.WriteLine($"Id: {veiculo.Id}");
        //            Console.WriteLine($"{veiculo.Marca} {veiculo.Modelo}");
        //            Console.WriteLine($"Placa: {veiculo.Placa}");
        //            Console.WriteLine($"Ano: {veiculo.Ano}");
        //            Console.WriteLine($"Cor: {veiculo.Cor}");
        //            Console.WriteLine($"Tipo: {veiculo.Tipo.Descricao}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Veículo não encontrado.");
        //        }

        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Erro: {erro.Message}");
        //    }
        //}

        //private static VeiculoDTO BuscarVeiculo(long Id)
        //{
        //    return _veiculoService.Get(Id);
        //}

        //private static void ExcluirTipoVeiculo()
        //{
        //    try
        //    {
        //        Console.Write("Informe o código do tipo: ");
        //        var codigoTipo = Convert.ToInt64(Console.ReadLine());

        //        var tipoExcluir = BuscarTipoVeiculo(codigoTipo);
        //        if (tipoExcluir != null && tipoExcluir.Id > 0)
        //        {
        //            Console.WriteLine($"Tem certeza que deseja excluir o tipo {tipoExcluir.Descricao} ? S/N: ");

        //            var opcao = Console.ReadLine().ToUpper();
        //            if (opcao == "S")
        //            {
        //                bool excluido = _serviceTipoVeiculo.Delete(tipoExcluir.Id);
        //                if (excluido)
        //                {
        //                    Console.WriteLine("Tipo excluído com sucesso");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Não foi possível realizar a operação");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Operação cancelada");
        //            }

        //        }
        //        else
        //        {
        //            Console.WriteLine("Tipo não encontrado.");
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Erro: {erro.Message}");
        //    }


        //}

        //private static TipoVeiculoDTO BuscarTipoVeiculo(long codigoTipo)
        //{
        //    return _serviceTipoVeiculo.Get(codigoTipo);
        //}

        //private static void AtualizarTipoVeiculo()
        //{
        //    try
        //    {
        //        Console.Write("Informe o código do tipo: ");
        //        var codigoTipo = Convert.ToInt64(Console.ReadLine());

        //        var tipoAtualizar = BuscarTipoVeiculo(codigoTipo);
        //        Console.WriteLine("Dados do tipo atual");
        //        Console.WriteLine($"Id: {tipoAtualizar.Id}");
        //        Console.WriteLine($"Descrição: {tipoAtualizar.Descricao}");
        //        Console.WriteLine("--------------------------------------");

        //        Console.WriteLine("Dados para atualizar");
        //        Console.Write("Descrição: ");
        //        tipoAtualizar.Descricao = Console.ReadLine();
        //        tipoAtualizar = _serviceTipoVeiculo.Update(tipoAtualizar);

        //        Console.WriteLine("--------------------------------------");
        //        Console.WriteLine("Dados atualizadosl");
        //        Console.WriteLine($"Id: {tipoAtualizar.Id}");
        //        Console.WriteLine($"Descrição: {tipoAtualizar.Descricao}");
        //    }
        //    catch (Exception erro)
        //    {
        //        Console.WriteLine($"Erro: {erro.Message}");
        //    }

        //}

        private static async void CadastrarTipoVeiculo()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var tipo = new TipoProdutoClient
                    {
                        Id=0,
                        Descricao="Jeep"
                    };

                    var json = JsonConvert.SerializeObject(tipo);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8);
                    var result = await client.PostAsync($"{urlBaseTipoVeiculo}Insert", stringContent);
                 }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        static async void ListarTiposVeiculos()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetStringAsync($"{urlBaseTipoVeiculo}List");
                    var  list = JsonConvert.DeserializeObject<List<TipoProdutoClient>>(result);
                    foreach (var tipoVeiculo in list)
                    {
                        Console.WriteLine("--------------------------------------");

                        Console.WriteLine($"Id: {tipoVeiculo.Id}");
                        Console.WriteLine($"Desrição: {tipoVeiculo.Descricao}");
                    }


                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Error: {erro.Message}");
            }


        }


    }
}