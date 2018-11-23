using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bonneTable.API.Controllers
{
    public class TableController
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        public void Add()
        {
            _tableService.Add(object);
        }

        public void Delete()
        {
            _tableService.Delete(object);
        }

        public void Edit()
        {
            _tableService.Edit(object);
        }

        public void Get()
        {
            _tableService.Get(object);
        }
    }
}
