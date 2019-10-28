using DigitalBank.Api.Adm.Transaction.Business.Implementations;
using DigitalBank.Api.Adm.Transaction.Business.Interfaces;
using DigitalBank.Api.Adm.Transaction.Business.Repository;
using DigitalBank.Api.Adm.Transaction.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Adm.Transaction.Business.Test
{
    public class DigitalAccountTransactionBusinessTest
    {
        private DigitalAccountTransactionBusiness _digitalAccountTransactionBusiness;
        private Mock<IDigitalAccountTransactionRepository> _digitalAccountTransactionRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountTransactionRepositoryMock = new Mock<IDigitalAccountTransactionRepository>();

            _digitalAccountTransactionBusiness = new DigitalAccountTransactionBusiness(_digitalAccountTransactionRepositoryMock.Object);
        }
    }
}
