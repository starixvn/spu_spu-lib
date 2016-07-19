namespace FD.Lib.DTO
{
    using Fanex.Data.Repository;
    using System.ComponentModel.DataAnnotations;

    public class MessageMaster
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Message Code Required.")]
        [StringLength(50, ErrorMessage = "The max length of MessageCode is 50 characters.")]
        public string MessageCode { get; set; }

        [Required(ErrorMessage = "Message Content Required.")]
        public string MessageContent { get; set; }

        public string MessageDesc { get; set; }

        public string Recipient { get; set; }

        public string UsernameRecipient { get; set; }

        public string OnlineRecipient { get; set; }

        public string UsernameOnlineRecipient { get; set; }

        public bool IsActive { get; set; }
    }
}
