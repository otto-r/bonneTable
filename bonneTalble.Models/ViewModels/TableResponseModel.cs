using System.Collections.Generic;

namespace bonneTable.Models.ViewModels
{
    public class TableResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public List<Table> Tables { get; set; }

        public static TableResponseModel Create(bool success = false, string errormsg = null, List<Table> tables = null)
        {
            return new TableResponseModel { Success = success, ErrorMessage = errormsg, Tables = tables };
        }
    }
}
