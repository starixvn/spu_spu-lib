// --------------------------------------------------------------------------
// <copyright file="MailMasterInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    /// <summary>
    ///     Mail master information.
    /// </summary>
    public class MailMasterInfo
    {
        public int MailId { get; set; }
        public int MailingListId { get; set; }
        public string MailCode { get; set; }
        public string MailDesc { get; set; }
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public bool IsActive { get; set; }
    }
}