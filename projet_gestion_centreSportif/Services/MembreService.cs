using System;
using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
using System.Collections.Generic;

namespace projet_gestion_centreSportif.Services {
    public class MembreService {
        Connection connection;
        private static readonly string INSERT_MEMBRE_QUERY = "INSERT INTO membre(`prenom`, `nom`, `email`, `password`) VALUES(@prenom, @nom, @email, @password)";
        private static readonly string LOGIN_MEMBRE_QUERY = "SELECT * FROM membre WHERE email=@email and password=@password";
        private static readonly string GET_ALL_MEMRES_QUERY = "SELECT `id`, `prenom`, `nom`, `email`,`isAdmin` FROM membre";

        public MembreService() {
            connection = new Connection();
        }

        public Boolean inscrire(Membre membre) {
            Boolean inscrit = true;
            try {

                MySqlCommand command;
                connection.Open();
                command = new MySqlCommand(MembreService.INSERT_MEMBRE_QUERY, connection.getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("prenom", membre.Prenom);
                command.Parameters.AddWithValue("nom", membre.Nom);
                command.Parameters.AddWithValue("email", membre.Email);
                command.Parameters.AddWithValue("password", membre.Password);

                command.ExecuteNonQuery();
                connection.Close();
            } catch (MySqlException mysqlException) {
                inscrit = false;
                Console.WriteLine(mysqlException.Message);
            }
            return inscrit;
        }
        public Boolean MembreValid(Membre membre) {
            Boolean valid = false;
            try {
                MySqlCommand command;
                connection.Open();
                command = new MySqlCommand(MembreService.LOGIN_MEMBRE_QUERY, connection.getConnection());
                command.Prepare();

                command.Parameters.AddWithValue("email", membre.Email);
                command.Parameters.AddWithValue("password", membre.Password);

                if (command.ExecuteScalar() != null && (int)command.ExecuteScalar() == 1) {
                    valid = true;
                }
                connection.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }

            return valid;
        }

        public List<Membre> GetALl() {
            List<Membre> membres = null;
            try {
                MySqlCommand command;
                connection.Open();
                command = new MySqlCommand(MembreService.GET_ALL_MEMRES_QUERY, connection.getConnection());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    Membre membre = new Membre();
                    membre.Id = reader.GetInt16(0);
                    membre.Prenom = reader.GetString(2);
                    membre.Nom = reader.GetString(1);
                    membre.Email = reader.GetString(3);
                    membre.IsAdmin = reader.GetInt16(4);
                    membres.Add(membre);
                }
                connection.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }
            return membres;
        }
    }
}