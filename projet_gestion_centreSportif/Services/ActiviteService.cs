﻿using System;
using System.Collections.Generic;
using projet_gestion_centreSportif.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace projet_gestion_centreSportif.Services {
    public class ActiviteService {

        Connection connexion;
        private static readonly string INSERT_ACTIVITE_QUERY = "INSERT INTO activite(`nom`, `prix`, `description`, `duree`) VALUES(@nom, @prix, @description, @duree)";
        private static readonly string READ_ACTIVITE_QUERY = "SELECT `id`, `nom`, `prix`, `description`, `duree` FROM activite WHERE `id` = @id";
        private static readonly string UPDATE_ACTIVITE_QUERY = "UPDATE activite SET `nom` = @nom, `prix` = @prix, `description` = @description, `duree` = @duree WHERE `id` = @id";
        private static readonly string DELETE_ACTIVITE_QUERY = "DELETE FROM activite WHERE `id` = @id";
        private static readonly string GET_ALL_ACTIVITE_QUERY = "SELECT `id`, `nom`, `prix`, `description`, `duree` FROM activite";

        public ActiviteService() {
            connexion = new Connection();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Activite
        /// </summary>
        /// <param name="activiteModel">L'activite a ajouter</param>
        public void Add(Activite activiteModel) {
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ActiviteService.INSERT_ACTIVITE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("nom", activiteModel.Nom);
                        command.Parameters.AddWithValue("prix", activiteModel.Prix);
                        command.Parameters.AddWithValue("description", activiteModel.Description);
                        command.Parameters.AddWithValue("duree", activiteModel.Duree);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException exception) {
                // TODO
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Activite
        /// </summary>
        /// <param name="idActivite">l'id de l'activite que l'on veut read</param>
        /// <returns>une Activite; null sinon</returns>
        public Activite Read(int idActivite) {
            Activite activiteModel = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ActiviteService.READ_ACTIVITE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("id", idActivite);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                activiteModel = new Activite();
                                activiteModel.id = reader.GetString("id");
                                activiteModel.Nom = reader.GetString("nom");
                                activiteModel.Prix = reader.GetString("prix");
                                activiteModel.Description = reader.GetString("description");
                                activiteModel.Duree = reader.GetString("duree");
                            }
                        } 
                    }
                }
            }
            catch (MySqlException exception) {
                // TODO
            }
            return activiteModel;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Activite
        /// </summary>
        /// <param name="activiteModel">L'activite a modifier</param>
        public void Update(Activite activiteModel) {
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ActiviteService.UPDATE_ACTIVITE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("nom", activiteModel.Nom);
                        command.Parameters.AddWithValue("prix", activiteModel.Prix);
                        command.Parameters.AddWithValue("description", activiteModel.Description);
                        command.Parameters.AddWithValue("duree", activiteModel.Duree);
                        command.Parameters.AddWithValue("id", activiteModel.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException exception) {
                // TODO
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Activite
        /// </summary>
        /// <param name="activiteModel">L'activite a supprimer</param>
        public void Delete(Activite activiteModel) {
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ActiviteService.DELETE_ACTIVITE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("id", activiteModel.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException exception) {
                // TODO
            }
        }

        /// <summary>
        /// Retourne la liste de toutes les activite de la table Activite
        /// </summary>
        /// <returns>La liste de toutes les activite; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnection()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ActiviteService.GET_ALL_ACTIVITE_QUERY, connection)) {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            }
            catch (MySqlException exception) {
                // TODO
            }
            return dataset;
        }
    }
}
