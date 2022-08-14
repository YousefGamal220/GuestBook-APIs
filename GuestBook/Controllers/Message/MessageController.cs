using GuestBook.Services.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Controllers.Message
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        MessageService messageService = new MessageService();
        public IActionResult Index()
        {
            return View();
        }

        // TODO: Remove this when complete JWT Configuration
        [AllowAnonymous]
        [HttpPost]
        [Route("send")]
        public IActionResult send([FromBody] GuestBook.Models.Message.Message message) {
            try
            {
                bool isSent = messageService.sendMessage(message);
                return isSent ? Ok(message) : BadRequest("Something went wrong");

                // Complete JWT Configuration
                /*
                var user = HttpContext.User;
                if (user.HasClaim((c => c.Type == "id")))
                {
                    int id = int.Parse(user.Claims.FirstOrDefault(c => c.Type == "id").Value);

                    message.senderId = id;
                    bool isSent = messageService.sendMessage(message);
                    return isSent ? Ok(message) : BadRequest("Something went wrong");

                }
                else {
                    return Unauthorized("User is not Authorised");
                }
                */

            }
            catch (Exception e) {
                return StatusCode(500, e.ToString());
            }
            
        }

        // TODO: Remove this when complete JWT Configuration
        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public IActionResult update([FromQuery(Name = "messageId")] int messageId, [FromBody] string message) {
            try {

                // TODO: Check that the senderId is the one who requested the update of the message
                // That can be done by checking in the database if the senderId of the given message
                // is equal to the Id extracted from the JWT Token
                bool isUpdated = messageService.updateMessage(messageId, message);
                return isUpdated ? Ok(message) : BadRequest("Something went wrong");
            }
            catch (Exception e) {
                return StatusCode(500, e.ToString());
            }
        }
        // TODO: Remove this when complete JWT Configuration
        [AllowAnonymous]

        [HttpDelete]
        [Route("delete")]
        public IActionResult delete([FromQuery(Name = "messageId")] int messageId) {
            try {
                
                bool isDeleted = messageService.Delete(messageId);
                return isDeleted ? Ok("Deleted") : BadRequest("Something went wrong");
            }
            catch (Exception e) {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPost]
        [Route("reply")]
        public IActionResult reply([FromBody] GuestBook.Models.Message.Message message) {
            if (message.repliedMessageId == null) {
                return BadRequest("MessageId cannot be empty");
            }
            try
            {
                bool isDeleted = messageService.replyToMessage(message);
                return isDeleted ? Ok(message) : BadRequest("Something went wrong");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }

        }

    }
}
