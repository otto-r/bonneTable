using System;
using System.Collections.Generic;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
        // api/booking/getall
        [Route("getall")]
        [HttpGet]
        public async Task<ActionResult> Getall()
        {
            var bookings = await _bookingService.Get();

            return Ok(bookings);
        }

        [Route("getbyemail")]
        [HttpGet]
        public async Task<ActionResult> Getall(string email)
        {
            var bookings = await _bookingService.SearchByEmail(email);

            return Ok(bookings);
        }

        // GET bookings from requested date
        [HttpGet]
        public async Task<ActionResult> GetAsync(DateTime dateTime)
        {
            var getBookings = await _bookingService.Get(dateTime);
            if (!getBookings.Success)
            {
                return BadRequest();
            }

            return Ok(getBookings);
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
        public void Delete(string id)
        {
            id = Regex.Replace(id, @"[ ! ]", "-");
            Guid.TryParse(id, out Guid gid);
            _bookingService.AdminCancelBooking(gid);
        }
    }
}
