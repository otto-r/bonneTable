using bonneTable.Models.RequestModels;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        // api/booking/getall
        [Route("getall")]
        [HttpGet]
        public async Task<ActionResult> Getall()
        {
            var bookings = await _bookingService.Get();

            return Ok(bookings);
        }

        [Route("getbyemail/{email}")]
        [HttpGet]
        public async Task<ActionResult> Getall(string email)
        {
            var bookings = await _bookingService.SearchByEmail(email);

            return Ok(bookings);
        }

        // GET bookings from requested date
        [Route("getbydate/{date}")]
        [HttpGet]
        public async Task<ActionResult> GetByDate(DateTime date)
        {
            var bookings = await _bookingService.Get(date);

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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] BookingRequestModel bookingRequestModel, Guid guid)
        {
            await _bookingService.EditBooking(bookingRequestModel, guid);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _bookingService.AdminCancelBooking(id);

            return Ok(response);
        }
    }
}
