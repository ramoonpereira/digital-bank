using DigitalBank.Api.Pub.Transaction.Business.Implementations;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using Moq;
using NUnit.Framework;

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
    }
}
