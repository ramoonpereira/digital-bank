using DigitalBank.Worker.Transaction.Business.Interfaces;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using DigitalBank.Worker.Transaction.Business.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Business.Implementations
{
    public class DigitalAccountTransactionBusiness : IDigitalAccountTransactionBusiness
    {
        private IDigitalAccountTransactionRepository _digitalAccountTransactionRepository;
        private IDigitalAccountBusiness _digitalAccounBusiness;
        private IConfiguration _configuration;

        public DigitalAccountTransactionBusiness(IDigitalAccountTransactionRepository digitalAccountTransactionRepository, IDigitalAccountBusiness digitalAccounBusiness,
                                                 IConfiguration configuration)
        {
            _digitalAccountTransactionRepository = digitalAccountTransactionRepository;
            _digitalAccounBusiness = digitalAccounBusiness;
            _configuration = configuration;
        }

        public async Task ConsistQueueAsync(int transactionId)
        {
            DigitalAccountTransactionModel transaction = await _digitalAccountTransactionRepository.GetByIdAsync(transactionId);

            bool limitAttemptExceeded = false;

            if (transaction.DigitalAccountSenderId.HasValue)
                limitAttemptExceeded = await CheckExceededLimitAttemptToIntervalTransactionAsync(transaction.DigitalAccountSenderId.Value);

            if (transaction.DigitalAccountSenderId.HasValue && limitAttemptExceeded)
                await GenerateRollbackTransation(transaction);
            else
                await EffectedTransation(transaction);
        }

        private async Task GenerateRollbackTransation(DigitalAccountTransactionModel transaction)
        {
            await UpdateStatusAsync(transaction, TransactionStatusEnum.Denied);
        }

        private async Task EffectedTransation(DigitalAccountTransactionModel transaction)
        {
            DigitalAccountModel digitalAccount = await _digitalAccounBusiness.GetByIdAsync(transaction.DigitalAccountId);

            digitalAccount.Balance = transaction.Type == TransactionTypeEnum.Output ?
                (digitalAccount.Balance - transaction.Value) : (digitalAccount.Balance + transaction.Value);

            await _digitalAccounBusiness.UpdateAsync(digitalAccount);

            await UpdateStatusAsync(transaction, TransactionStatusEnum.Effected);
        }

        private async Task<bool> CheckExceededLimitAttemptToIntervalTransactionAsync(int digitalAccountId)
        {
            int intervalAttempt;
            int retryAttempt;

            Int32.TryParse(_configuration["Transaction:INTERVAL_ATTEMPT_TRANSACTION"], out intervalAttempt);
            Int32.TryParse(_configuration["Transaction:RETRY_ATTEMPT_TRANSACTION"], out retryAttempt);

            var startDate = DateTime.Now.AddMinutes(intervalAttempt);
            var endDate = DateTime.Now;

            List<DigitalAccountTransactionModel> transactions =
                await _digitalAccountTransactionRepository.GetTransactionsPendingOrEffectedByPeriodAsync(digitalAccountId, startDate, endDate);

            if (transactions.Count >= retryAttempt)
                return true;

            return false;
        }

        public async Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId)
        {
            DigitalAccountTransactionModel transaction = await _digitalAccountTransactionRepository.GetByIdAsync(transactionId);

            return transaction;
        }

        public async Task<DigitalAccountTransactionModel> UpdateStatusAsync(DigitalAccountTransactionModel digitalAccountTransaction, TransactionStatusEnum status)
        {
            digitalAccountTransaction.Status = status;
            digitalAccountTransaction.ReleaseDate = DateTime.Now;
            return await _digitalAccountTransactionRepository.UpdateAsync(digitalAccountTransaction);
        }

        public async Task<DigitalAccountTransactionModel> UpdateAsync(DigitalAccountTransactionModel digitalAccountTransaction)
        {
            return await _digitalAccountTransactionRepository.UpdateAsync(digitalAccountTransaction);
        }
    }
}
