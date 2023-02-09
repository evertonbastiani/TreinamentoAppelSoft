using Curso.Business.Classes;
using Curso.Business.DTO;
using Curso.Business.Interfaces;
using Curso.Data.DB;
using Curso.Data.Interfaces;

namespace Curso.Application
{
    internal class Program
    {
        static ITipoVeiculoDataOperaration tipoVeiculoDataOperaration = new TipoVeiculoDB();
        static ITipoVeiculoBusinessOperation tipoVeiculoBusinessOperation = new TipoVeiculoBS(tipoVeiculoDataOperaration);
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Selecione a opção desejada");
                Console.WriteLine("1 - Listar Tipos de Veículos");
                Console.WriteLine("2 - Cadastrar Tipos de Veículos");
                Console.WriteLine("3 - Atualizar Tipo de Veículo");
                Console.WriteLine("4 - Excluir Tipo de Veículo");
                Console.WriteLine("5 - Buscar Tipo de Veículo por Id");
                Console.WriteLine("6- Sair");
                Console.Write("Opção: ");
                var opcaoSelecionada = Console.ReadLine();
                switch (opcaoSelecionada)
                {
                    case "1":
                        {
                            ListarTiposVeiculos();
                            break;
                        }
                    case "2":
                        {
                            CadastrarTipoVeiculo();
                            break;
                        }
                    case "3":
                        {
                            AtualizarTipoVeiculo();
                            break;
                        }
                    case "4":
                        {
                            ExcluirTipoVeiculo();
                            break;
                        }
                    case "5":
                        {
                            BuscarVeiculo();
                            break;
                        }
                    case "6":
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

        private static void BuscarVeiculo()
        {
            Console.Write("Informe o código do tipo: ");
            var codigoTipo = Convert.ToInt64(Console.ReadLine());
            var tipoVeiculo = tipoVeiculoBusinessOperation.Get(codigoTipo);

            Console.WriteLine($"Id: {tipoVeiculo.Id}");
            Console.WriteLine($"Descrição: {tipoVeiculo.Descricao}");
            Console.ReadLine();
        }

        private static TipoVeiculoDTO BuscarVeiculo(long Id)
        {
            return tipoVeiculoBusinessOperation.Get(Id);
        }

        private static void ExcluirTipoVeiculo()
        {
            Console.Write("Informe o código do tipo: ");
            var codigoTipo = Convert.ToInt64(Console.ReadLine());

            var tipoExcluir = BuscarVeiculo(codigoTipo);
            if(tipoExcluir != null && tipoExcluir.Id > 0)
            {
                Console.WriteLine($"Tem certeza que deseja excluir o tipo {tipoExcluir.Descricao} ? S/N: ");
               
                var opcao = Console.ReadLine().ToUpper();
                if(opcao == "S")
                {
                    bool excluido = tipoVeiculoBusinessOperation.Delete(tipoExcluir.Id);
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

        private static void AtualizarTipoVeiculo()
        {
            Console.Write("Informe o código do tipo: ");
            var codigoTipo = Convert.ToInt64(Console.ReadLine());

            var tipoAtualizar = BuscarVeiculo(codigoTipo);
            Console.WriteLine("Dados do tipo atual");
            Console.WriteLine($"Id: {tipoAtualizar.Id}");
            Console.WriteLine($"Descrição: {tipoAtualizar.Descricao}");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Dados para atualizar");
            Console.Write("Descrição: ");
            tipoAtualizar.Descricao = Console.ReadLine();
            tipoAtualizar = tipoVeiculoBusinessOperation.Update(tipoAtualizar);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Dados atualizadosl");
            Console.WriteLine($"Id: {tipoAtualizar.Id}");
            Console.WriteLine($"Descrição: {tipoAtualizar.Descricao}");

        }

        private static void CadastrarTipoVeiculo()
        {
            TipoVeiculoDTO tipoVeiculoDTO = new TipoVeiculoDTO();

            Console.Write("Descrição: ");
            tipoVeiculoDTO.Descricao = Console.ReadLine();

            tipoVeiculoDTO = tipoVeiculoBusinessOperation.Insert(tipoVeiculoDTO);
            Console.WriteLine($"Id: {tipoVeiculoDTO.Id}");
            Console.WriteLine($"Descrição: {tipoVeiculoDTO.Descricao}");
            Console.ReadLine();
        }

        static void ListarTiposVeiculos()
        {

            List<TipoVeiculoDTO> listTiposDTO = tipoVeiculoBusinessOperation.List();
            foreach (var tipoVeiculo in listTiposDTO)
            {
                Console.WriteLine($"Id: {tipoVeiculo.Id}");
                Console.WriteLine($"Desrição: {tipoVeiculo.Descricao}");
            }
            Console.ReadLine();
        }


    }
}