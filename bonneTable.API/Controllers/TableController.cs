using bonneTable.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bonneTable.API.Controllers
{
    public class TableController
    {
        private readonly ITableService _tableService;

        Guid testGuid = new Guid();

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        public void Add()
        {
            _tableService.Add(1);
        }

        public void Delete()
        {
            _tableService.Delete(testGuid);
        }

        public void Edit()
        {
            _tableService.Edit(testGuid);
        }

        public void Get()
        {


            _tableService.Get(testGuid);
        }
    }
}
