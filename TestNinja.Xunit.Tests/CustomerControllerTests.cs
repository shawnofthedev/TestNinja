using Xunit;
using System;
using Shouldly;
using TestNinja.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestNinja.Tests
{
    
    public class CustomerControllerTests : IDisposable
    {
        private CustomerController _controller;

        public CustomerControllerTests()
        {
            _controller= new CustomerController();
        }

        public void Dispose()
        {
            _controller.Equals(null);
        }

        [Fact]
        public void GetCustomer_IdIsZero_ShouldReturnNotFound()
        {
            var result = _controller.GetCustomer(0);
            result.ShouldBeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetCustomer_IdIsNotZero_ShouldReturnOk()
        {
            var result = _controller.GetCustomer(1);
            result.ShouldBeOfType<OkResult>();
        }
    }
}
