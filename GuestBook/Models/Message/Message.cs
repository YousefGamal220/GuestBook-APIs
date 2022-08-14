namespace GuestBook.Models.Message
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int senderId { get; set; }

        public int reciverId { get; set; }

        public DateTime sentAt{ get; set; }
        public DateTime recivedAt { get; set; }
        
        public int repliedMessageId { get; set; }
        public bool isDeleted { get; set; }

        public bool isSeen { get; set; }

        public bool isRecived { get; set; }


    }
}
