using DigitalBank.Api.Adm.Authenticate.Business.Implementations;
using DigitalBank.Api.Adm.Authenticate.Business.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Adm.Authenticate.Business.Test
{
    public class AdministratorBusinessTest
    {
        private AdministratorBusiness _administratorBusiness;
        private Mock<IAdministratorRepository> _administratorRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _administratorRepositoryMock = new Mock<IAdministratorRepository>();

            _administratorBusiness = new AdministratorBusiness(
                _administratorRepositoryMock.Object);
        }
    }
}
