using AutoMapper;
using DigitalBank.Api.Adm.Authenticate.Business.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Controllers.v1;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Adm.Authenticate.Test.v1
{
    public class AuthenticateControllerTest
    {
        private AuthenticateController _controller;
        private Mock<IAuthenticateBusiness> _authenticateBusinessMock;
        private Mock<IMapper> _mapperMock;


        [SetUp]
        public void SetUp()
        {
            _authenticateBusinessMock = new Mock<IAuthenticateBusiness>();
            _mapperMock = new Mock<IMapper>();

            _controller = new AuthenticateController(_authenticateBusinessMock.Object, _mapperMock.Object);
        }
    }
}
