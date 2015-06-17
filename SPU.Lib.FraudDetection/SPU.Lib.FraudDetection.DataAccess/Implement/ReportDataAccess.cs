using System;
using Fanex.Data.Repository;
using SPU.Lib.FraudDetection.DataAccess.Interface;

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    class ReportDataAccess : BaseDataAccess, IReportDataAccess
    {
        public object GetCustomerAndMatch(ICriteria criteria)
        {
            throw  new NotImplementedException();
        }
    }
}