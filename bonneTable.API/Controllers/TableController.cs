using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bonneTable.API.Entities;
using bonneTable.API.Services;

namespace bonneTable.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IUserService _userService;

        public TableController(ITableService tableService, IUserService userService)
        {
            _tableService = tableService;
            _userService = userService;
        }

        // api/table/authenticate
        // {}
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParameters)
        {
            var user = _userService.Authenticate(userParameters.UserName, userParameters.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // GET: api/Table
        [HttpGet]
        public async Task<ActionResult<TableResponseModel>> GetAll()
        {
            var tableResponseModel = await _tableService.Get();
            if (!tableResponseModel.Success)
            {
                return BadRequest();
            }
            return Ok(tableResponseModel);
        }

        // GET: api/Table/{id}
        [Route("{id:guid}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TableResponseModel>> GetByID(Guid id)
        {
            var tableResponseModel = await _tableService.Get(id);
            if (!tableResponseModel.Success)
            {
                return BadRequest();
            }
            return Ok(tableResponseModel);
        }

        // POST: api/Table
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TableRequestModel tableRequest)
        {
            var tableToAdd = await _tableService.Add(tableRequest.numberOfSeats);
            if (!tableToAdd.Success)
            {
                return BadRequest();
            }
            return Ok(tableToAdd);
        }

        // PUT: api/Table/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Table table)
        {
            var tableToUpdate = await _tableService.Edit(id, table);

            if (!tableToUpdate.Success)
            {
                return BadRequest();
            }
            return Ok(tableToUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tableToDelete = await _tableService.Delete(id);
            if (!tableToDelete.Success)
            {
                return BadRequest();
            }
            return Ok(tableToDelete);
        }
    }
}
