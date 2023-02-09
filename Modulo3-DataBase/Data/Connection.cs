using MySql.Data.MySqlClient;

namespace Curso.Data
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString);
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw;
            }
            return conn;
        }
    }
}