﻿using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Repository
{
    public class DigitalAccountTransactionRepository : IDigitalAccountTransactionRepository
    {
        private AppDbContext _appDbContext;
        public DigitalAccountTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DigitalAccountTransactionModel> InsertAsync(DigitalAccountTransactionModel digitalAccountTransaction)
        {
            var newDigitalAccountTransaction = await _appDbContext.DigitalAccountTransactions.AddAsync(digitalAccountTransaction);

            await _appDbContext.SaveChangesAsync();

            return newDigitalAccountTransaction.Entity;
        }

        public async Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate)
        {
            return await _appDbContext.DigitalAccountTransactions
                                   .Where(c => c.CreatedDate.Date >= startDate.Date &&
                                    c.CreatedDate.Date <= endDate.Date).ToListAsync();
        }

        public async Task<List<DigitalAccountTransactionModel>> GetTransactionsEffectedByDateAsync(int digitalAccountId, DateTime date)
        {
            return await _appDbContext.DigitalAccountTransactions
                                      .Where(c => c.Status == TransactionStatusEnum.Effected &&
                                       c.CreatedDate.Date == date.Date).ToListAsync();
        }

        public Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccountTransactions.Where(c => c.Id.Equals(transactionId)).FirstOrDefault();
            });
        }
    }
}