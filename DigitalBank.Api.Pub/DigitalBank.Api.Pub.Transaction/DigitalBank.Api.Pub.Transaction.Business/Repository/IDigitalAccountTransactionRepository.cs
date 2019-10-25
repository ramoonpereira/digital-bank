using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Repository
{
    public interface IDigitalAccountTransactionRepository
    {
        Task<DigitalAccountTransactionModel> InsertAsync(DigitalAccountTransactionModel digitalAccountTransaction);

        Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(DateTime startDate, DateTime endDate);

        Task<List<DigitalAccountTransactionModel>> GetTransactionsByDateAsync(DateTime date);
    }
}
