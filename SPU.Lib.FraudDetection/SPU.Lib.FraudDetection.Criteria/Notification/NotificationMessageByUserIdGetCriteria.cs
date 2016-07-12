namespace FD.Lib.Criteria.Notification
{
    using Fanex.Data.Repository;

    /// <summary>
    /// NotificationMessageByUserIdGetCriteria Class.
    /// </summary>
    public class NotificationMessageByUserIdGetCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_NotificationGetUserMessageById";
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
