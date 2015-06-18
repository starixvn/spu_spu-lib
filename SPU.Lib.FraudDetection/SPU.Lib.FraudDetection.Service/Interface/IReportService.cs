using System;
using System.Collections.Generic;
using SPU.Lib.FraudDetection.DataAccess.Interface;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;

namespace SPU.Lib.FraudDetection.Service.Interface
{
    public interface IReportService
    {
        SuspiciousStatisticViewModel GetSuspiciousCustomerStatistics(IList<SuspiciousInfo> list);
    }
}