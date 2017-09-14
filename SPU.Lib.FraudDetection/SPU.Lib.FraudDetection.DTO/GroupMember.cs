namespace FD.Lib.DTO
{
    using System;

    public class GroupMember
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedDateString
        {
            get
            {
                return CreatedDate != null ? CreatedDate.Value.ToString() : string.Empty;
            }
        }
    }
}