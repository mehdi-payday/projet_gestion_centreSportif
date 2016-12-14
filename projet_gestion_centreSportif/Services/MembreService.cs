using System;
using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
using System.Collections.Generic;

namespace projet_gestion_centreSportif.Services {
    public class MembreService {
        Connection connexion;
        private static readonly string INSERT_MEMBRE_QUERY = "INSERT INTO `membre` (`prenom`, `nom`, `email`, `password`, `adresse`, `cart_credit`, `cart_cvc`) VALUES (@prenom, @nom, @email, @password, @adresse, @cart_credit, @cart_cvc)";
        private static readonly string READ_MEMBRE_QUERY = "SELECT `id`, `prenom`, `nom`, `email`, `password`, `isAdmin`, `adresse`, `cart_credit`, `cart_cvc` FROM membre WHERE `id`=@id";
        private static readonly string UPDATE_MEMBRE_QUERY = "UPDATE membre SET `prenom`=@prenom, `nom`=@nom, `email`=@email, `password`=@password, adresse=@adresse, cart_credit=@cart_credit, cart_cvc=@cart_cvc WHERE `id`=@id";
        private static readonly string DELETE_MEMBRE_QUERY = "DELETE FROM membre WHERE `id`=@id";
        private static readonly string GET_ALL_MEMRE_QUERY = "`id`, `prenom`, `nom`, `email`, `password`, `isAdmin`, `adresse`, `cart_credit`, `cart_cvc` FROM membre";
        private static readonly string LOGIN_MEMBRE_QUERY = "SELECT * FROM membre WHERE email=@email and password=@password";
        private static readonly string UNIQUE_EMAIL_QUERY= "SELECT * FROM membre WHERE email=@email";
        private static readonly string REGISTER_MEMBRE_QUERY = "INSERT INTO membre(`prenom`, `nom`, `email`, `password`) VALUES(@prenom, @nom, @email, @password)";

        public MembreService() {
            connexion = new Connection();
        }

        /// <summary>
        /// Ajouter un membre à la base de donnée.
        /// </summary>
        /// <param name="membre">Le membre à ajouter.</param>
        public void add(Membre membre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.INSERT_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("prenom", membre.Prenom);
                    command.Parameters.AddWithValue("nom", membre.Nom);
                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);
                    command.Parameters.AddWithValue("adresse", membre.Adresse);
                    command.Parameters.AddWithValue("cart_Credit", membre.Cart_Credit);
                    command.Parameters.AddWithValue("cart_cvc", membre.Cart_CVC);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }
        /// <summary>
        /// Inscrir un membre.
        /// </summary>
        /// <param name="membre">Le membre à inscrir</param>
        public void inscrire(Membre membre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.REGISTER_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("prenom", membre.Prenom);
                    command.Parameters.AddWithValue("nom", membre.Nom);
                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);
                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }
        /// <summary>
        /// Verifier si la combinaison du mot de passe et l'adresse email  est valide.
        /// </summary>
        /// <param name="membre">Le membre à vérifier.</param>
        /// <returns>Un membre; null sinon.</returns>
        public Membre MembreValid(Membre membre) {
            Membre unMembre= null;
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.LOGIN_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();

                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);
                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            unMembre = new Membre();
                            unMembre.IdMembre = reader.GetString("id");
                            unMembre.Prenom = reader.GetString("prenom");
                            unMembre.Nom = reader.GetString("nom");
                            unMembre.Email = reader.GetString("email");
                            unMembre.Password = reader.GetString("password");
                            unMembre.IsAdmin = reader.GetInt16("isAdmin");
                            unMembre.Adresse = reader.GetString("adresse");
                            unMembre.Cart_Credit = reader.GetInt64("cart_credit");
                            unMembre.Cart_CVC = reader.GetInt16("cart_cvc");
                        }
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }

            return unMembre;
        }

        /// <summary>
        /// Vérifier si l'adresse email est unique
        /// </summary>
        /// <param name="membre">Le membre contenant l'adresse email.</param>
        /// <returns>Un membre; null sinon.</returns>
        public bool EmailUnique(Membre membre) {
            bool unique = true;
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.UNIQUE_EMAIL_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("email", membre.Email);

                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            unique = false;
                        }
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }

            return unique;
        }
        /// <summary>
        /// Récupérer un membre.
        /// </summary>
        /// <param name="idMembre">L'id du membre.</param>
        /// <returns>Un membre; null sinon.</returns>
        public Membre Read(string idMembre) {
            Membre membre = null;
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.READ_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", idMembre);
                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            membre = new Membre();
                            membre.IdMembre= reader.GetString("id");
                            membre.Prenom = reader.GetString("prenom");
                            membre.Nom = reader.GetString("nom");
                            membre.Email = reader.GetString("email");
                            membre.Password = reader.GetString("password");
                            membre.IsAdmin = reader.GetInt16("isAdmin");
                            membre.Adresse = reader.GetString("adresse");
                            membre.Cart_Credit = reader.GetInt64("cart_credit");
                            membre.Cart_CVC = reader.GetInt16("cart_cvc");

                        }
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return membre;
        }
        /// <summary>
        /// Mettre à jour un membre.
        /// </summary>
        /// <param name="membre">Le membre à mettre àjour.</param>
        public void Update(Membre membre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.UPDATE_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("prenom", membre.Prenom);
                    command.Parameters.AddWithValue("nom", membre.Nom);
                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);
                    command.Parameters.AddWithValue("adresse", membre.Adresse);
                    command.Parameters.AddWithValue("cart_Credit", membre.Cart_Credit);
                    command.Parameters.AddWithValue("cart_cvc", membre.Cart_CVC);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Supprimer un membre.
        /// </summary>
        /// <param name="idMembre"> ID du membre à supprimer</param>
        public void Delete(string idMembre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.DELETE_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", idMembre);

                    command.ExecuteNonQuery();
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }
        /// <summary>
        /// Désinscrire un membre.
        /// </summary>
        /// <param name="idMembre"> ID du membre à Désinscrire.</param>
        public void Desinscrire(string idMembre) {
            Delete(idMembre);
        }

        /// <summary>
        /// Récupérer la liste de tous les membres.
        /// </summary>
        /// <returns>Une liste de membres; une liste vide sinon</returns>
        public List<Membre> GetAll() {
            List<Membre> membres = new List<Membre>();
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.GET_ALL_MEMRE_QUERY, connexion.getConnection())) {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Membre membre = new Membre();
                        membre.IdMembre = reader.GetString("id");
                        membre.Prenom = reader.GetString("prenom");
                        membre.Nom = reader.GetString("nom");
                        membre.Email = reader.GetString("Email");
                        membre.IsAdmin = reader.GetInt16("isAdmin");
                        membre.Adresse = reader.GetString("adresse");
                        membre.Cart_Credit = reader.GetInt64("cart_credit");
                        membre.Cart_CVC = reader.GetInt16("cart_cvc");
                        membres.Add(membre);
                    }
                }
                connexion.Close();
            } catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return membres;
        }
    }
}