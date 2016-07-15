namespace FD.Lib.DTO
{
    using Fanex.Data.Repository;
    using System.ComponentModel.DataAnnotations;

    public class MessageMaster
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Message Code Required.")]
        public string MessageCode { get; set; }

        public string MessageContent { get; set; }

        public string MessageDesc { get; set; }

        //[RegularExpression(@"^[\d]*$")]
        [Required(ErrorMessage = "Recipient Required.")]
        public string Recipient { get; set; }

        public string UsernameRecipient { get; set; }

        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found.")]
        [Required(ErrorMessage = "Online Recipient Required.")]
        public string OnlineRecipient { get; set; }

        public string UsernameOnlineRecipient { get; set; }

        public bool IsActive { get; set; }
    }
}
