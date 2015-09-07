namespace FD.Lib.QueryGenerator
{
    public enum EventType
    {
        /// <summary>
        /// No Event type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Scan Match - Find Ticket
        /// </summary>
        ScanMathFindTicket = 1,

        /// <summary>
        /// Count Suspicious Times By Customer.
        /// </summary>
        CountSuspiciousTimes = 2,

        /// <summary>
        /// Scan Match - Find Betting Groups.
        /// </summary>
        ScanMatchFinBettingGroups = 3
    }
}