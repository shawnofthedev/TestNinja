using Shouldly;
using Xunit;
using TestNinja.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestNinja.Tests
{
    public class ReservationTests
    {
        [Fact]
        public async void CanBeCancelledBy_UserIsAdmin_ShouldReturnTrue()
        {
            var reservation = new ReservationController();
            var result = await reservation.CanBeCancelledBy(new User { IsAdmin = true });
            result.ShouldBeOfType<OkResult>();
        }

        [Fact]
        public async void CanBeCancelledBy_AnotherUSerCancellingReservation_ReturnsFalse()
        {
            var reservation = new ReservationController { MadeBy = new User() };
            var result = await reservation.CanBeCancelledBy(new User());
            result.ShouldBeOfType<BadRequestResult>();
        }

        [Fact]
        public async void CanBeCancelledBy_UserMadeBy_ReturnsTrue()
        {
            var user = new User();
            var reservation = new ReservationController { MadeBy = user };
            var result = await reservation.CanBeCancelledBy(user);
            result.ShouldBeOfType<OkResult>();
        }
    }
}