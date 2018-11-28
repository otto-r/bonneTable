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
        // Temporary objects will be replaced later on


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
            BookingRequestModel temprequest = new BookingRequestModel(); // TEMP
            _bookingService.ClientBookTable(temprequest); // TEMP
        }

        // PUT AKA EDIT
        [Route("{id:guid}")]
        [HttpPut("{id}")]
        public void Put(BookingRequestModel bookingValue, Guid id)
        {
            _bookingService.EditBooking(bookingValue, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //_bookingService.Delete(id, DateTime???);
        }
    }
}
