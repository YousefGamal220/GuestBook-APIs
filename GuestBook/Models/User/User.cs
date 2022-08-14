namespace GuestBook.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Password { get; set; }
        public bool Enabled { get; set; }

        public string PhoneNumber { get; set; }
    }
}
