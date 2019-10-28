using DigitalBank.Api.Pub.Authenticate.Business.Implementations;
using DigitalBank.Api.Pub.Authenticate.Business.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Pub.Authenticate.Business.Test
{
    public class CustomerBusinessTest
    {
        private CustomerBusiness _customerBusiness;
        private Mock<ICustomerRepository> _customerRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            _customerBusiness = new CustomerBusiness(
                _customerRepositoryMock.Object);
        }
    }
}
