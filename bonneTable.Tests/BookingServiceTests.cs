using AutoFixture;
using bonneTable.Services.Interfaces;
using bonneTable.Services.Services;
using bonneTalble.Models.RequestModels;
using bonneTalble.Models.ViewModels;
using FluentAssertions;
using System;
using Xunit;

namespace bonneTable.Tests
{
    public class BookingServiceTests
    {
        private Fixture _fixture;

        public BookingServiceTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ClientBookTable_WithValidValues_ReturnsSuccessViewModel()
        {
            var bookingService = new BookingService();
            var bookingRequest = _fixture.Build<BookingRequestModel>().With(b => b.Seats, 2).With(b => b.Email, "wow@wow.se").Create();
            var expected = new BookingViewModel() { Success = true};

            var actual = bookingService.ClientBookTable(bookingRequest);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ClientBookTable_WithNegativeSeats_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService();
            var bookingRequest = _fixture.Build<BookingRequestModel>().With(b => b.Seats, -2).Create();
            var expected = new BookingViewModel() { Success = false, ErrorMessage = "Seats are negative." };

            var actual = bookingService.ClientBookTable(bookingRequest);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ClientBookTable_WithInvalidSeats_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService();
            var bookingRequest = _fixture.Build<BookingRequestModel>().With(b => b.Seats, 7).Create();
            var expected = new BookingViewModel() { Success = false, ErrorMessage = "Too many seats." };

            var actual = bookingService.ClientBookTable(bookingRequest);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ClientBookTable_WithEmptyName_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService();
            var bookingRequest = _fixture.Build<BookingRequestModel>().With(b => b.CustomerName, "").Create();
            var expected = new BookingViewModel() { Success = false, ErrorMessage = "Customer name is empty." };

            var actual = bookingService.ClientBookTable(bookingRequest);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ClientBookTable_WithBadDate_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService();
            var bookingRequest = _fixture.Build<BookingRequestModel>().With(b => b.Time, DateTime.Now).Create();
            var expected = new BookingViewModel() { Success = false, ErrorMessage = "Invalid time." };

            var actual = bookingService.ClientBookTable(bookingRequest);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
