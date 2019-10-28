using DigitalBank.Api.Pub.DigitalAccount.Business.Implementations;
using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Test
{
    public class CustomerPermissionBusinessTest
    {
        private CustomerPermissionBusiness _customerPermissionBusiness;
        private Mock<IPermissionBusiness> _permissionBusinessMock;
        private Mock<ICustomerPermissionRepository> _customerPermissionRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _customerPermissionRepositoryMock = new Mock<ICustomerPermissionRepository>();
            _permissionBusinessMock = new Mock<IPermissionBusiness>();

            _customerPermissionBusiness = new CustomerPermissionBusiness(
                _customerPermissionRepositoryMock.Object,
                _permissionBusinessMock.Object);
        }
    }
}
