using Curso.Data.Interfaces;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.DB
{
    public class TipoVeiculoDB : BaseDB, ITipoVeiculoDataOperaration
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }

        public List<TipoVeiculoDB> List()
        {
            List<TipoVeiculoDB> listTipos = new List<TipoVeiculoDB>();
            try
            {
                string sqlList = "select * from tipo_veiculo order by id";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {

                    using (MySqlCommand command = new MySqlCommand(sqlList, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                TipoVeiculoDB tipoVeiculoDB = new TipoVeiculoDB();
                                tipoVeiculoDB.Id = reader.GetInt32("id");
                                tipoVeiculoDB.Descricao = reader.GetString("descricao");

                                listTipos.Add(tipoVeiculoDB);

                                //Outra forma de adicionar.
                                //listTipos.Add(new TipoVeiculoDB
                                //{
                                //    Id = reader.GetInt32("id"),
                                //    Descricao = reader.GetString("descricao")
                                //});
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

        public TipoVeiculoDB Insert(TipoVeiculoDB tipoVeiculoDB)
        {
            try
            {
                string sqlInsert = $"insert into tipo_veiculo(descricao)values('{tipoVeiculoDB.Descricao}'); SELECT LAST_INSERT_ID()";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlInsert, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        command.ExecuteNonQuery();
                        tipoVeiculoDB.Id = command.LastInsertedId;
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tipoVeiculoDB;
        }

        public bool Delete(long id)
        {
            try
            {
                string sqlDelete = $"delete from tipo_veiculo where id = {id}";
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

        public TipoVeiculoDB Update(TipoVeiculoDB tipoVeiculoDB)
        {
            try
            {
                string sqlUpdate = $"update tipo_veiculo set descricao ='{tipoVeiculoDB.Descricao}' where id ={tipoVeiculoDB.Id}";
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

            return tipoVeiculoDB;
        }

        public TipoVeiculoDB Get(long id)
        {
            TipoVeiculoDB tipoVeiculoDB = new TipoVeiculoDB();
            try
            {
                string sqlGet = $"select * from tipo_veiculo where id = {id}";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {

                    using (MySqlCommand command = new MySqlCommand(sqlGet, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                               
                                tipoVeiculoDB.Id = reader.GetInt32("id");
                                tipoVeiculoDB.Descricao = reader.GetString("descricao");
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

            return tipoVeiculoDB;
        }
    }


}
