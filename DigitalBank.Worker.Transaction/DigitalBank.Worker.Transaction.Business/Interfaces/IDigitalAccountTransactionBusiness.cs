using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Business.Interfaces
{
    public interface IDigitalAccountTransactionBusiness
    {
        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);
        Task<DigitalAccountTransactionModel> UpdateAsync(DigitalAccountTransactionModel digitalAccountTransaction);
        Task<DigitalAccountTransactionModel> UpdateStatusAsync(DigitalAccountTransactionModel digitalAccountTransaction, TransactionStatusEnum status);
        Task ConsistQueueAsync(int transactionId);
    }
}
