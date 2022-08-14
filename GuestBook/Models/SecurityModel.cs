namespace GuestBook.Models
{
    public class SecurityModel 
    {
        public string ConnectionString { get; set; }
        public string JwtToken { get; set; }

        public string hashingKey { get; set; }
    }
}
