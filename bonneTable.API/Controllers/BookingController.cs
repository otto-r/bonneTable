using System;
using System.Collections.Generic;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using bonneTable.Models;
using bonneTable.Models.RequestModels;

namespace bonneTable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;


        public BookingController(IBookingService bookingServie)
        {
            _bookingService = bookingServie;

        }

        // GET tables from requested date 
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Booking>>> GetAsync(DateTime dateTime)
        {
            var bookings = await _bookingService.Get(dateTime);

            return bookings;
        }

        // POST AKA ADD
        [HttpPost]
        public void Post([FromBody] string value)
        {
            BookingRequestModel temprequest = new BookingRequestModel();

            _bookingService.ClientBookTable(temprequest);
        }

        // PUT AKA EDIT
        [HttpPut("{id}")]
        public void Put(BookingRequestModel bookingValue, Guid guid)
        {
            _bookingService.EditBooking(bookingValue, guid);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //_bookingService.Delete(id, DateTime???);
        }
    }
}
