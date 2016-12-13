using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_gestion_centreSportif.Services {
    public class VisiteService {
        private static readonly string INSERT_VISITE_QUERY = "INSERT INTO visite(`idMembre`, `ipAdresse`) VALUES(@idMembre, @ipAdresse)";
        private static readonly string READ_VISITE_QUERY = "SELECT `id`, `idMembre`, `date`, `ipAdresse` FROM visite WHERE `id` = @id";
        private static readonly string DELETE_VISITE_QUERY = "DELETE FROM visite WHERE `id` = @id";
        private static readonly string GET_ALL_VISITE_QUERY = "SELECT `id`, `idMembre`, `date`, `ipAdresse` FROM visite";
        Connection connexion;

        public VisiteService() {
            connexion = new Connection();
        }

        /// <summary>
        /// Ajouter unE VISITE a la base de donnee
        /// </summary>
        /// <param name="visite">la visite a ajouter</param>
        public void add(Visite visite) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(VisiteService.INSERT_VISITE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("idMembre", visite.IdMembre);
                    command.Parameters.AddWithValue("ipAdresse", visite.IPAdresse);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }
        }
        /// <summary>
        /// Ajouter la connexion d'un membre a la base de donnee.
        /// </summary>
        /// <param name="visite">la visite a inscrir</param>
        public void Login(Visite visite) {
            add(visite);
        }

        /// <summary>
        /// Read une visite.
        /// </summary>
        /// <param name="idVisite">l'id de la visite</param>
        /// <returns>une visite; null sinon</returns>
        public Visite Read(string idVisite) {
            Visite visite = null;
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(VisiteService.READ_VISITE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", idVisite);
                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            visite = new Visite();
                            visite.IdVisite = reader.GetString("id");
                            visite.IdMembre = reader.GetString("idMembre");
                            visite.Date = reader.GetDateTime("date");
                            visite.IPAdresse = reader.GetString("ipAdresse");

                        }
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }
            return visite;
        }
    }
}