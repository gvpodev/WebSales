using System;
using System.ComponentModel.DataAnnotations;
using WebSalesMVC.Models.Enums;
namespace WebSalesMVC.Models
{
    public class SalesRecord
    {
        public int  Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyy}")]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
