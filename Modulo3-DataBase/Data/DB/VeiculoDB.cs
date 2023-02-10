using Curso.Data.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.DB
{
    public class VeiculoDB: BaseDB, IVeiculoDataOperation
    {
        public long Id { get; set; }
        public string ?Marca { get; set; }
        public string ?Modelo { get; set; }
        public int Ano { get; set; }
        public string ?Cor { get; set; }
        public string ?Placa { get; set; }

        public TipoVeiculoDB Tipo { get; set; }

        public VeiculoDB()
        {
            this.Tipo = new TipoVeiculoDB();    
        }

        public List<VeiculoDB> List()
        {
            List<VeiculoDB> listTipos = new List<VeiculoDB>();
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
                                VeiculoDB veiculoDB = new VeiculoDB();
                                veiculoDB.Id = reader.GetInt32("id");
                                veiculoDB.Placa = reader.GetString("placa");
                                veiculoDB.Ano = reader.GetInt32("ano");
                                veiculoDB.Cor = reader.GetString("cor");
                                veiculoDB.Marca = reader.GetString("marca");
                                veiculoDB.Modelo = reader.GetString("modelo");

                                TipoVeiculoDB tipoVeiculoDB = new TipoVeiculoDB().Get(reader.GetInt32("tipo"));
                                veiculoDB.Tipo = tipoVeiculoDB;

                                listTipos.Add(veiculoDB);
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

            return listTipos;
        }

        public VeiculoDB Insert(VeiculoDB veiculoDB)
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
                                          '{veiculoDB.Marca}',
                                          '{veiculoDB.Modelo}',
                                          '{veiculoDB.Cor}',
                                          '{veiculoDB.Placa}',
                                          '{veiculoDB.Tipo.Id}',
                                          '{veiculoDB.Ano}'
                                         ); SELECT LAST_INSERT_ID()";

                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlVeiculos, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        command.ExecuteNonQuery();
                        veiculoDB.Id = command.LastInsertedId;
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return veiculoDB;
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

        public VeiculoDB Update(VeiculoDB veiculoDB)
        {
            try
            {
                string sqlUpdate = $@"update veiculo set 
                                           modelo ='{veiculoDB.Modelo}',
                                           marca = '{veiculoDB.Marca}',
                                           cor = '{veiculoDB.Cor}',
                                           placa = '{veiculoDB.Placa}',
                                           ano = '{veiculoDB.Ano}',
                                           tipo = '{veiculoDB.Tipo.Id}'
                                      where 
                                           id ={veiculoDB.Id}";
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

            return veiculoDB;
        }

        public VeiculoDB Get(long id)
        {
            VeiculoDB veiculoDB = new VeiculoDB();
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
                                veiculoDB.Id = reader.GetInt32("id");
                                veiculoDB.Placa = reader.GetString("placa");
                                veiculoDB.Ano = reader.GetInt32("ano");
                                veiculoDB.Cor = reader.GetString("cor");
                                veiculoDB.Marca = reader.GetString("marca");
                                veiculoDB.Modelo = reader.GetString("modelo");

                                TipoVeiculoDB tipoVeiculoDB = new TipoVeiculoDB().Get(reader.GetInt32("tipo"));
                                veiculoDB.Tipo = tipoVeiculoDB;
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

            return veiculoDB;
        }
    }
}
