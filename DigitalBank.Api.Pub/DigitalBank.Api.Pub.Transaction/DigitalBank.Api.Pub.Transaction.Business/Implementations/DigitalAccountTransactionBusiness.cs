using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Handler.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Implementations
{
    public class DigitalAccountTransactionBusiness : IDigitalAccountTransactionBusiness
    {
        private IDigitalAccountTransactionRepository _digitalAccountTransactionRepository;
        private IDigitalAccountBusiness _digitalAccounBusiness;
        private ITokenHandler _tokenHandler;
        private JwtSecurityToken _token;

        public DigitalAccountTransactionBusiness(IDigitalAccountTransactionRepository digitalAccountTransactionRepository, IDigitalAccountBusiness digitalAccounBusiness,
                                                 ITokenHandler tokenHandler)
        {
            _digitalAccountTransactionRepository = digitalAccountTransactionRepository;
            _digitalAccounBusiness = digitalAccounBusiness;
            _tokenHandler = tokenHandler;
        }
        public async Task Authorize(string accessToken)
        {
            _token = await _tokenHandler.DecodeJwtToken(accessToken);
        }

        public async Task<DigitalAccountTransactionModel> CreateTransactionDepositAsync(DigitalAccountTransactionModel transaction)
        {
            if (transaction.DigitalAccountSenderId != null)
                await ProcessCustomerSenderDepositTransactionAsync(transaction);

            DigitalAccountModel digitalAccount = await _digitalAccounBusiness.GetByIdAsync(transaction.DigitalAccountId);

            transaction = await CreateTransactionAsync(transaction, TransactionTypeEnum.Input,
           TransactionOperationEnum.Deposit, transaction.DigitalAccountSenderId);

            return transaction;
        }

        private async Task<DigitalAccountTransactionModel> ProcessCustomerSenderDepositTransactionAsync(DigitalAccountTransactionModel transaction)
        {
            DigitalAccountTransactionModel transactionSender = await ProcessCustomerSenderTransactionAsync(transaction, TransactionOperationEnum.Deposit);

            return transactionSender;
        }

        public async Task<DigitalAccountTransactionModel> CreateTransactionTransferAsync(DigitalAccountTransactionModel transaction)
        {
            if (transaction.DigitalAccountSenderId != null)
                await ProcessCustomerSenderTransferTransactionAsync(transaction);

            DigitalAccountModel digitalAccount = await _digitalAccounBusiness.GetByIdAsync(transaction.DigitalAccountId);

            transaction = await CreateTransactionAsync(transaction, TransactionTypeEnum.Input,
            TransactionOperationEnum.Transfer, transaction.DigitalAccountSenderId);

            return transaction;
        }

        private async Task<DigitalAccountTransactionModel> ProcessCustomerSenderTransferTransactionAsync(DigitalAccountTransactionModel transaction)
        {
            await ValidRequestCustomerIdWithCustomerTokenAsync(transaction.DigitalAccountSenderId.Value);

            DigitalAccountTransactionModel transactionSender = await ProcessCustomerSenderTransactionAsync(transaction, TransactionOperationEnum.Transfer);

            return transactionSender;
        }

        private async Task<DigitalAccountTransactionModel> ProcessCustomerSenderTransactionAsync(DigitalAccountTransactionModel transaction,
                                                                                                 TransactionOperationEnum operation)
        {
            await ValidTransactionIfCustomerSenderAndRecipientEqualsAsync(transaction.DigitalAccountSenderId.Value, transaction.DigitalAccountId);

            DigitalAccountModel digitalAccountSender = await _digitalAccounBusiness.GetByIdAsync(transaction.DigitalAccountSenderId.Value);

            await CheckExceededDigitalAccountDailyLimitTransctionAsync(transaction.DigitalAccountSenderId.Value, transaction.Value, digitalAccountSender);

            DigitalAccountTransactionModel transactionSender = await CreateTransactionAsync(transaction, TransactionTypeEnum.Output,
               operation, transaction.DigitalAccountSenderId.Value);

            return transactionSender;
        }

        private async Task<DigitalAccountTransactionModel> CreateTransactionAsync(DigitalAccountTransactionModel transaction, TransactionTypeEnum type,
                                                                                  TransactionOperationEnum operation, int? customerSenderId)
        {
            transaction.DigitalAccountSenderId = customerSenderId;
            transaction.Type = type;
            transaction.Operation = operation;
            transaction.Status = TransactionStatusEnum.Pending;

            transaction = await InsertAsync(transaction);

            return transaction;
        }

        private Task ValidTransactionIfCustomerSenderAndRecipientEqualsAsync(int customerSenderId, int customerRecipientId)
        {
            return Task.Run(() =>
            {
                if (customerSenderId == customerRecipientId)
                    throw new ArgumentException("Não é possivel realizar este tipo de transação com os dados informados");
            });
        }

        //private Task ValidRequestCustomerIdWithCustomerTokenAsync(int customerId)
        //{
        //    return Task.Run(() =>
        //    {
        //        int customerTokenId;

        //        Int32.TryParse(_token.Claims.Where(x => x.Type.Equals("Id")).FirstOrDefault().Value, out customerTokenId);

        //        if (customerTokenId == 0 || customerTokenId != customerId)
        //            throw new KeyNotFoundException("Conta não localizada");
        //    });
        //}

        private async Task CheckExceededDigitalAccountDailyLimitTransctionAsync(int digitalAccountId, decimal transactionValue, DigitalAccountModel digitalAccount)
        {
            List<DigitalAccountTransactionModel> transactions =
                await _digitalAccountTransactionRepository.GetTransactionsEffectedByDateAsync(digitalAccountId, DateTime.Now);

            decimal transactionsValue = transactions.Sum(t => t.Value);

            if ((digitalAccount.TransferLimitTransactionDay - transactionsValue) < transactionValue)
                throw new ArgumentException("Nao foi possivel efetuar a transação, limite de transações diária da conta excedida");
        }

        public async Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId)
        {
            DigitalAccountTransactionModel transaction = await _digitalAccountTransactionRepository.GetByIdAsync(transactionId);

            if (transaction == null)
                throw new KeyNotFoundException("Transação não localizada");

            return transaction;
        }

        public async Task<DigitalAccountTransactionModel> InsertAsync(DigitalAccountTransactionModel digitalAccountTransaction)
        {
            return await _digitalAccountTransactionRepository.InsertAsync(digitalAccountTransaction);
        }

        public async Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
                startDate = DateTime.Now.AddDays(-30);

            if (endDate == null)
                endDate = DateTime.Now;

            return await _digitalAccountTransactionRepository.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate.Value, endDate.Value);
        }
    }
}
