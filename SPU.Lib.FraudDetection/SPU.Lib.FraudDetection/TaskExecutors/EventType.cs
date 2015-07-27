namespace SPU.Lib.FraudDetection.TaskExecutors
{
    public enum EventType
    {
        /// <summary>
        /// No Event type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Scan Match And Find Ticket.
        /// </summary>
        ScanMatchAndFindTicket = 1,

        /// <summary>
        /// Count Suspicious Times By Customer.
        /// </summary>
        CountSuspiciousTimesByCustomer = 2
    }
}