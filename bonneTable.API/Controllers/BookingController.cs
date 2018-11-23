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
        public ActionResult<IEnumerable<Booking>> Get(DateTime dateTime)
        {
            return _bookingService.GetBookigsByDate(dateTime);
        }

        // POST AKA ADD
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _bookingService.Add("Add this booking To The Current Date");
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
