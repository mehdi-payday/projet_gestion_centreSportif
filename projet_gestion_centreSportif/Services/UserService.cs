using System;
using MySql.Data.MySqlClient;
using projet_gestion_centreSportif.Models;
namespace projet_gestion_centreSportif.Services {
    public class UserService {
        Connection connection = new Connection();
        private static readonly string INSERT_USER_QUERY = "INSERT INTO users VALUES(null, @first_name, @lastname, @email, @password, 0)";
        private static readonly string USER_LOGIN_QUERY = "SELECT * FROM users WHERE email=@email and password=@password";
        public Boolean register(User user) {
            Boolean registered = true;
            try {
                
                MySqlCommand command;
                connection.getConnection().Open();
                command = new MySqlCommand(UserService.INSERT_USER_QUERY, connection.getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("first_name", user.First_name);
                command.Parameters.AddWithValue("lastname", user.Last_name);
                command.Parameters.AddWithValue("email", user.Email);
                command.Parameters.AddWithValue("password", user.Password);
                
                command.ExecuteNonQuery();
                connection.getConnection().Close();        // Close the connection to the database
            } catch (MySqlException mysqlException) {
                registered = false;
                Console.WriteLine(mysqlException.Message);
            }
            return registered;
        }
        public Boolean ValidUser(User user) {
            Boolean valid = false;
            try {
                MySqlCommand command;
                connection.getConnection().Open();
                command = new MySqlCommand(UserService.USER_LOGIN_QUERY, connection.getConnection());
                command.Prepare();
                
                command.Parameters.AddWithValue("email", user.Email);
                command.Parameters.AddWithValue("password", user.Password);

                if (command.ExecuteScalar() != null && (int)command.ExecuteScalar() == 1) {
                    valid = true;
                }
                connection.getConnection().Close();        // Close the connection to the database
            } catch (MySqlException mysqlException) {
                Console.WriteLine(mysqlException.Message);
            }

            return valid;
        }

    }
}