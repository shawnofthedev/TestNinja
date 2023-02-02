﻿using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin= true });

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            
            var reservation = new Reservation { MadeBy = new User()};

            var result = reservation.CanBeCancelledBy(new User());

            Assert.That(result, Is.False);
        }

        [Test]
        public void CanBeCancelledBy_UserMadeBy_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user};
            var result = reservation.CanBeCancelledBy(user);

            Assert.That(result, Is.True);
        }
    }
}
