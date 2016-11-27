using System;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace projet_gestion_centreSportif {
    public class Connection {
        MySqlConnection connection;
        public Connection() {
            CreateConnection();
        }
        private void CreateConnection() {
            try {
                string connectionString = ConfigurationManager.ConnectionStrings["mysqlConnectionString"].ConnectionString;
                MySqlConnection connection = new MySqlConnection(connectionString);
                setConnection(connection);
            } catch (MySqlException sqlException) {
                Console.WriteLine(sqlException.Message);
            }
        }
        public void Open() {
            getConnection().Open();
        }
        public void Close() {
            getConnection().Close();
        }
        public void setConnection(MySqlConnection connection) {
            this.connection = connection;
        }
        public MySqlConnection getConnection() {
            return this.connection;
        }
    }
}