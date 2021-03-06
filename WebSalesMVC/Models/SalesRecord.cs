﻿using System;
using System.ComponentModel.DataAnnotations;
using WebSalesMVC.Models.Enums;
namespace WebSalesMVC.Models
{
    public class SalesRecord
    {
        public int  Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }

        public SalesRecord(int id, DateTime date, double amount,
            SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
