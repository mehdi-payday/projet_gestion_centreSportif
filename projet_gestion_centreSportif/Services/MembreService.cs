using System;
using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
using System.Collections.Generic;

namespace projet_gestion_centreSportif.Services {
    public class MembreService {
        Connection connexion;
        private static readonly string INSERT_MEMBRE_QUERY = "INSERT INTO `membre` (`prenom`, `nom`, `email`, `password`, `balance`, `adresse`, `cart_credit`, `cart_cvc`) VALUES (@prenom, @nom, @email, @password, @balance, @adresse, @cart_credit, @cart_cvc)";
        private static readonly string READ_MEMBRE_QUERY = "SELECT `id`, `prenom`, `nom`, `email`, `password`, `isAdmin`, `balance`, `adresse`, `cart_credit`, `cart_cvc` FROM membre WHERE `id`=@id";
        private static readonly string UPDATE_MEMBRE_QUERY = "UPDATE membre SET `prenom`=@prenom, `nom`=@nom, `email`=@email, `password`=@password, balance=@balance, adresse=@adresse, cart_credit=@cart_credit, cart_cvc=@cart_cvc WHERE `id`=@id";
        private static readonly string DELETE_MEMBRE_QUERY = "DELETE FROM membre WHERE `id`=@id";
        private static readonly string GET_ALL_MEMRE_QUERY = "`id`, `prenom`, `nom`, `email`, `password`, `isAdmin`, `balance`, `adresse`, `cart_credit`, `cart_cvc` FROM membre";
        private static readonly string LOGIN_MEMBRE_QUERY = "SELECT * FROM membre WHERE email=@email and password=@password";
        private static readonly string REGISTER_MEMBRE_QUERY = "INSERT INTO membre(`prenom`, `nom`, `email`, `password`) VALUES(@prenom, @nom, @email, @password)";

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
                    command.Parameters.AddWithValue("balance", membre.Balance);
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
        /// <param name="membre">le membre a inscrir</param>
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
        /// Verifier si la combinaison de mot de passe et email est valide
        /// </summary>
        /// <param name="membre">le membre a verifier</param>
        /// <returns>un membre; null sinon</returns>
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
                            unMembre.Balance = reader.GetInt32("balance");
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
        /// Read un membre.
        /// </summary>
        /// <param name="idMembre">l'id du membre</param>
        /// <returns>un membre; null sinon</returns>
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
                            membre.Balance = reader.GetInt32("balance");
                            membre.Adresse = reader.GetString("adresse");
                            membre.Cart_Credit = reader.GetInt64("cart_credit");
                            membre.Cart_CVC = reader.GetInt16("cart-cvc");

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
        /// Fait un Update dans la BD sur la table Membre
        /// </summary>
        /// <param name="membre">Le membre a modifier</param>
        public void Update(Membre membre) {
            try {
                connexion.Open();
                using (MySqlCommand command = new MySqlCommand(MembreService.UPDATE_MEMBRE_QUERY, connexion.getConnection())) {
                    command.Prepare();
                    command.Parameters.AddWithValue("id", membre.IdMembre);
                    command.Parameters.AddWithValue("prenom", membre.Prenom);
                    command.Parameters.AddWithValue("nom", membre.Nom);
                    command.Parameters.AddWithValue("email", membre.Email);
                    command.Parameters.AddWithValue("password", membre.Password);
                    command.Parameters.AddWithValue("balance", membre.Balance);
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
        /// <param name="idMembre"> id du membre a supprimer</param>
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
        /// Desinscrire un membre.
        /// </summary>
        /// <param name="idMembre"> id du membre a Desinscrire</param>
        public void Desinscrire(string idMembre) {
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
                        membre.IdMembre = reader.GetString("id");
                        membre.Prenom = reader.GetString("prenom");
                        membre.Nom = reader.GetString("nom");
                        membre.Email = reader.GetString("Email");
                        membre.IsAdmin = reader.GetInt16("isAdmin");
                        membre.Balance = reader.GetInt32("balance");
                        membre.Adresse = reader.GetString("adresse");
                        membre.Cart_Credit = reader.GetInt64("cart_credit");
                        membre.Cart_CVC = reader.GetInt16("cart-cvc");
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