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
        private static readonly string UPDATE_VISITE_QUERY = "UPDATE visite SET `idMembre`=@idMembre, `date`=@date, `ipAdresse`=@ipAdresse WHERE `id`=@id";
        private static readonly string DELETE_VISITE_QUERY = "DELETE FROM visite WHERE `id` = @id";
        private static readonly string GET_ALL_VISITE_QUERY = "SELECT `id`, `idMembre`, `date`, `ipAdresse` FROM visite";
        Connection connexion;

        public VisiteService() {
            connexion = new Connection();
        }

        /// <summary>
        /// Ajouter une visite a la base de donnee
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
        /// <summary>
        /// Supprimer une visite.
        /// </summary>
        /// <param name="idVisite"> id de la visite à supprimer</param>
        public void Delete(string idVisite) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(VisiteService.DELETE_VISITE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", idVisite);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Mettre à jour une visite.
        /// </summary>
        /// <param name="visite">La visite à mettre àjour.</param>
        public void Update(Visite visite) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(VisiteService.UPDATE_VISITE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("idMembre", visite.IdMembre);
                    command.Parameters.AddWithValue("date", visite.Date);
                    command.Parameters.AddWithValue("ipAdresse", visite.IPAdresse);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }
        /// <summary>
        /// Récupérer la liste de toutes les visites.
        /// </summary>
        /// <returns>Une liste de visite; une liste vide sinon</returns>
        public List<Visite> GetAll() {
            List<Visite> visites = new List<Visite>();
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(VisiteService.GET_ALL_VISITE_QUERY, connexion.getConnection())) {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Visite visite = new Visite();
                        visite.IdVisite = reader.GetString("id");
                        visite.IdMembre = reader.GetString("idMembre");
                        visite.Date = reader.GetDateTime("date");
                        visite.IPAdresse = reader.GetString("ipAdresse");
                        visites.Add(visite);
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return visites;
        }
    }
}