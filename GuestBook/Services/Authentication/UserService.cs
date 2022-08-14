using GuestBook.Models.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace GuestBook.Services.Authentication
{
    public class UserService
    {
        private IConfiguration _configuration;
        private string connectionString;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            Console.WriteLine(_configuration.GetValue<String>("connectionString"));
            connectionString = _configuration.GetValue<String>("connectionString");
        }

        public UserService() {
            //connectionString = "Data Source=Yousef-Gamal;Initial Catalog=GuestBook;Integrated Security=True";
            //_configuration = null;
        }
        public Boolean signUp(User user) {
            try
            {
                const String insertionQuery = "INSERT INTO [GuestBook].[dbo].[User] values (@userId, @name, @email, @password)";
                SqlDataReader myReader;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertionQuery, connection))
                    {   
                        // TODO: Validation that email is unique

                        command.Parameters.Add("@userId", System.Data.SqlDbType.Int);
                        command.Parameters["@userId"].Value = user.Id;
                        command.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
                        command.Parameters["@name"].Value = user.Name;
                        command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                        command.Parameters["@email"].Value = user.Email;
                        String passwordHashed = hashPassword(user.Password);
                        command.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
                        command.Parameters["@password"].Value = passwordHashed;

                        myReader = command.ExecuteReader();


                        myReader.Close();
                        connection.Close();

                        return true;


                    }
                }
            }
            catch { throw; }
            
        }

        public bool login(LoginUser user) {
            const String query = "SELECT * FROM [GuestBook].[dbo].[User] WHERE email = @email and password = @password";

            SqlDataReader myReader;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                    command.Parameters["@email"].Value = user.Email;
                    String passwordHashed = hashPassword(user.Password);

                    command.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
                    command.Parameters["@password"].Value = passwordHashed;

                    myReader = command.ExecuteReader();


                    bool isFound = myReader.HasRows;


                    myReader.Close();
                    connection.Close();
                    return isFound;
                }
            }

                return true;
        }

        private String hashPassword(String password)
        {
            String saltValue = _configuration.GetSection("Security").GetValue<String>("PasswordSalt");

            byte[] salt = Encoding.ASCII.GetBytes(saltValue);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
    password: password!,
    salt: salt,
    prf: KeyDerivationPrf.HMACSHA256,
    iterationCount: 100000,
    numBytesRequested: 256 / 8));

    return hashed;

        }
    }
}
