using MySql.Data.MySqlClient;

namespace Curso.Data
{
    internal class Connection : IDisposable
    {
        private readonly string _connectionString;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            if (this != null)
            {
                this.Dispose();
            }
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw;
            }
            return conn;
        }
    }
}