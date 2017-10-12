namespace FD.Lib.QueryGenerator
{
    public enum ActivityType
    {
        /// <summary>
        /// No Event type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Scan Match - Find Ticket.
        /// </summary>
        ScanMathFindTicket = 1,

        /// <summary>
        /// Count Suspicious Times By Customer.
        /// </summary>
        CountSuspiciousTimes = 2,

        /// <summary>
        /// Scan Match - Capture Data.
        /// </summary>
        ScanMatchCaptureData = 3,

        /// <summary>
        /// Scan Match - Compare Match Data.
        /// </summary>
        ScanMatchCompareData = 4,

        ScanCustomerSyncData = 5
    }
}