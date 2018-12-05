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

        public async Task<BookingResponseModel> AdminBookTable(BookingRequestModel bookingRequest)
        {
            if (bookingRequest == null)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            bookingRequest.Time = bookingRequest.Time.AddMilliseconds(-bookingRequest.Time.Millisecond);
            bookingRequest.Time = bookingRequest.Time.AddSeconds(-bookingRequest.Time.Second);

            var now = DateTime.Now.AddMinutes(-5);
            now = now.AddMilliseconds(-now.Millisecond);
            now = now.AddSeconds(-now.Second - 1);

            if (bookingRequest.Time < now)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            var bookingsOnDate = await _bookingRepository.GetByDate(bookingRequest.Time);
            var tables = await _tableRepository.GetAll();

            List<Table> freeTables = new List<Table>();

            List<Booking> bookingsDuring2hInterval = new List<Booking>();

            foreach (var oldBooking in bookingsOnDate)
            {
                var newBookingStart = bookingRequest.Time.AddMinutes(1);
                var newBookingEnd = bookingRequest.Time.AddHours(2).AddMinutes(-1);

                var oldBookingStart = oldBooking.Time.AddMinutes(1);
                var oldBookingEnd = oldBooking.Time.AddHours(2).AddMinutes(-1);

                // if these are true add to interval
                var overlapOldBookingFirst = newBookingStart < oldBookingEnd && newBookingStart > oldBookingStart;
                var overlapNewBookingFirst = newBookingEnd > oldBookingStart && newBookingEnd < oldBookingEnd;


                if (overlapNewBookingFirst || overlapOldBookingFirst)
                {
                    bookingsDuring2hInterval.Add(oldBooking);
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
            Table selectedTable = null;

            if (!freeTables.Any()) { return new BookingResponseModel { Success = false, ErrorMessage = "No table available" }; };

            foreach (var table in freeTables)
            {
                if (bookingRequest.Seats <= table.Seats)
                {
                    selectedTable = table;
                }
            }

            if (selectedTable == null)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "No table available with correct amount of seats" };
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
                // log error and method
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }

            return new BookingResponseModel { Success = true };
        }

        public async Task<BookingResponseModel> AdminCancelBooking(Guid id)
        {
            try
            {
                await _bookingRepository.Delete(id);
                return new BookingResponseModel { Success = true };
            }
            catch (Exception)
            {
                // log exception and method
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }
        }

        public async Task<BookingResponseModel> ClientBookTable(BookingRequestModel bookingRequest)
        {
            if (bookingRequest == null)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            bookingRequest.Time = bookingRequest.Time.AddMilliseconds(-bookingRequest.Time.Millisecond);
            bookingRequest.Time = bookingRequest.Time.AddSeconds(-bookingRequest.Time.Second);

            var now = DateTime.Now.AddMinutes(-5);
            now = now.AddMilliseconds(-now.Millisecond);
            now = now.AddSeconds(-now.Second - 1);

            if (bookingRequest.Time < now)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            List<Booking> bookingsOnDate;
            List<Table> tables;
            try
            {
                bookingsOnDate = await _bookingRepository.GetByDate(bookingRequest.Time);
                tables = await _tableRepository.GetAll();
            }
            catch (Exception)
            {
                // logg error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }

            List<Table> freeTables = new List<Table>();

            List<Booking> bookingsDuring2hInterval = new List<Booking>();

            foreach (var oldBooking in bookingsOnDate)
            {
                var newBookingStart = bookingRequest.Time.AddMinutes(1);
                var newBookingEnd = bookingRequest.Time.AddHours(2).AddMinutes(-1);

                var oldBookingStart = oldBooking.Time.AddMinutes(1);
                var oldBookingEnd = oldBooking.Time.AddHours(2).AddMinutes(-1);

                // if these are true add to interval
                var overlapOldBookingFirst = newBookingStart < oldBookingEnd && newBookingStart > oldBookingStart;
                var overlapNewBookingFirst = newBookingEnd > oldBookingStart && newBookingEnd < oldBookingEnd;


                if (overlapNewBookingFirst || overlapOldBookingFirst)
                {
                    bookingsDuring2hInterval.Add(oldBooking);
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
            Table selectedTable = null;

            if (!freeTables.Any()) { return new BookingResponseModel { Success = false, ErrorMessage = "No table available" }; };

            foreach (var table in freeTables)
            {
                if (bookingRequest.Seats <= table.Seats)
                {
                    selectedTable = table;
                }
            }

            if (selectedTable == null)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "No table available with correct amount of seats" };
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
                // log error and method
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }

            return new BookingResponseModel { Success = true };
        }

        public async Task<BookingResponseModel> EditBooking(BookingRequestModel bookingRequest, Guid bookingId)
        {
            if (bookingRequest == null)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            bookingRequest.Time = bookingRequest.Time.AddMilliseconds(-bookingRequest.Time.Millisecond);
            bookingRequest.Time = bookingRequest.Time.AddSeconds(-bookingRequest.Time.Second);

            var now = DateTime.Now.AddMinutes(-5);
            now = now.AddMilliseconds(-now.Millisecond);
            now = now.AddSeconds(-now.Second - 1);

            if (bookingRequest.Time < now)
            {
                return new BookingResponseModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            List<Booking> bookingsOnDate;
            List<Table> tables;
            try
            {
                bookingsOnDate = await _bookingRepository.GetByDate(bookingRequest.Time);
                tables = await _tableRepository.GetAll();
            }
            catch (Exception)
            {
                // logg error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }

            List<Table> freeTables = new List<Table>();

            List<Booking> bookingsDuring2hInterval = new List<Booking>();

            foreach (var oldBooking in bookingsOnDate)
            {
                var newBookingStart = bookingRequest.Time.AddMinutes(1);
                var newBookingEnd = bookingRequest.Time.AddHours(2).AddMinutes(-1);

                var oldBookingStart = oldBooking.Time.AddMinutes(1);
                var oldBookingEnd = oldBooking.Time.AddHours(2).AddMinutes(-1);

                // if these are true add to interval
                var overlapOldBookingFirst = newBookingStart < oldBookingEnd && newBookingStart > oldBookingStart;
                var overlapNewBookingFirst = newBookingEnd > oldBookingStart && newBookingEnd < oldBookingEnd;


                if (overlapNewBookingFirst || overlapOldBookingFirst)
                {
                    bookingsDuring2hInterval.Add(oldBooking);
                }
            }

            var oldBookingToChange = await _bookingRepository.GetByID(bookingId);

            foreach (var table in tables)
            {
                if (oldBookingToChange.Table.Id == table.Id)
                {
                    freeTables.Add(table);
                }
                else if (!bookingsOnDate.Any(b => b.Table.Id == table.Id))
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
                    return new BookingResponseModel { Success = false, ErrorMessage = "No table available" };
                }
            }

            oldBookingToChange.Seats = bookingRequest.Seats;
            oldBookingToChange.PhoneNumber = bookingRequest.PhoneNumber;
            oldBookingToChange.CustomerName = bookingRequest.CustomerName;
            oldBookingToChange.Time = bookingRequest.Time;
            oldBookingToChange.Email = bookingRequest.Email;
            oldBookingToChange.Table = selectedTable;

            try
            {
                await _bookingRepository.EditAsync(bookingId, oldBookingToChange);
            }
            catch (Exception)
            {
                // log error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }

            return new BookingResponseModel { Success = true };
        }

        public async Task<BookingResponseModel> Get()
        {
            List<Booking> bookings;
            try
            {
                bookings = await _bookingRepository.GetAll();
            }
            catch (Exception)
            {
                // log error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }
            return new BookingResponseModel { Success = true, Bookings = bookings };
        }

        public async Task<BookingResponseModel> Get(DateTime dateTime)
        {
            List<Booking> bookings;

            try
            {
                bookings = await _bookingRepository.GetByDate(dateTime);
            }
            catch (Exception)
            {
                // log error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }
            return new BookingResponseModel { Success = true, Bookings = bookings };
        }

        public async Task<BookingResponseModel> Get(Guid id)
        {
            List<Booking> bookings;

            try
            {
                var booking = await _bookingRepository.GetByID(id);
                bookings = new List<Booking> { booking };
            }
            catch (Exception)
            {
                // log error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }
            return new BookingResponseModel { Success = true, Bookings = bookings };
        }

        public async Task<BookingResponseModel> SearchByEmail(string email)
        {
            List<Booking> bookings;

            try
            {
                bookings = await _bookingRepository.GetByEmail(email);
            }
            catch (Exception)
            {
                // log error
                return new BookingResponseModel { Success = false, ErrorMessage = "Error connecting to database" };
            }
            return new BookingResponseModel { Success = true, Bookings = bookings };
        }
    }
}
