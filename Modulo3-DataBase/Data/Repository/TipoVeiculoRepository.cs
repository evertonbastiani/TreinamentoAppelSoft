using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Repository.Repository
{
    public class TipoVeiculoRepository : Repository, ITipoVeiculoRepository
    {
        public List<TipoVeiculo> List()
        {
            List<TipoVeiculo> listTipos = new List<TipoVeiculo>();
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

                                TipoVeiculo tipoVeiculoDB = new TipoVeiculo();
                                tipoVeiculoDB.Id = reader.GetInt32("id");
                                tipoVeiculoDB.Descricao = reader.GetString("descricao");

                                listTipos.Add(tipoVeiculoDB);
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

        public TipoVeiculo Insert(TipoVeiculo tipoVeiculo)
        {
            try
            {
                string sqlInsert = $"insert into tipo_veiculo(descricao)values('{tipoVeiculo.Descricao}'); SELECT LAST_INSERT_ID()";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlInsert, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        command.ExecuteNonQuery();
                        tipoVeiculo.Id = command.LastInsertedId;
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tipoVeiculo;
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

        public TipoVeiculo Update(TipoVeiculo tipoVeiculo)
        {
            try
            {
                string sqlUpdate = $"update tipo_veiculo set descricao ='{tipoVeiculo.Descricao}' where id ={tipoVeiculo.Id}";
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

            return tipoVeiculo;
        }

        public TipoVeiculo Get(long id)
        {
            TipoVeiculo tipoVeiculo = new TipoVeiculo();
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
                                tipoVeiculo.Id = reader.GetInt32("id");
                                tipoVeiculo.Descricao = reader.GetString("descricao");
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

            return tipoVeiculo;
        }
    }


}
