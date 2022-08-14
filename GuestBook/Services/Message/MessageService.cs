using GuestBook.Models.Message;
using System.Data.SqlClient;

namespace GuestBook.Services.Message
{
    public class MessageService
    {
        private String connectionString = "Data Source=Yousef-Gamal;Initial Catalog=GuestBook;Integrated Security=True";
        public bool sendMessage(GuestBook.Models.Message.Message message) {
            try {

                const String insertionQuery = "INSERT INTO [GuestBook].[dbo].[Messages] values (@id, @conent, @senderId, @reciverId, @isRecived, @repliedMessageId, @sentAt, @recivedAt, @isSeen, isDeleted)";
                SqlDataReader myReader;
                using (SqlConnection connection = new SqlConnection("Data Source=Yousef-Gamal;Initial Catalog=GuestBook;Integrated Security=True")) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertionQuery, connection)) {
                        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
                        command.Parameters["@Id"].Value = message.Id;

                        command.Parameters.Add("@content", System.Data.SqlDbType.VarChar);
                        command.Parameters["@content"].Value = message.Content;

                        command.Parameters.Add("@senderId", System.Data.SqlDbType.Int);
                        command.Parameters["@senderId"].Value = message.senderId;

                        command.Parameters.Add("@reciverId", System.Data.SqlDbType.Int);
                        command.Parameters["@reciverId"].Value = message.reciverId;

                        command.Parameters.Add("@isRecived", System.Data.SqlDbType.Bit);
                        command.Parameters["@isRecived"].Value = false;

                        command.Parameters.Add("@repliedMessageId", System.Data.SqlDbType.Int);
                        command.Parameters["@repliedMessageId"].Value = null;

                        command.Parameters.Add("@sentAt", System.Data.SqlDbType.DateTime);
                        command.Parameters["@Id"].Value = DateTime.Now;

                        command.Parameters.Add("@recivedAt", System.Data.SqlDbType.DateTime);
                        command.Parameters["@recivedAt"].Value = null;

                        command.Parameters.Add("@isSeen", System.Data.SqlDbType.Bit);
                        command.Parameters["@isSeen"].Value = false ;

                        command.Parameters.Add("@isDeleted", System.Data.SqlDbType.Bit);
                        command.Parameters["@isDeleted"].Value = false;

                        myReader = command.ExecuteReader();


                        myReader.Close();
                        connection.Close();
                        return true;

                    }
                }
            }
            catch (Exception e) {
                throw;
                
            }
            
            return false;
        }

        public bool Delete(int messageId) {
            try {

                const String insertionQuery = "UPDATE [GuestBook].[dbo].[Messages] SET isDeleted = 1 WHERE id = @id";
                SqlDataReader myReader;
                using (SqlConnection connection = new SqlConnection("Data Source=Yousef-Gamal;Initial Catalog=GuestBook;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertionQuery, connection))
                    {
                        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
                        command.Parameters["@Id"].Value = messageId;

                        myReader = command.ExecuteReader();
                        myReader.Close();
                        connection.Close();
                        return true;
                    }
                }

                    }
            catch (Exception e) {
                throw;

            }
            return false;
        }

        public bool updateMessage(int messageId, string messageContent) {

            try {
                const String insertionQuery = "UPDATE [GuestBook].[dbo].[Messages] SET messageContent = @content WHERE id = @id";
                SqlDataReader myReader;
                using (SqlConnection connection = new SqlConnection("Data Source=Yousef-Gamal;Initial Catalog=GuestBook;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertionQuery, connection))
                    {
                        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
                        command.Parameters["@Id"].Value = messageId;

                        command.Parameters.Add("@content", System.Data.SqlDbType.VarChar);
                        command.Parameters["@content"].Value = messageContent;

                        myReader = command.ExecuteReader();
                        myReader.Close();
                        connection.Close();
                        return true;
                    }
                }

                
            }
            catch (Exception e) { throw; }
            return false;
        }

        public bool replyToMessage(GuestBook.Models.Message.Message message) {

            try
            {

                const String insertionQuery = "INSERT INTO [GuestBook].[dbo].[Messages] values (@id, @conent, @senderId, @reciverId, @isRecived, @repliedMessageId, @sentAt, @recivedAt, @isSeen, isDeleted)";
                SqlDataReader myReader;
                using (SqlConnection connection = new SqlConnection("Data Source=Yousef-Gamal;Initial Catalog=GuestBook;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertionQuery, connection))
                    {
                        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
                        command.Parameters["@Id"].Value = message.Id;

                        command.Parameters.Add("@content", System.Data.SqlDbType.VarChar);
                        command.Parameters["@content"].Value = message.Content;

                        command.Parameters.Add("@senderId", System.Data.SqlDbType.Int);
                        command.Parameters["@senderId"].Value = message.senderId;

                        command.Parameters.Add("@reciverId", System.Data.SqlDbType.Int);
                        command.Parameters["@reciverId"].Value = message.reciverId;

                        command.Parameters.Add("@isRecived", System.Data.SqlDbType.Bit);
                        command.Parameters["@isRecived"].Value = false;

                        command.Parameters.Add("@repliedMessageId", System.Data.SqlDbType.Int);
                        command.Parameters["@repliedMessageId"].Value = message.repliedMessageId;

                        command.Parameters.Add("@sentAt", System.Data.SqlDbType.DateTime);
                        command.Parameters["@Id"].Value = DateTime.Now;

                        command.Parameters.Add("@recivedAt", System.Data.SqlDbType.DateTime);
                        command.Parameters["@recivedAt"].Value = null;

                        command.Parameters.Add("@isSeen", System.Data.SqlDbType.Bit);
                        command.Parameters["@isSeen"].Value = false;

                        command.Parameters.Add("@isDeleted", System.Data.SqlDbType.Bit);
                        command.Parameters["@isDeleted"].Value = false;

                        myReader = command.ExecuteReader();


                        myReader.Close();
                        connection.Close();
                        return true;

                    }
                }
            }
            catch (Exception e)
            {
                throw;

            }

            return false;

        }


    }
}
