using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bonneTable.Models;
using bonneTable.Models.ViewModels;
using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bonneTable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
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

        // GET: api/Table/5
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
        public async Task<IActionResult> Post([FromBody] int numberOfSeats)
        {
            var tableToAdd = await _tableService.Add(numberOfSeats);
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
