using AutoFixture;
using bonneTable.Services.Interfaces;
using bonneTable.Services.Services;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using FluentAssertions;
using System;
using AutoFixture.Kernel;
using bonneTable.Models;
using NSubstitute;
using Xunit;

namespace bonneTable.Tests
{
    public class BookingServiceTests
    {
        private Fixture _fixture;
        private IBookingRepository _repository;

        public BookingServiceTests()
        {
            _fixture = new Fixture();
            _repository = Substitute.For<IBookingRepository>();
        }

        [Fact]
        public async void ClientBookTable_WithValidValues_ReturnsSuccessViewModel()
        {
            var bookingService = new BookingService(_repository);
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeTrue();
        }

        [Fact]
        public async void ClientBookTable_WithValidValues_CallsRepositoryAddAsync()
        {
            var bookingService = new BookingService(_repository);
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            await bookingService.ClientBookTable(bookingRequest);

            await _repository.Received(1).AddAsync(Arg.Any<Booking>());
        }

        [Fact]
        public async void ClientBookTable_WithNegativeSeats_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository);
            var bookingRequest = new BookingRequestModel()
            {
                Seats = -2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithTooManySeats_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository);
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 7,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithEmptyName_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository);
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithBadTime_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository);
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(-2),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithNullBookingRequest_ReturnsFailureViewModel()
        {
            var bookingService = new BookingService(_repository);
            BookingRequestModel bookingRequest = null;

            var actual = await bookingService.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void AdminCancelBooking_CallsRepositoryDelete()
        {
            var bookingService = new BookingService(_repository);

            await bookingService.AdminCancelBooking(new Guid());

            await _repository.Received(1).Delete(Arg.Any<Guid>());
        }

        [Fact]
        public async void EditBooking_CallsRepositoryEditAsync()
        {
            var bookingService = new BookingService(_repository);
            var guid = _fixture.Create<Guid>();
            var bookingRequest = _fixture.Create<BookingRequestModel>();
            var booking = new Booking()
            {
                CustomerName = bookingRequest.CustomerName,
                Email = bookingRequest.Email,
                Id = guid,
                PhoneNumber = bookingRequest.PhoneNumber,
                Seats = bookingRequest.Seats,
                Time = bookingRequest.Time
            };

            await bookingService.EditBooking(bookingRequest, guid);

            await _repository.Received(1).EditAsync(guid, booking);
        }

        [Fact]
        public async void GetBookingsByDate_CallsRepositoryGetByDate()
        {
            var bookingService = new BookingService(_repository);
            var date = new DateTime();

            await bookingService.GetBookigsByDate(date);

            await _repository.Received(1).GetByDate(date);
        }

        [Fact]
        public async void SearchByEmail_CallsRepositoryGetByEmail()
        {
            var bookingService = new BookingService(_repository);
            var email = _fixture.Create<string>();

            await bookingService.SearchByEmail(email);

            await _repository.Received(1).GetByEmail(email);
        }
    }
}
