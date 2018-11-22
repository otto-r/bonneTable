using AutoFixture;
using bonneTable.Services.Interfaces;
using bonneTable.Services.Services;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace bonneTable.Tests
{
    public class BookingServiceTests
    {
        private Fixture _fixture;
        private IMock<IBookingRepository> _repository;

        public BookingServiceTests()
        {
            _fixture = new Fixture();
            _repository = new Mock<IBookingRepository>();
        }

        [Fact]
        public async void ClientBookTable_WithValidValues_ReturnsSuccessViewModel()
        {
            var bookingService = new BookingService(_repository.Object);
            var bookingRequest = _fixture.Build<BookingRequestModel>()
                .With(b => b.Seats, 2)
                .With(b => b.Email, "wow@wow.se")
                .With(b => b.CustomerName, "Coolguy")
                .With(b => b.Time, DateTime.Now.AddHours(2))
                .With(b => b.PhoneNumber, "3758374").Create();

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeTrue();
        }

        [Fact]
        public async void ClientBookTable_WithNegativeSeats_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository.Object);
            var bookingRequest = _fixture.Build<BookingRequestModel>()
                .With(b => b.Seats, -2)
                .With(b => b.Email, "wow@wow.se")
                .With(b => b.CustomerName, "Coolguy")
                .With(b => b.Time, DateTime.Now.AddHours(2))
                .With(b => b.PhoneNumber, "3758374").Create();

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithTooManySeats_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository.Object);
            var bookingRequest = _fixture.Build<BookingRequestModel>()
                .With(b => b.Seats, 7)
                .With(b => b.Email, "wow@wow.se")
                .With(b => b.CustomerName, "Coolguy")
                .With(b => b.Time, DateTime.Now.AddHours(2))
                .With(b => b.PhoneNumber, "3758374").Create();

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithEmptyName_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository.Object);
            var bookingRequest = _fixture.Build<BookingRequestModel>()
                .With(b => b.Seats, 2)
                .With(b => b.Email, "wow@wow.se")
                .With(b => b.CustomerName, "")
                .With(b => b.Time, DateTime.Now.AddHours(2))
                .With(b => b.PhoneNumber, "3758374").Create();

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithBadTime_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository.Object);
            var bookingRequest = _fixture.Build<BookingRequestModel>()
                .With(b => b.Seats, 2)
                .With(b => b.Email, "wow@wow.se")
                .With(b => b.CustomerName, "Coolguy")
                .With(b => b.Time, DateTime.Now.AddHours(-2))
                .With(b => b.PhoneNumber, "3758374").Create();

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }
    }
}
