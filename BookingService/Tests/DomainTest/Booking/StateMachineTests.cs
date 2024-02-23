using Domain.Entities;
using Domain.Enums;

namespace DomainTest.Bookings
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShoulStartWhitCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Pay);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelForABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Cancel);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Canceled));
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishForABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Pay);
            booking.ChangeState(Domain.Enums.Action.Finish);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Finished));
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundForABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Pay);
            booking.ChangeState(Domain.Enums.Action.Refound);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopenForABookingWithCanceledStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Cancel);
            booking.ChangeState(Domain.Enums.Action.Reopen);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }

        [Test]
        public void ShouldNotChangeStatusWhenRefoundForABookingWithStatusDiferentOfPaid()
        {
            var bookingRefound = new Booking();
            bookingRefound.ChangeState(Domain.Enums.Action.Refound);
            Assert.That(bookingRefound.CurrentStatus, !Is.EqualTo(Status.Refounded));
            bookingRefound.ChangeState(Domain.Enums.Action.Cancel);
            bookingRefound.ChangeState(Domain.Enums.Action.Refound);
            Assert.That(bookingRefound.CurrentStatus, !Is.EqualTo(Status.Refounded));
            bookingRefound.ChangeState(Domain.Enums.Action.Reopen);
            bookingRefound.ChangeState(Domain.Enums.Action.Refound);
            Assert.That(bookingRefound.CurrentStatus, !Is.EqualTo(Status.Refounded));
            bookingRefound.ChangeState(Domain.Enums.Action.Pay);
            bookingRefound.ChangeState(Domain.Enums.Action.Finish);
            bookingRefound.ChangeState(Domain.Enums.Action.Refound);
            Assert.That(bookingRefound.CurrentStatus, !Is.EqualTo(Status.Refounded));
        }
    }
}