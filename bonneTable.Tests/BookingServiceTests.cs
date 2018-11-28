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
using System.Collections.Generic;
using System.Linq;
using bonneTable.Tests.Fakes;

namespace bonneTable.Tests
{
    public class BookingServiceTests
    {
        private Fixture _fixture;
        private IBookingRepository _bookingRepository;
        private IRepository<Table> _tableRepository;
        private IBookingService _service;

        public BookingServiceTests()
        {
            _fixture = new Fixture();
            _bookingRepository = Substitute.For<IBookingRepository>();
            _tableRepository = Substitute.For<IRepository<Table>>();
            _service = new BookingService(_bookingRepository, _tableRepository);
        }

        [Fact]
        public async void ClientBookTable_WithValidValues_ReturnsSuccessViewModel()
        {
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await _service.ClientBookTable(bookingRequest);

            actual.Success.Should().BeTrue();
        }

        [Fact]
        public async void ClientBookTable_WithValidValues_CallsRepositoryAddAsync()
        {
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            await _service.ClientBookTable(bookingRequest);

            await _bookingRepository.Received(1).AddAsync(Arg.Any<Booking>());
        }

        [Fact]
        public async void ClientBookTable_WithNegativeSeats_ReturnsFailureViewModel()
        {
            var bookingRequest = new BookingRequestModel()
            {
                Seats = -2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await _service.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithTooManySeats_ReturnsFailureViewModel()
        {
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 7,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await _service.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithEmptyName_ReturnsFailureViewModel()
        {
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "",
                Time = DateTime.Now.AddHours(2),
                PhoneNumber = "3758374"
            };

            var actual = await _service.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithBadTime_ReturnsFailureViewModel()
        {
            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "Coolguy",
                Time = DateTime.Now.AddHours(-2),
                PhoneNumber = "3758374"
            };

            var actual = await _service.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void ClientBookTable_WithNullBookingRequest_ReturnsFailureViewModel()
        {
            BookingRequestModel bookingRequest = null;

            var actual = await _service.ClientBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void AdminCancelBooking_CallsRepositoryDelete()
        {
            await _service.AdminCancelBooking(new Guid());

            await _bookingRepository.Received(1).Delete(Arg.Any<Guid>());
        }

        [Fact]
        public async void EditBooking_CallsRepositoryEditAsync()
        {
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

            await _service.EditBooking(bookingRequest, guid);

            await _bookingRepository.Received(1).EditAsync(guid, booking);
        }

        [Fact]
        public async void GetBookingsByDate_CallsRepositoryGetByDate()
        {
            var date = new DateTime();

            await _service.Get(date);

            await _bookingRepository.Received(1).GetByDate(date);
        }

        [Fact]
        public async void SearchByEmail_CallsRepositoryGetByEmail()
        {
            var email = _fixture.Create<string>();

            await _service.SearchByEmail(email);

            await _bookingRepository.Received(1).GetByEmail(email);
        }

        [Fact]
        public async void AdminBookTable_TableFull_ReturnsSuccessFalse()
        {
            var tablesGetAll = FakeTables.GetAll3x2Tables();
            var bookingsGetByDate = FakeBookings.Get3Bookings();

            _bookingRepository.GetByDate(Arg.Any<DateTime>()).Returns(bookingsGetByDate);
            _tableRepository.GetAll().Returns(tablesGetAll);

            var bookingService = new BookingService(_bookingRepository, _tableRepository);

            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "notCoolguy",
                Time = DateTime.Now.AddHours(1),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.AdminBookTable(bookingRequest);

            actual.Success.Should().BeFalse();
        }

        [Fact]
        public async void AdminBookTable_TableAvailable_ReturnsSuccessTrue()
        {
            var tablesGetAll = FakeTables.GetAll4x2Tables();
            var bookingsGetByDate = FakeBookings.Get3Bookings();

            _bookingRepository.GetByDate(Arg.Any<DateTime>()).Returns(bookingsGetByDate);
            _tableRepository.GetAll().Returns(tablesGetAll);

            var bookingService = new BookingService(_bookingRepository, _tableRepository);

            var bookingRequest = new BookingRequestModel()
            {
                Seats = 2,
                Email = "wow@wow.se",
                CustomerName = "slightlyCoolguy",
                Time = DateTime.Now.AddHours(1),
                PhoneNumber = "3758374"
            };

            var actual = await bookingService.AdminBookTable(bookingRequest);

            actual.Success.Should().BeTrue();
        }
    }
}


