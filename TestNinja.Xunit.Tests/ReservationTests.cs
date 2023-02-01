using Shouldly;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.Tests
{
    public class ReservationTests
    {
        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ShouldReturnTrue()
        {
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            result.ShouldBeTrue();
        }

        [Fact]
        public void CanBeCancelledBy_AnotherUSerCancellingReservation_ReturnsFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };
            var result = reservation.CanBeCancelledBy(new User());
            result.ShouldBeFalse();
        }

        [Fact]
        public void CanBeCancelledBy_UserMadeBy_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };
            var result = reservation.CanBeCancelledBy(user);
            result.ShouldBeTrue();
        }
    }
}