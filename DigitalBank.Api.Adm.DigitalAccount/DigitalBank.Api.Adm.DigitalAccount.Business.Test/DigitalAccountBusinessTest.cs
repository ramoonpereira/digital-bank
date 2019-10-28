using DigitalBank.Api.Adm.DigitalAccount.Business.Implementations;
using DigitalBank.Api.Adm.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Adm.DigitalAccount.Business.Repository;
using DigitalBank.Api.Adm.DigitalAccount.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Adm.DigitalAccount.Business.Test
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
