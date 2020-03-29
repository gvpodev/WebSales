using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Services;
using WebSalesMVC.Models.ViewModels;
using WebSalesMVC.Models;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSalesMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalerRecordServices _salerRecordServices;
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalerRecordServices salerRecordServices, SellerService sellerService)
        {
            _salerRecordServices = salerRecordServices;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var sellers = await _sellerService.FindAllAsync();
            return View(sellers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleRecordCreateViewModel saleRecordCreateViewModel)
        {
            var seller = await _sellerService.FindByIdAsync(saleRecordCreateViewModel.SellerId);

            if (seller == null)
            {
                return BadRequest();
            }

            var salesRecord = new SalesRecord(saleRecordCreateViewModel.Date, saleRecordCreateViewModel.Amount
                , saleRecordCreateViewModel.Status, seller);

            await _salerRecordServices.InsertAsync(salesRecord);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salerRecordServices.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salerRecordServices.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
