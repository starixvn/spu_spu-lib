// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerReportNoteModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.12.09">Created</change>
// </history>

namespace FD.Lib.Model.Reports.SuspiciousCustomer
{
    using System;

    /// <summary>
    /// The class SuspiciousCustomerReportNoteModel.
    /// </summary>
    public class SuspiciousCustomerReportNoteModel
    {
        public string DateString
        {
            get
            {
                return Date.ToString("MM/dd/yyyy");
            }
        }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int AuthorId { get; set; }

        public string Type { get; set; }
    }
}
