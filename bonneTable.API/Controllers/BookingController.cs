using System;
using System.Collections.Generic;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using System.Threading.Tasks;

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

        //GETALL for testing mainly. Perhaps useful for admin
        [Route("getall")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> Getall()
        {
            var bookings = await _bookingService.Get();

            return Ok(bookings);
        }

        // GET tables from requested date
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAsync(DateTime dateTime)
        {
            var bookings = await _bookingService.Get(dateTime);

            return Ok(bookings);
        }

        // POST AKA ADD
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingRequestModel bookingRequestModel)
        {

            var bookingresponse = await _bookingService.ClientBookTable(bookingRequestModel);
            return Ok(bookingresponse);
        }

        // PUT AKA EDIT
        [Route("{id:guid}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(BookingRequestModel bookingValue, Guid guid)
        {
            await _bookingService.EditBooking(bookingValue, guid);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //_bookingService.Delete(id, DateTime???);
        }
    }
}
