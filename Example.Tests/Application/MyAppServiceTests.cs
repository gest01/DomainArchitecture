using System;
using Example.Application;
using Example.Application.DTO;
using Example.Domain;
using Example.Tests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Tests.Application
{
    [TestClass]
    public class MyAppServiceTests : TestBase
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateItem_ItemNotFound_Test()
        {
            // Arrange

            MyDataRepositoryStub repository = new MyDataRepositoryStub();
            DataDomainService dds = new DataDomainService(repository);
            IMyAppService appservice = new MyAppService(dds);

            MyDemoDTO mydto = new MyDemoDTO() { Id = 123323 };

            // Act

            appservice.UpdateItem(mydto);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateItem_Null_Test()
        {
            // Arrange

            MyDataRepositoryStub repository = new MyDataRepositoryStub();
            DataDomainService dds = new DataDomainService(repository);
            IMyAppService appservice = new MyAppService(dds);

            // Act

            appservice.UpdateItem(null);

            // Assert
        }
    }
}
