using DigitalBank.Api.Pub.Transaction.Business.Implementations;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DigitalBank.Api.Pub.Transaction.Business.Test
{
    public class DigitalAccountBusinessTest
    {
        private DigitalAccountBusiness _digitalAccountBusiness;
        private Mock<IDigitalAccountRepository> _digitalAccountRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountRepositoryMock = new Mock<IDigitalAccountRepository>();

            _digitalAccountBusiness = new DigitalAccountBusiness(_digitalAccountRepositoryMock.Object);
        }


        [TestCase(999)]
        [TestCase(99)]
        [TestCase(0)]
        public void GetById_Error_NotFoundException(int id)
        {
            _digitalAccountRepositoryMock.Setup(repository =>
                     repository.GetByIdAsync(id)).ReturnsAsync(() => null);

            KeyNotFoundException exception = Assert.ThrowsAsync<KeyNotFoundException>(async () => await _digitalAccountBusiness.GetByIdAsync(id));

            Assert.AreEqual("Conta não localizada", exception.Message);

            _digitalAccountRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetById_Success_ReturnDigitalAccount(int id)
        {
            DigitalAccountModel digitalAccount = new DigitalAccountModel() {
                Id = id,
                Balance = 100m,
                Number = 1234 + id,
                Digit = 'X',
                CreatedDate = DateTime.Now
            };

            _digitalAccountRepositoryMock.Setup(repository =>
         repository.GetByIdAsync(id)).ReturnsAsync(() => digitalAccount);

            DigitalAccountModel result = _digitalAccountBusiness.GetByIdAsync(id).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(id,result.Id);

            _digitalAccountRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }
    }
}
