namespace FD.Lib.Criteria.Notification
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     NotificationMessageByUserIdUpdateCriteria Class.
    /// </summary>
    public class NotificationMessageByUserIdUpdateCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public bool IsViewed { get; set; }

        ////public int ErrCode { get; set; }

        //// string ErrMsg { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_NotificationUpdateAllUserMessageStatus";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
