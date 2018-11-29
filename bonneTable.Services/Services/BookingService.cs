using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using bonneTable.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRepository<Table> _tableRepository;

        public BookingService(IBookingRepository bookingRepository, IRepository<Table> tableRepository)
        {
            _bookingRepository = bookingRepository;
            _tableRepository = tableRepository;
        }

        public async Task<BookingsResponseModel> AdminBookTable(BookingRequestModel bookingRequest)
        {
            if (bookingRequest == null)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            bookingRequest.Time = bookingRequest.Time.AddMilliseconds(-bookingRequest.Time.Millisecond);
            bookingRequest.Time = bookingRequest.Time.AddSeconds(-bookingRequest.Time.Second);


            var now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            now = now.AddSeconds(-now.Second - 1);


            if (bookingRequest.Time < now)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            var bookingsOnDate = await _bookingRepository.GetByDate(bookingRequest.Time);
            var tables = await _tableRepository.GetAll();

            List<Table> freeTables = new List<Table>();

            List<Booking> bookingsDuring2hInterval = new List<Booking>();

            foreach (var previousBooking in bookingsOnDate)
            {

                var oldBookingEnd = previousBooking.Time.AddHours(2);
                var newBookingStart = bookingRequest.Time.AddMinutes(-1);
                var newBookingAfterOld = oldBookingEnd > newBookingStart;

                var oldBookingStart = previousBooking.Time.AddMinutes(1);
                var newBookingEnd = bookingRequest.Time.AddHours(2);
                var newBookingBeforeOld = oldBookingStart < newBookingEnd;

                var betweenTimes = (newBookingStart > oldBookingStart) && (newBookingStart < oldBookingEnd);

                if (betweenTimes)
                {
                    bookingsDuring2hInterval.Add(previousBooking);
                }
            }

            foreach (var table in tables)
            {
                if (!bookingsDuring2hInterval.Any(b => b.Table.Id == table.Id))
                {
                    freeTables.Add(table);
                }
            }

            freeTables.Sort((x, y) => x.Seats.CompareTo(y.Seats));
            Table selectedTable = new Table();

            if (!freeTables.Any()) { return new BookingsResponseModel { Success = false, ErrorMessage = "No table available" }; };

            foreach (var table in freeTables)
            {
                if (freeTables.Any() && bookingRequest.Seats <= table.Seats)
                {
                    selectedTable = table;
                }
                else
                {
                    return new BookingsResponseModel { Success = false, ErrorMessage = "No table available" };
                }
            }

            Booking booking = new Booking
            {
                Seats = bookingRequest.Seats,
                PhoneNumber = bookingRequest.PhoneNumber,
                CustomerName = bookingRequest.CustomerName,
                Time = bookingRequest.Time,
                Email = bookingRequest.Email,
                Table = selectedTable
            };

            try
            {
                await _bookingRepository.AddAsync(booking);
            }
            catch (Exception)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
                // log error and method
            }

            return new BookingsResponseModel { Success = true };
        }

        public async Task<BookingsResponseModel> AdminCancelBooking(Guid id)
        {
            try
            {
                await _bookingRepository.Delete(id);
                return new BookingsResponseModel { Success = true };
            }
            catch (Exception)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
                // log exception and method
            }
        }

        public async Task<BookingsResponseModel> ClientBookTable(BookingRequestModel bookingRequest)
        {
            if (bookingRequest == null)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            var now = DateTime.Now;

            if (bookingRequest.Time < now)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            // logic to see if seats are available
            // Get bookings and tables to see how many available
            // seats and time slots there are
            var datesBookings = await _bookingRepository.GetByDate(bookingRequest.Time);


            Booking booking = new Booking
            {
                Seats = bookingRequest.Seats,
                PhoneNumber = bookingRequest.PhoneNumber,
                CustomerName = bookingRequest.CustomerName,
                Time = bookingRequest.Time,
                Email = bookingRequest.Email,
                //select table
            };

            await _bookingRepository.AddAsync(booking);

            return new BookingsResponseModel { Success = true };
        }

        public async Task<BookingsResponseModel> EditBooking(BookingRequestModel bookingRequest, Guid id)
        {
            if (bookingRequest == null)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            var now = DateTime.Now;

            if (bookingRequest.Time < now)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            var oldBooking = await _bookingRepository.GetByID(id);

            oldBooking.Table = null;

            await _bookingRepository.EditAsync(id, oldBooking);

            var bookingsOnDate = await _bookingRepository.GetByDate(bookingRequest.Time);
            var tables = await _tableRepository.GetAll();

            List<Table> freeTables = new List<Table>();

            foreach (var table in tables)
            {
                if (!bookingsOnDate.Any(b => b.Table.Id == table.Id))
                {
                    freeTables.Add(table);
                }
            }

            freeTables.Sort((x, y) => x.Seats.CompareTo(y.Seats));
            Table selectedTable = new Table();

            foreach (var table in freeTables)
            {
                if (bookingRequest.Seats <= table.Seats)
                {
                    selectedTable = table;
                }
                else
                {
                    return new BookingsResponseModel { Success = false, ErrorMessage = "No table available" };
                }
            }

            oldBooking.Seats = bookingRequest.Seats;
            oldBooking.PhoneNumber = bookingRequest.PhoneNumber;
            oldBooking.CustomerName = bookingRequest.CustomerName;
            oldBooking.Time = bookingRequest.Time;
            oldBooking.Email = bookingRequest.Email;
            oldBooking.Table = selectedTable;

            try
            {
                await _bookingRepository.EditAsync(id, oldBooking);
            }
            catch (Exception)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
                // log errors
            }

            return new BookingsResponseModel { Success = true };
        }

        public async Task<List<Booking>> Get(DateTime dateTime)
        {
            var bookings = await _bookingRepository.GetAll();
            return bookings;
        }

        public async Task<Booking> Get(Guid id)
        {
            var booking = await _bookingRepository.GetByID(id);
            return booking;
        }

        public async Task<List<Booking>> SearchByEmail(string email)
        {
            var bookings = await _bookingRepository.GetByEmail(email);
            return bookings;
        }
    }
}
