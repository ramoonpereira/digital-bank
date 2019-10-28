using AutoMapper;
using DigitalBank.Api.Adm.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Adm.DigitalAccount.Controllers.v1;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Adm.DigitalAccount.Test.v1
{
    public class DigitalAccountControllerTest
    {
        private DigitalAccountController _controller;
        private Mock<IDigitalAccountBusiness> _digitalAccountBusinessMock;
        private Mock<IMapper> _mapperMock;


        [SetUp]
        public void SetUp()
        {
            _digitalAccountBusinessMock = new Mock<IDigitalAccountBusiness>();
            _mapperMock = new Mock<IMapper>();

            _controller = new DigitalAccountController(_digitalAccountBusinessMock.Object, _mapperMock.Object);
        }
    }
}
