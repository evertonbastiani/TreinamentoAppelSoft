using Curso.Domain.DTO;
using Curso.Repository.Repository;
using Curso.Service.Interfaces;
using Curso.Service.Services;

namespace Curso.Application
{
    internal class Program
    {
        private static VeiculoRepository _veiculoRepository;
        private static TipoVeiculoRepository _tipoVeiculoRepository;
        private static IServiceVeiculo _veiculoService;
        private static IServiceTipoVeiculo _serviceTipoVeiculo;
        static void Main(string[] args)
        {
            InjectDependencies();

            do
            {
                Console.WriteLine("Selecione a opção desejada");

                Console.WriteLine("VEÍCULOS");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Cadastrar");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("4 - Buscar");
                Console.WriteLine("5 - Excluir");

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
                            ListarVeiculos();
                            break;
                        }
                    case "2":
                        {
                            CadastrarVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            AtualizarVeiculo();
                            break;
                        }
                    case "4":
                        {
                            BuscarVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            ExcluirVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            ListarTiposVeiculos();
                            Console.ReadLine();
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
                            AtualizarTipoVeiculo();
                            break;
                        }
                    case "9":
                        {
                            ExcluirTipoVeiculo();
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

        private static void InjectDependencies()
        {
            _tipoVeiculoRepository = new TipoVeiculoRepository();
            _veiculoRepository = new VeiculoRepository(_tipoVeiculoRepository);
            
            _veiculoService = new ServiceVeiculo(_veiculoRepository);
            _serviceTipoVeiculo = new ServiceTipoVeiculo(_tipoVeiculoRepository);
        }

        private static void ExcluirVeiculo()
        {
            Console.Write("Informe o código do veículo: ");
            var codigo = Convert.ToInt64(Console.ReadLine());

            var veiculo = BuscarVeiculo(codigo);
            if (veiculo != null && veiculo.Id > 0)
            {
                Console.WriteLine($"Tem certeza que deseja excluir o veículo {veiculo.Marca} {veiculo.Modelo} ? S/N: ");

                var opcao = Console.ReadLine().ToUpper();
                if (opcao == "S")
                {
                    bool excluido =  _veiculoService.Delete(veiculo.Id);
                    if (excluido)
                    {
                        Console.WriteLine("Veículo excluído com sucesso");
                    }
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }

            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        private static void AtualizarVeiculo()
        {
            throw new NotImplementedException();
        }

        private static void CadastrarVeiculo()
        {
            Console.WriteLine("CADASTRO DE VEÍCULO");
            VeiculoDTO veiculo = new VeiculoDTO();

            Console.Write("Placa: ");
            veiculo.Placa = Console.ReadLine();

            Console.Write("Marca: ");
            veiculo.Marca = Console.ReadLine();

            Console.Write("Modelo: ");
            veiculo.Modelo = Console.ReadLine();

            Console.Write("Cor: ");
            veiculo.Cor = Console.ReadLine();

            Console.Write("Ano: ");
            veiculo.Ano = Convert.ToInt16( Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Selecione o tipo:");
            ListarTiposVeiculos();

            Console.Write("Tipo: ");
            var idTipo = Convert.ToInt64( Console.ReadLine());
            veiculo.Tipo = BuscarTipoVeiculo(idTipo);

            veiculo = _veiculoService.Insert(veiculo);
            if (veiculo.Id > 0)
            {
                Console.WriteLine("Veículo cadastrado com sucesso.");                
            }


        }

        private static void ListarVeiculos()
        {
            List<VeiculoDTO> listVeiculoDto = _veiculoService.List();
            if(listVeiculoDto.Count == 0)
            {
                Console.WriteLine("Ainda não foi cadastrado nenhum veículo.");
            }
            foreach (var veiculo in listVeiculoDto)
            {
                Console.WriteLine($"Id: {veiculo.Id}");
                Console.WriteLine($"{veiculo.Marca} {veiculo.Modelo}");                
                Console.WriteLine($"Placa: {veiculo.Placa}");              
                Console.WriteLine($"Ano: {veiculo.Ano}");
                Console.WriteLine($"Cor: {veiculo.Cor}");
                Console.WriteLine($"Tipo: {veiculo.Tipo.Descricao}");
            }
            Console.ReadLine();
        }

        private static void BuscarVeiculo()
        {
            Console.Write("Informe o código veiculo: ");
            var codigo = Convert.ToInt64(Console.ReadLine());
            var veiculo = BuscarVeiculo(codigo);

            if (veiculo != null && veiculo.Id == codigo)
            {
                Console.WriteLine($"Id: {veiculo.Id}");
                Console.WriteLine($"{veiculo.Marca} {veiculo.Modelo}");
                Console.WriteLine($"Placa: {veiculo.Placa}");
                Console.WriteLine($"Ano: {veiculo.Ano}");
                Console.WriteLine($"Cor: {veiculo.Cor}");
                Console.WriteLine($"Tipo: {veiculo.Tipo.Descricao}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }

        }

        private static VeiculoDTO BuscarVeiculo(long Id)
        {
            return _veiculoService.Get(Id);
        }

        private static void ExcluirTipoVeiculo()
        {
            Console.Write("Informe o código do tipo: ");
            var codigoTipo = Convert.ToInt64(Console.ReadLine());

            var tipoExcluir = BuscarTipoVeiculo(codigoTipo);
            if (tipoExcluir != null && tipoExcluir.Id > 0)
            {
                Console.WriteLine($"Tem certeza que deseja excluir o tipo {tipoExcluir.Descricao} ? S/N: ");

                var opcao = Console.ReadLine().ToUpper();
                if (opcao == "S")
                {
                    bool excluido = _serviceTipoVeiculo.Delete(tipoExcluir.Id);
                    if (excluido)
                    {
                        Console.WriteLine("Tipo excluído com sucesso");
                    }
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }

            }
            else
            {
                Console.WriteLine("Tipo não encontrado.");
            }

        }

        private static TipoVeiculoDTO BuscarTipoVeiculo(long codigoTipo)
        {
            return _serviceTipoVeiculo.Get(codigoTipo);
        }

        private static void AtualizarTipoVeiculo()
        {
            try
            {
                Console.Write("Informe o código do tipo: ");
                var codigoTipo = Convert.ToInt64(Console.ReadLine());

                var tipoAtualizar = BuscarTipoVeiculo(codigoTipo);
                Console.WriteLine("Dados do tipo atual");
                Console.WriteLine($"Id: {tipoAtualizar.Id}");
                Console.WriteLine($"Descrição: {tipoAtualizar.Descricao}");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("Dados para atualizar");
                Console.Write("Descrição: ");
                tipoAtualizar.Descricao = Console.ReadLine();
                tipoAtualizar = _serviceTipoVeiculo.Update(tipoAtualizar);

                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Dados atualizadosl");
                Console.WriteLine($"Id: {tipoAtualizar.Id}");
                Console.WriteLine($"Descrição: {tipoAtualizar.Descricao}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }           

        }

        private static void CadastrarTipoVeiculo()
        {
            try
            {
                TipoVeiculoDTO tipoVeiculoDTO = new TipoVeiculoDTO();

                Console.Write("Descrição: ");
                tipoVeiculoDTO.Descricao = Console.ReadLine();

                tipoVeiculoDTO = _serviceTipoVeiculo.Insert(tipoVeiculoDTO);
                Console.WriteLine($"Id: {tipoVeiculoDTO.Id}");
                Console.WriteLine($"Descrição: {tipoVeiculoDTO.Descricao}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }          
           
        }

        static void ListarTiposVeiculos()
        {

            List<TipoVeiculoDTO> listTiposDTO = _serviceTipoVeiculo.List();
            foreach (var tipoVeiculo in listTiposDTO)
            {
                Console.WriteLine($"Id: {tipoVeiculo.Id}");
                Console.WriteLine($"Desrição: {tipoVeiculo.Descricao}");
            }
            
        }


    }
}