using System;
using System.Collections.Generic;
using projet_gestion_centreSportif.Models;
using MySql.Data.MySqlClient;

namespace projet_gestion_centreSportif.Services {
    public class InscriptionService {
        Connection connexion;
        private static readonly string INSERT_INSCRIPTION_QUERY = "INSERT INTO inscription(`idActivite`, `idMembre`, `date_debut`, `date_fin`) VALUES(@idActivite, @idMembre, @dateInscription, @dateFin)";
        private static readonly string FIND_BY_ACTIVITE = "SELECT `id`, `idActivite`, `idMembre`, `date_debut`, `date_fin` FROM inscription WHERE `idActivite` = @idActivite";
        private static readonly string FIND_BY_MEMBRE = "SELECT `id`, `idActivite`, `idMembre`, `date_debut`, `date_fin` FROM inscription WHERE `idMembre` = @idMembre";
        private static readonly string UPDATE_INSCRIPTION_QUERY = "UPDATE inscription SET `date_fin` = @dateFin,  WHERE `id` = @idIscription";
        private static readonly string GET_ALL_INSCRIPTION_QUERY = "SELECT `id`, `idActivite`, `idMembre`, `date_debut`, `date_fin` FROM inscription";
        private static readonly string DELETE_INSCRIPTION_QUERY = "DELETE FROM inscription WHERE `id` = @idInscription";
        private static readonly string READ_INSCRIPTION_QUERY = "SELECT `idInscription`, `idActivite`, `idMembre`, `date_debut`, `date_fin` FROM inscription WHERE `id` = @idInscription";

        public InscriptionService() {
            connexion = new Connection();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Inscription
        /// </summary>
        /// <param name="inscriptionModel">L'inscription a ajouter</param>
        public void Add(Inscription inscriptionModel) {
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.INSERT_INSCRIPTION_QUERY,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idActivite", inscriptionModel.IdActivite);
                        command.Parameters.AddWithValue("idMembre", inscriptionModel.IdMembre);
                        command.Parameters.AddWithValue("dateInscription", inscriptionModel.DateInscription);
                        command.Parameters.AddWithValue("dateFin", inscriptionModel.DateFin);

                        command.ExecuteNonQuery();
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Inscription
        /// </summary>
        /// <param name="idInscription">l'id de l'inscription que l'on veut read</param>
        /// <returns>une Inscription; null sinon</returns>
        public Inscription Read(int idInscription) {
            Inscription inscriptionModel = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.READ_INSCRIPTION_QUERY,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idInscription", idInscription);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                inscriptionModel = new Inscription();
                                inscriptionModel.IdInscription = reader.GetString("id");
                                inscriptionModel.IdActivite = reader.GetString("idActivite");
                                inscriptionModel.IdMembre = reader.GetString("idMembre");
                                inscriptionModel.DateInscription = reader.GetDateTime("date_debut");
                                inscriptionModel.DateFin = reader.GetDateTime("date_fin");
                            }
                        }
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return inscriptionModel;
        }

        /// <summary>
        /// Fait un Find by Inscription dans la BD sur la table Inscription
        /// </summary>
        /// <param name="idInscription">l'id de l'inscription que l'on veut read</param>
        /// <returns>des Inscriptions; null sinon</returns>
        public List<Inscription> FindByActivite(int idInscription) {
            List<Inscription> inscriptions = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.FIND_BY_ACTIVITE,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idActivite",idInscription);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            Inscription inscriptionModel;
                            if (reader.Read()) {
                                inscriptions = new List<Inscription>();
                                do {
                                    inscriptionModel = new Inscription();
                                    inscriptionModel.IdInscription = reader.GetString("id");
                                    inscriptionModel.IdActivite = reader.GetString("idActivite");
                                    inscriptionModel.IdMembre = reader.GetString("idMembre");
                                    inscriptionModel.DateInscription = reader.GetDateTime("date_debut");
                                    inscriptionModel.DateFin = reader.GetDateTime("date_fin");
                                    inscriptions.Add(inscriptionModel);
                                } while (reader.Read());
                            }
                        }
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return inscriptions;
        }

        /// <summary>
        /// Fait un Find by Membre dans la BD sur la table Inscription
        /// </summary>
        /// <param name="idMembre">l'id du membre que l'on veut read</param>
        /// <returns>des Inscriptions; null sinon</returns>
        public List<Inscription> FindByMembre(int idMembre) {
            List<Inscription> inscriptions = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.FIND_BY_MEMBRE,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idMembre",idMembre);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            Inscription inscriptionModel;
                            if (reader.Read()) {
                                inscriptions = new List<Inscription>();
                                do {
                                    inscriptionModel = new Inscription();
                                    inscriptionModel.IdInscription = reader.GetString("id");
                                    inscriptionModel.IdActivite = reader.GetString("idActivite");
                                    inscriptionModel.IdMembre = reader.GetString("idMembre");
                                    inscriptionModel.DateInscription = reader.GetDateTime("date_debut");
                                    inscriptionModel.DateFin = reader.GetDateTime("date_fin");
                                    inscriptions.Add(inscriptionModel);
                                } while (reader.Read());
                            }
                        }
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return inscriptions;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Inscription
        /// </summary>
        /// <param name="inscriptionModel">L'inscription a modifier</param>
        public void Update(Inscription inscriptionModel) {
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.UPDATE_INSCRIPTION_QUERY,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("dateFin", inscriptionModel.DateFin);
                        command.ExecuteNonQuery();
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Inscription
        /// </summary>
        /// <param name="inscriptionModel">L'inscription a supprimer</param>
        public void Delete(Inscription inscriptionModel) {
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.DELETE_INSCRIPTION_QUERY,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idInscription",inscriptionModel.IdInscription);

                        command.ExecuteNonQuery();
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }


        /// <summary>
        /// Retourne la liste de toutes les inscriptions de la table Inscription
        /// </summary>
        /// <returns>La liste de toutes les inscription; une liste vide sinon</returns>
        public List<Inscription> GetAll() {
            List<Inscription> inscriptions = new List<Inscription>();
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.GET_ALL_INSCRIPTION_QUERY,connection)) {
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                Inscription inscriptionModel = new Inscription();
                                command.Parameters.AddWithValue("idInscription", inscriptionModel.IdInscription);
                                command.Parameters.AddWithValue("idActivite", inscriptionModel.IdActivite);
                                command.Parameters.AddWithValue("idMembre", inscriptionModel.IdMembre);
                                command.Parameters.AddWithValue("dateInscription", inscriptionModel.DateInscription);
                                command.Parameters.AddWithValue("dateFin", inscriptionModel.DateFin);
                                inscriptions.Add(inscriptionModel);
                            }
                        }
                    }
                }
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return inscriptions;
        }
    }
}