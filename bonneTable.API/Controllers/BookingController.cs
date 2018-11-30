using System;
using System.Collections.Generic;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using System.Threading.Tasks;
using bonneTable.Models.ViewModels;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingResponseModel>> GetByDate(DateTime dateTime)
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
        public async Task<IActionResult> Post([FromBody] string value)
        {
            BookingRequestModel temprequest = new BookingRequestModel();

            var bookTable = await _bookingService.ClientBookTable(temprequest);
            if (!bookTable.Success)
            {
                return BadRequest();
            }

            return Ok(bookTable);
        }

        // PUT AKA EDIT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(BookingRequestModel bookingValue, Guid guid)
        {
            var ediTable = await _bookingService.EditBooking(bookingValue, guid);
            if (!ediTable.Success)
            {
                return BadRequest();
            }

            return Ok(ediTable);
        }
    }
}
