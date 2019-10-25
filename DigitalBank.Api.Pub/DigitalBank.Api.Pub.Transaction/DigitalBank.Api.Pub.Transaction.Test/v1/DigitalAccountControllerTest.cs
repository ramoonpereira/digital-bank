using AutoMapper;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Controllers.v1;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Pub.Transaction.Test.v1
{
    public class DigitalAccountControllerTest
    {
        private DigitalAccountController _controller;
        private Mock<IDigitalAccountBusiness> _authenticateBusinessMock;
        private Mock<IMapper> _mapperMock;


        [SetUp]
        public void SetUp()
        {
            _authenticateBusinessMock = new Mock<IDigitalAccountBusiness>();
            _mapperMock = new Mock<IMapper>();

            _controller = new DigitalAccountController(_authenticateBusinessMock.Object, _mapperMock.Object);
        }
    }
}
