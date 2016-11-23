using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace projet_gestion_centreSportif
{
    public class Connection
    {
        MySqlConnection connection;
        public Connection() {
            CreateConnection();
        }
        private void CreateConnection() {
            try
            {
                String connectionString = "server=localhost;uid=admin;pwd=1234;database=centresportif;";
                MySqlConnection con = new MySqlConnection(connectionString);
                setConnection(con);
            }
            catch (SQLiteException sqlException) {
                throw new SQLiteException(sqlException.Message);
            }
        }
        public void setConnection(MySqlConnection connection) {
            this.connection = connection;
        }
        public MySqlConnection getConnection() {
            return this.connection;
        }
    }
}