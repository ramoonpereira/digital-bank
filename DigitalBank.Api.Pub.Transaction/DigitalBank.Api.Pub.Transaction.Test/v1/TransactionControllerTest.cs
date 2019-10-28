using AutoMapper;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Controllers.v1;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Pub.Transaction.Test.v1
{
    public class TransactionControllerTest
    {
        private TransactionController _controller;
        private Mock<IDigitalAccountTransactionBusiness> _digitalAccountTransactionBusinessMock;
        private Mock<IMapper> _mapperMock;


        [SetUp]
        public void SetUp()
        {
            _digitalAccountTransactionBusinessMock = new Mock<IDigitalAccountTransactionBusiness>();
            _mapperMock = new Mock<IMapper>();

            _controller = new TransactionController(_digitalAccountTransactionBusinessMock.Object, _mapperMock.Object);
        }
    }
}
