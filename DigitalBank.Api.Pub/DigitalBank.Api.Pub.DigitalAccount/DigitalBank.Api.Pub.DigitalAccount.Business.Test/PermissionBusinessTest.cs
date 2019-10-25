using DigitalBank.Api.Pub.DigitalAccount.Business.Implementations;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Test
{
    public class PermissionBusinessTest
    {
        private PermissionBusiness _permissionBusiness;
        private Mock<IPermissionRepository> _permissionRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _permissionRepositoryMock = new Mock<IPermissionRepository>();

            _permissionBusiness = new PermissionBusiness(_permissionRepositoryMock.Object);
        }
    }
}
