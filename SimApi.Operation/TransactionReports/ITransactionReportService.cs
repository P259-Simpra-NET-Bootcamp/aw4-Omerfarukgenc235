using SimApi.Base;
using SimApi.Schema;

namespace SimApi.Operation.TransactionReports;

public interface ITransactionReportService
{
    ApiResponse<List<TransactionViewResponse>> GetAll();
    ApiResponse<TransactionViewResponse> GetById(int id);
    ApiResponse<List<TransactionViewResponse>> GetByReferenceNumber(string referenceNumber);
    ApiResponse<List<TransactionViewResponse>> GetByCustomerId(int customerId);
    ApiResponse<List<TransactionViewResponse>> GetByAccountId(int accountId);
}
