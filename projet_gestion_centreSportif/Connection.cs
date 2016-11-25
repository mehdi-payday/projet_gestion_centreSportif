using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace projet_gestion_centreSportif {
    public class Connection {
        MySqlConnection connection;
        public Connection() {
            CreateConnection();
        }
        private void CreateConnection() {
            try {
                String connectionString = "server=localhost;uid=root;pwd='';database=centresportif;";
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