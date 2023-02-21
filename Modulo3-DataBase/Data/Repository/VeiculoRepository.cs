using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using MySql.Data.MySqlClient;

namespace Curso.Repository.Repository
{
    public class VeiculoRepository: Repository, IVeiculoRepository
    {
        private readonly ITipoVeiculoRepository _tipoVeiculoRepository;
       public TipoVeiculo Tipo { get; set; }

        public VeiculoRepository(ITipoVeiculoRepository tipoVeiculoRepository)
        {
            this._tipoVeiculoRepository = tipoVeiculoRepository;
            this.Tipo = new TipoVeiculo();    
        }

        public List<Veiculo> List()
        {
            List<Veiculo> listVeiculos = new List<Veiculo>();
            try
            {
                string sqlVeiculos = "select * from veiculo order by id";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlVeiculos, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Veiculo veiculo = new Veiculo();
                                veiculo.Id = reader.GetInt32("id");
                                veiculo.Placa = reader.GetString("placa");
                                veiculo.Ano = reader.GetInt32("ano");
                                veiculo.Cor = reader.GetString("cor");
                                veiculo.Marca = reader.GetString("marca");
                                veiculo.Modelo = reader.GetString("modelo");

                                var tipoVeiculo = _tipoVeiculoRepository.Get(reader.GetInt32("tipo"));
                                veiculo.Tipo = tipoVeiculo;

                                listVeiculos.Add(veiculo);
                            }
                        }
                        mySqlConnection.Close();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return listVeiculos;
        }

        public Veiculo Insert(Veiculo veiculo)
        {
            try
            {
                string sqlVeiculos = $@"insert into veiculo
                                        ( marca,
                                          modelo,
                                          cor,
                                          placa,
                                          tipo,
                                          ano
                                        )
                                      values
                                        (
                                          '{veiculo.Marca}',
                                          '{veiculo.Modelo}',
                                          '{veiculo.Cor}',
                                          '{veiculo.Placa}',
                                          '{veiculo.Tipo.Id}',
                                          '{veiculo.Ano}'
                                         ); SELECT LAST_INSERT_ID()";

                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlVeiculos, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        command.ExecuteNonQuery();
                        veiculo.Id = command.LastInsertedId;
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return veiculo;
        }

        public bool Delete(long id)
        {
            try
            {
                string sqlDelete = $"delete from veiculo where id = {id}";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlDelete, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        var result = command.ExecuteNonQuery();
                        mySqlConnection.Close();
                        return result > 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Veiculo Update(Veiculo veiculo)
        {
            try
            {
                string sqlUpdate = $@"update veiculo set 
                                           modelo ='{veiculo.Modelo}',
                                           marca = '{veiculo.Marca}',
                                           cor = '{veiculo.Cor}',
                                           placa = '{veiculo.Placa}',
                                           ano = '{veiculo.Ano}',
                                           tipo = '{veiculo.Tipo.Id}'
                                      where 
                                           id ={veiculo.Id}";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlUpdate, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        command.ExecuteNonQuery();
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return veiculo;
        }

        public Veiculo Get(long id)
        {
            Veiculo veiculo = new Veiculo();
            try
            {
                string sqlGet = $"select * from veiculo where id = {id}";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {

                    using (MySqlCommand command = new MySqlCommand(sqlGet, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                              
                                veiculo.Id = reader.GetInt32("id");
                                veiculo.Placa = reader.GetString("placa");
                                veiculo.Ano = reader.GetInt32("ano");
                                veiculo.Cor = reader.GetString("cor");
                                veiculo.Marca = reader.GetString("marca");
                                veiculo.Modelo = reader.GetString("modelo");

                                var tipoVeiculo = _tipoVeiculoRepository.Get(reader.GetInt32("tipo"));
                                veiculo.Tipo = tipoVeiculo;
                            }
                        }
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return veiculo;
        }
    }
}
