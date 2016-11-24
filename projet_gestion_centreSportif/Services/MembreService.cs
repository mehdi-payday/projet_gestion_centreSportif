using System;
using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
namespace projet_gestion_centreSportif.Services {
    public class MembreService {
        Connection connection = new Connection();
        private static readonly string INSERT_MEMBRE_QUERY = "INSERT INTO membre(`prenom`, `nom`, `email`, `password`) VALUES(@prenom, @nom, @email, @password)";
        private static readonly string LOGIN_USER_QUERY = "SELECT * FROM membre WHERE email=@email and password=@password";
        public Boolean register(Membre membre) {
            Boolean registered = true;
            try {
                
                MySqlCommand command;
                connection.getConnection().Open();
                command = new MySqlCommand(MembreService.INSERT_MEMBRE_QUERY, connection.getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("prenom", membre.Prenom);
                command.Parameters.AddWithValue("nom", membre.Nom);
                command.Parameters.AddWithValue("email", membre.Email);
                command.Parameters.AddWithValue("password", membre.Password);
                
                command.ExecuteNonQuery();
                connection.getConnection().Close();
            } catch (MySqlException mysqlException) {
                registered = false;
                Console.WriteLine(mysqlException.Message);
            }
            return registered;
        }
        public Boolean MembreValid(Membre membre) {
            Boolean valid = false;
            try {
                MySqlCommand command;
                connection.getConnection().Open();
                command = new MySqlCommand(MembreService.LOGIN_USER_QUERY, connection.getConnection());
                command.Prepare();
                
                command.Parameters.AddWithValue("email", membre.Email);
                command.Parameters.AddWithValue("password", membre.Password);

                if (command.ExecuteScalar() != null && (int)command.ExecuteScalar() == 1) {
                    valid = true;
                }
                connection.getConnection().Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }

            return valid;
        }

    }
}