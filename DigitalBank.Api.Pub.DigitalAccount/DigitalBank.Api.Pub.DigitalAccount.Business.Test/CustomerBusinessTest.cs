using DigitalBank.Api.Pub.DigitalAccount.Business.Implementations;
using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Security.Encryptor.Handler.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Test
{
    public class CustomerBusinessTest
    {
        private CustomerBusiness _customerBusiness;
        private Mock<ICustomerPermissionBusiness> _customerPermissionBusinessMock;
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private Mock<IEncryptorHandler> _encryptorHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerPermissionBusinessMock = new Mock<ICustomerPermissionBusiness>();
            _encryptorHandlerMock = new Mock<IEncryptorHandler>();

            _customerBusiness = new CustomerBusiness(
                _customerRepositoryMock.Object,
                _customerPermissionBusinessMock.Object,
                _encryptorHandlerMock.Object);
        }
    }
}
