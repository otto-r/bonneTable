﻿using bonneTable.Services.Interfaces;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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

            if (bookingRequest.Seats <= 0)
            {
                return new BookingsResponseModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            // logic to see if seats are available
            // Get bookings and tables to see how many available
            // seats and time slots there are
            var bookingsOnDate = await _bookingRepository.GetByDate(bookingRequest.Time);
            var tables = await _tableRepository.GetAll();

            List<Table> freeTables = new List<Table>();

            foreach (var table in tables)
            {
                if (!bookingsOnDate.Any(b => b.Id == table.Id))
                {
                    freeTables.Add(table);
                }
            }

            freeTables.Sort((x, y) => x.Seats.CompareTo(y.Seats));
            Table selectedTable;

            foreach (var table in freeTables)
            {
                if (bookingRequest.Seats <= table.Seats)
                {
                    selectedTable = table;
                }
                else
                {
                    return new BookingsResponseModel { Success = false, ErrorMessage = "Bad request" };
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

            await _bookingRepository.AddAsync(booking);

            return new BookingsResponseModel { Success = true };
        }

        public async Task AdminCancelBooking(Guid id)
        {
            await _bookingRepository.Delete(id);
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
            var datesBookings = _bookingRepository.GetByDate(bookingRequest.Time);


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

        public Task EditBooking(BookingRequestModel bookingRequest, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetBookigsByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
