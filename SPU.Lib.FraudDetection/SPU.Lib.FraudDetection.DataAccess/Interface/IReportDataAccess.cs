using Fanex.Data.Repository;

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    public interface IReportDataAccess
    {
        object GetCustomerAndMatch(ICriteria criteria);
    }
}