using System;
using Example.Application;
using Example.Tests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Tests.Application
{
    [TestClass]
    public class MyAppServiceTests : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateItem_Null_Test()
        {
            // Arrange

            MyDataRepositoryStub repository = new MyDataRepositoryStub();
            IMyAppService appservice = new MyAppService(repository);

            // Act

            appservice.UpdateItem(null);

            // Assert
        }
    }
}
