﻿using bonneTable.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace bonneTable.API.Controllers
{
    public class TableController
    {
        private readonly ITableService _tableService;

        // To get key:

        // [Route("{key:int}")] to get key
        // [HttpGet]
        // public ... Get(int key)

        Guid tempGuid = new Guid(); // TEMP
        Models.Table tempTable = new Models.Table(); // TEMP

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [Route("api/books")]
        [HttpPost]
        public void Add(int numberOfSeats)
        {
            _tableService.Add(numberOfSeats);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _tableService.Delete(tempGuid);
        }

        [Route("{id:guid}")]
        [HttpPut]
        public void Edit(Guid id)
        {
            _tableService.Edit(id, tempTable);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public void GetTablebyId(Guid id)
        {
            _tableService.Get(id);
        }

        [HttpGet]
        public void GetAll()
        {
            _tableService.Get();
        }
    }
}
