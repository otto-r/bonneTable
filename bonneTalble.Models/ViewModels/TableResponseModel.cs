using System.Collections.Generic;

namespace bonneTable.Models.ViewModels
{
    public class TableResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public List<Table> Tables { get; set; }
    }
}
