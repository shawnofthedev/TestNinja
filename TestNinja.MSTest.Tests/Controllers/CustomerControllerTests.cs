using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace TestNinja.Api.Controllers.Tests
{
    [TestClass()]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;

        public CustomerControllerTests()
        {
            _customerController = new CustomerController();
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(-1)]
        public void GetCustomerTest(int value)
        {
            var result = _customerController.GetCustomer(value);
            result.ShouldBeOfType<NotFoundResult>();
        }

        [TestMethod()]
        public void GetCustomer_IdNotZero_ShouldReturnOk()
        {
            var result = _customerController.GetCustomer(1);
            result.ShouldBeOfType<OkResult>();
        }
    }
}