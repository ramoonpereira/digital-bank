using DigitalBank.Worker.Transaction.Business.Implementations;
using DigitalBank.Worker.Transaction.Business.Repository;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Worker.Transaction.Business.Test
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
