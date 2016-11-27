using System;
using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
using System.Collections.Generic;

namespace projet_gestion_centreSportif.Services {
    public class MembreService {
        Connection connexion;
        private static readonly string INSERT_MEMBRE_QUERY = "INSERT INTO membre(`prenom`, `nom`, `email`, `password`) VALUES(@prenom, @nom, @email, @password)";
        private static readonly string READ_MEMBRE_QUERY = "SELECT `id`, `prenom`, `nom`, `email`, `password`, `isAdmin` FROM membre WHERE `id`=@id";
        private static readonly string UPDATE_MEMBRE_QUERY = "UPDATE membre SET `prenom`=@prenom, `nom`=@nom, `email`=@email, `password`=@password WHERE `id`=@id";
        private static readonly string DELETE_MEMBRE_QUERY = "DELETE FROM membre WHERE `id`=@id";
        private static readonly string GET_ALL_MEMRE_QUERY = "SELECT `id`, `prenom`, `nom`, `email`,`isAdmin` FROM membre";
        private static readonly string LOGIN_MEMBRE_QUERY = "SELECT * FROM membre WHERE email=@email and password=@password";

        public MembreService() {
            connexion = new Connection();
        }

        /// <summary>
        /// Ajouter un membre a la base de donnee
        /// </summary>
        /// <param name="membre">le membre a ajouter</param>
        public void add(Membre membre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.INSERT_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("prenom", membre.Prenom);
                    command.Parameters.AddWithValue("nom", membre.Nom);
                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }
        }
        /// <summary>
        /// Inscrir un membre.
        /// </summary>
        /// <param name="membre">le membre a inscrir</param>
        public void inscrire(Membre membre) {
            add(membre);
        }
        /// <summary>
        /// Verifier si la combinaison de mot de passe et email est valide
        /// </summary>
        /// <param name="membre">le membre a verifier</param>
        /// <returns>true ou false</returns>
        public Boolean MembreValid(Membre membre) {
            Boolean valid = false;
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.LOGIN_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();

                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);

                    if (command.ExecuteScalar() != null && (int)command.ExecuteScalar() == 1) {
                        valid = true;
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }

            return valid;
        }

        /// <summary>
        /// Read un membre.
        /// </summary>
        /// <param name="idMembre">l'id du membre</param>
        /// <returns>un membre; null sinon</returns>
        public Membre Read(int idMembre) {
            Membre membre = null;
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.READ_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", idMembre);
                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            membre = new Membre();
                            membre.Id = reader.GetInt16("id");
                            membre.Prenom = reader.GetString("prenom");
                            membre.Nom = reader.GetString("nom");
                            membre.Password = reader.GetString("password");
                            membre.IsAdmin = reader.GetInt16("isAdmin");
                        }
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }
            return membre;
        }
        /// <summary>
        /// Fait un Update dans la BD sur la table Membre
        /// </summary>
        /// <param name="membre">Le membre a modifier</param>
        public void Update(Membre membre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.UPDATE_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("prenom", membre.Prenom);
                    command.Parameters.AddWithValue("nom", membre.Nom);
                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException exception) {
                // TODO
            }
        }

        /// <summary>
        /// Supprimer un membre.
        /// </summary>
        /// <param name="idMembre"> id du membre a supprimer</param>
        public void Delete(int idMembre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.DELETE_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", idMembre);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException exception) {
                // TODO
            }
        }
        /// <summary>
        /// Desinscrire un membre.
        /// </summary>
        /// <param name="idMembre"> id du membre a Desinscrire</param>
        public void Desinscrire(int idMembre) {
            Delete(idMembre);
        }

        /// <summary>
        /// Retourne la liste de tous les membres.
        /// </summary>
        /// <returns>La liste de toute les membres; une liste vide sinon</returns>
        public List<Membre> GetAll() {
            List<Membre> membres = new List<Membre>();
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.GET_ALL_MEMRE_QUERY, connexion.getConnection())) {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Membre membre = new Membre();
                        membre.Id = reader.GetInt16("id");
                        membre.Prenom = reader.GetString("prenom");
                        membre.Nom = reader.GetString("nom");
                        membre.Email = reader.GetString("Email");
                        membre.IsAdmin = reader.GetInt16("isAdmin");
                        membres.Add(membre);
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }
            return membres;
        }
    }
}