using System.Collections.Generic;
namespace WebSalesMVC.Models.ViewModels
{
    public class SaleFormViewModel
    {
        public SalesRecord Sale { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
