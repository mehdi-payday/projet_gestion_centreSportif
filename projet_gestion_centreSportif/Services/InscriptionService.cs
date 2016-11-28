using System;
using System.Collections.Generic;
using projet_gestion_centreSportif.Models;
using MySql.Data.MySqlClient;

namespace projet_gestion_centreSportif.Services {
    public class InscriptionService {
        Connection connexion;
        private static readonly string INSERT_INSCRIPTION_QUERY = "INSERT INTO inscription(`IdInscription`, `IdMembre`, `Prix`, `DateInscription`, `DateFin`) VALUES(@idInscription, @idMembre, @prix, @dateInscription, @dateFin)";
        private static readonly string FIND_BY_ACTIVITE = "SELECT `IdInscription`, `IdMembre`, `Prix`, `DateInscription`, `DateFin` FROM inscription WHERE `IdInscription` = @idInscription";
        private static readonly string FIND_BY_MEMBRE = "SELECT `IdInscription`, `IdMembre`, `Prix`, `DateInscription`, `DateFin` FROM inscription WHERE `IdMembre` = @idMembre";
        private static readonly string UPDATE_INSCRIPTION_QUERY = "UPDATE inscription SET  `Prix` = @prix, `DateFin` = @dateFin,  WHERE `IdInscription` = @idIscription";
        private static readonly string GET_ALL_INSCRIPTION_QUERY = "SELECT `IdInscription`, `IdMembre`, `Prix`, `DateInscription`, `DateFin` FROM inscription";
        private static readonly string DELETE_INSCRIPTION_QUERY = "DELETE FROM Inscriiption WHERE `idInscription` = @idInscription";
        private static readonly string READ_INSCRIPTION_QUERY = "SELECT `IdInscription`, `IdMembre`, `Prix`, `DateInscription`, `DateFin` FROM inscription WHERE `IdInscription` = @idInscription";

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
                        command.Parameters.AddWithValue("idInscription",inscriptionModel.IdInscription);
                        command.Parameters.AddWithValue("idMembre",inscriptionModel.IdMembre);
                        command.Parameters.AddWithValue("prix",inscriptionModel.Prix);
                        command.Parameters.AddWithValue("dateInscription",inscriptionModel.DateInscription);
                        command.Parameters.AddWithValue("dateFin",inscriptionModel.DateFin);

                        command.ExecuteNonQuery();
                    }
                }
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);
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
                        command.Parameters.AddWithValue("idInscription",idInscription);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                inscriptionModel = new Inscription();
                                inscriptionModel.IdInscription = reader.GetString("idInscription");
                                inscriptionModel.IdMembre = reader.GetString("idMembre");
                                inscriptionModel.Prix = reader.GetString("prix");
                                inscriptionModel.DateInscription = reader.GetDateTime("dateInscription");
                                inscriptionModel.DateFin = reader.GetDateTime("dateFin");
                            }
                        }
                    }
                }
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);

            }
            return inscriptionModel;
        }

        /// <summary>
        /// Fait un Find by Inscription dans la BD sur la table Inscription
        /// </summary>
        /// <param name="idInscription">l'id de l'inscription que l'on veut read</param>
        /// <returns>une Inscription; null sinon</returns>
        public Inscription FindByInscription(int idInscription) {
            Inscription inscriptionModel = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.FIND_BY_ACTIVITE,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idInscription",idInscription);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                inscriptionModel = new Inscription();
                                inscriptionModel.IdInscription = reader.GetString("idInscription");
                                inscriptionModel.IdMembre = reader.GetString("idMembre");
                                inscriptionModel.Prix = reader.GetString("prix");
                                inscriptionModel.DateInscription = reader.GetDateTime("dateInscription");
                                inscriptionModel.DateFin = reader.GetDateTime("dateFin");
                            }
                        }
                    }
                }
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);
            }
            return inscriptionModel;
        }

        /// <summary>
        /// Fait un Find by Membre dans la BD sur la table Inscription
        /// </summary>
        /// <param name="idInscription">l'id de l'inscription que l'on veut read</param>
        /// <returns>une Inscription; null sinon</returns>
        public Inscription FindByMembre(int idMembre) {
            Inscription inscriptionModel = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(InscriptionService.FIND_BY_MEMBRE,connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("idMembre",idMembre);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                inscriptionModel = new Inscription();
                                inscriptionModel.IdInscription = reader.GetString("idInscription");
                                inscriptionModel.IdMembre = reader.GetString("idMembre");
                                inscriptionModel.Prix = reader.GetString("prix");
                                inscriptionModel.DateInscription = reader.GetDateTime("dateInscription");
                                inscriptionModel.DateFin = reader.GetDateTime("dateFin");
                            }
                        }
                    }
                }
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);
            }
            return inscriptionModel;
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
                        command.Parameters.AddWithValue("prix",inscriptionModel.Prix);
                        command.Parameters.AddWithValue("dateFin",inscriptionModel.DateFin);
                        command.ExecuteNonQuery();
                    }
                }
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);
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
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);

            }
        }


        /// <summary>
        /// Retourne la liste de toutes les inscription de la table Inscription
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
                                command.Parameters.AddWithValue("idInscription",inscriptionModel.IdInscription);
                                command.Parameters.AddWithValue("idInscription",inscriptionModel.IdInscription);
                                command.Parameters.AddWithValue("idMembre",inscriptionModel.IdMembre);
                                command.Parameters.AddWithValue("prix",inscriptionModel.Prix);
                                command.Parameters.AddWithValue("dateInscription",inscriptionModel.DateInscription);
                                command.Parameters.AddWithValue("dateFin",inscriptionModel.DateFin);
                                inscriptions.Add(inscriptionModel);
                            }
                        }
                    }
                }
            } catch (MySqlException exception) {
                // TODO
                Console.WriteLine(exception.Message);
            }
            return inscriptions;
        }


    }
}