// --------------------------------------------------------------------------
// <copyright file="LogsNotes.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DTO.CustomerDetails
{
    using System;

    public class LogsNotes
    {
        public int CustomerLogId { get; set; }

        public DateTime LogDate { get; set; }

        public string LogDesc { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string CustLogTypeName { get; set; }

        public string LogDateString
        {
            get
            {
                return LogDate.ToString("MM/dd/yyyy");
            }
        }
    }
}