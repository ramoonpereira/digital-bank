using DigitalBank.Api.Pub.Transaction.Business.Implementations;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using DigitalBank.Api.Pub.Transaction.Business.Pagination;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Handler.Interfaces;
using MassTransit;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DigitalBank.Api.Pub.Transaction.Business.Test
{
    public class DigitalAccountTransactionBusinessTest
    {
        private DigitalAccountTransactionBusiness _digitalAccountTransactionBusiness;
        private Mock<IDigitalAccountTransactionRepository> _digitalAccountTransactionRepositoryMock;
        private Mock<ITokenHandler> _tokenHandlerMock;
        private Mock<IDigitalAccountBusiness> _digitalAccountBusinessMock;
        private Mock<IBusControl> _busMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountTransactionRepositoryMock = new Mock<IDigitalAccountTransactionRepository>();
            _digitalAccountBusinessMock = new Mock<IDigitalAccountBusiness>();
            _tokenHandlerMock = new Mock<ITokenHandler>();
            _busMock = new Mock<IBusControl>();

            _digitalAccountTransactionBusiness = new DigitalAccountTransactionBusiness(_digitalAccountTransactionRepositoryMock.Object,
                _digitalAccountBusinessMock.Object, _tokenHandlerMock.Object, _busMock.Object);
        }

        [Test]
        public void Insert_Success()
        {
            DigitalAccountTransactionModel digitalAccountTransaction = new DigitalAccountTransactionModel()
            {
                Operation = TransactionOperationEnum.Deposit,
                Type = TransactionTypeEnum.Input,
                DigitalAccountId = 1,
                DigitalAccountSenderId = 2,
                Status = TransactionStatusEnum.Pending,
                Value = 100m,
            };

            DigitalAccountTransactionModel digitalAccountTransactionResult = new DigitalAccountTransactionModel()
            {
                Id = 1,
                Operation = TransactionOperationEnum.Deposit,
                Type = TransactionTypeEnum.Input,
                DigitalAccountId = 1,
                DigitalAccountSenderId = 2,
                Status = TransactionStatusEnum.Pending,
                Value = 100m,
                CreatedDate = DateTime.Now
            };

            _digitalAccountTransactionRepositoryMock.Setup(repository =>
         repository.InsertAsync(digitalAccountTransaction)).ReturnsAsync(() => digitalAccountTransactionResult);

            DigitalAccountTransactionModel result = _digitalAccountTransactionBusiness.InsertAsync(digitalAccountTransaction).Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Id);
            Assert.IsNotNull(result.CreatedDate);
            Assert.NotZero(result.Id);

            _digitalAccountTransactionRepositoryMock.Verify(x => x.InsertAsync(digitalAccountTransaction), Times.Once);
        }

        [TestCase(999)]
        [TestCase(99)]
        [TestCase(0)]
        public void GetById_Error_NotFoundException(int id)
        {
            _digitalAccountTransactionRepositoryMock.Setup(repository =>
                     repository.GetByIdAsync(id)).ReturnsAsync(() => null);

            KeyNotFoundException exception = Assert.ThrowsAsync<KeyNotFoundException>(async () => await _digitalAccountTransactionBusiness.GetByIdAsync(id));

            Assert.AreEqual("Transação não localizada", exception.Message);

            _digitalAccountTransactionRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetById_Success_ReturnDigitalAccountTransaction(int id)
        {
            DigitalAccountTransactionModel digitalAccountTransactionResult = new DigitalAccountTransactionModel()
            {
                Id = id,
                Operation = TransactionOperationEnum.Deposit,
                Type = TransactionTypeEnum.Input,
                DigitalAccountId = 1,
                DigitalAccountSenderId = 2,
                Status = TransactionStatusEnum.Pending,
                Value = 100m,
                CreatedDate = DateTime.Now
            };

            _digitalAccountTransactionRepositoryMock.Setup(repository =>
         repository.GetByIdAsync(id)).ReturnsAsync(() => digitalAccountTransactionResult);

            DigitalAccountTransactionModel result = _digitalAccountTransactionBusiness.GetByIdAsync(id).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);

            _digitalAccountTransactionRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }

        [TestCase(1,"2019-10-28", "2019-10-28",1,10)]
        [TestCase(2, "2019-10-28", "2019-09-28", 1, 10)]
        [TestCase(3, "2019-10-28", "2019-08-28", 1, 10)]
        public void GetAllTransactionsByPeriod_Success_ReturnDigitalAccountTransactions(int digitalAccountId, DateTime startDate, DateTime endDate,
                                                                                        int page, int pageSize)
        {
            PagedResultBase<DigitalAccountTransactionModel> digitalAccountTransactionsResult = new PagedResultBase<DigitalAccountTransactionModel>()
            {
                PageSize = pageSize,
                CurrentPage = page,
                TotalItems = 1,
                TotalPages = 1,
                Result = new List<DigitalAccountTransactionModel>() {
                                new DigitalAccountTransactionModel(){
                                        Id = 1,
                                        Operation = TransactionOperationEnum.Deposit,
                                        Type = TransactionTypeEnum.Input,
                                        DigitalAccountId = digitalAccountId,
                                        DigitalAccountSenderId = 2,
                                        Status = TransactionStatusEnum.Pending,
                                        Value = 100m,
                                        CreatedDate = startDate.AddDays(1)
                                }
                }
            };

            _digitalAccountTransactionRepositoryMock.Setup(repository =>
         repository.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize)).ReturnsAsync(() => digitalAccountTransactionsResult);

            PagedResultBase<DigitalAccountTransactionModel> result = 
                _digitalAccountTransactionBusiness.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize).Result;

            Assert.IsNotNull(result);
            Assert.NotZero(result.TotalItems);
            Assert.IsNotEmpty(result.Result);

            _digitalAccountTransactionRepositoryMock.Verify(x => x.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize), Times.Once);
        }

        [TestCase(99, "1999-10-28", "1999-10-28", 1, 10)]
        [TestCase(99, "1999-10-28", "1999-09-28", 1, 10)]
        [TestCase(99, "1999-10-28", "1999-08-28", 1, 10)]
        public void GetAllTransactionsByPeriod_EmptyResults_NoReturnDigitalAccountTransactionss(int digitalAccountId, DateTime startDate, DateTime endDate,
                                                                                                int page, int pageSize)
        {
            PagedResultBase<DigitalAccountTransactionModel> digitalAccountTransactionsResult = new PagedResultBase<DigitalAccountTransactionModel>()
            {
                PageSize = pageSize,
                CurrentPage = page,
                TotalItems = 0,
                TotalPages = 0,
                Result = new List<DigitalAccountTransactionModel>()
            };

            _digitalAccountTransactionRepositoryMock.Setup(repository =>
         repository.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize)).ReturnsAsync(() => digitalAccountTransactionsResult);

            PagedResultBase<DigitalAccountTransactionModel> result =
                _digitalAccountTransactionBusiness.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize).Result;

            Assert.IsNotNull(result);
            Assert.Zero(result.TotalItems);
            Assert.IsEmpty(result.Result);

            _digitalAccountTransactionRepositoryMock.Verify(x => x.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize), Times.Once);
        }
    }
}
