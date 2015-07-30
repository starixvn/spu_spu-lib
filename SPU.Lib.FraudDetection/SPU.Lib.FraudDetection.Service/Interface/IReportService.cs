// --------------------------------------------------------------------------
// <copyright file="IReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Model.ReportTemplate;

    public interface IReportService
    {
        SuspiciousStatisticViewModel GetSuspiciousCustomerStatistics(IList<SuspiciousInfo> list);
    }
}