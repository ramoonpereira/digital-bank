using DigitalBank.Api.Adm.Authenticate.Business.Implementations;
using DigitalBank.Api.Adm.Authenticate.Business.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Adm.Authenticate.Business.Test
{
    public class PermissionBusinessTest
    {
        private PermissionBusiness _permissionBusiness;
        private Mock<IPermissionRepository> _permissionRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _permissionRepositoryMock = new Mock<IPermissionRepository>();

            _permissionBusiness = new PermissionBusiness(
                _permissionRepositoryMock.Object);
        }
    }
}
