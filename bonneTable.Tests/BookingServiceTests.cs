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

        public class ClientTests : BookingServiceTests
        {
            [Fact]
            public async void WithValidValues_ReturnsSuccessViewModel()
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
            public async void BookTable_WithValidValues_CallsRepositoryAddAsync()
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
            public async void BookTable_WithNegativeSeats_ReturnsFailureViewModel()
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
            public async void BookTable_WithTooManySeats_ReturnsFailureViewModel()
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
            public async void BookTable_WithBadTime_ReturnsFailureViewModel()
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
            public async void BookTable_WithNullBookingRequest_ReturnsFailureViewModel()
            {
                BookingRequestModel bookingRequest = null;

                var actual = await _service.ClientBookTable(bookingRequest);

                actual.Success.Should().BeFalse();
            }
        }

        public class AdminTests
        {
            public class BookTable : BookingServiceTests
            {
                [Fact]
                public async void TableFull_ReturnsFalse()
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
                public async void TableAvailable_ReturnsTrue()
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

                [Fact]
                public async void TableAvailable_TableBookedAfter_ReturnsFalse()
                {
                    var tablesGetAll = FakeTables.GetAll3x2Tables();
                    var bookingsGetByDate = FakeBookings.Get3Bookings1Late();

                    _bookingRepository.GetByDate(Arg.Any<DateTime>()).Returns(bookingsGetByDate);
                    _tableRepository.GetAll().Returns(tablesGetAll);

                    var bookingService = new BookingService(_bookingRepository, _tableRepository);

                    var bookingRequest = new BookingRequestModel()
                    {
                        Seats = 2,
                        Email = "wow@wow.se",
                        CustomerName = "notCoolguy",
                        Time = DateTime.Now,
                        PhoneNumber = "3758374"
                    };

                    var actual = await bookingService.AdminBookTable(bookingRequest);

                    actual.Success.Should().BeTrue();
                }

                [Fact]
                public async void BookTable_TableBookedBefore_returnsTrue()
                {
                    var tablesGetAll = FakeTables.GetAll3x2Tables();
                    var bookingsGetByDate = FakeBookings.Get3Bookings1Early();

                    _bookingRepository.GetByDate(Arg.Any<DateTime>()).Returns(bookingsGetByDate);
                    _tableRepository.GetAll().Returns(tablesGetAll);

                    var bookingService = new BookingService(_bookingRepository, _tableRepository);

                    var bookingRequest = new BookingRequestModel()
                    {
                        Seats = 2,
                        Email = "wow@wow.se",
                        CustomerName = "notCoolguy",
                        Time = DateTime.Now,
                        PhoneNumber = "3758374"
                    };

                    var actual = await bookingService.AdminBookTable(bookingRequest);

                    actual.Success.Should().BeTrue();
                }
            }

            public class OtherTests : BookingServiceTests
            {
                [Fact]
                public async void CancelBooking_CallsRepositoryDelete()
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
            }
        }
    }
}


