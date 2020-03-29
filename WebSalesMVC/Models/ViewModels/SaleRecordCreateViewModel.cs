using System;
using System.ComponentModel.DataAnnotations;
using WebSalesMVC.Models.Enums;
namespace WebSalesMVC.Models.ViewModels
{
    public class SaleRecordCreateViewModel
    {
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public SaleStatus Status { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public int SellerId { get; set; }
    }
}
