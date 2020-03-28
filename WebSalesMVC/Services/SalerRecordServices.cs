using System;
using System.Collections.Generic;
using WebSalesMVC.Models;
using System.Linq;
using WebSalesMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebSalesMVC.Services
{
    public class SalerRecordServices
    {
        private readonly WebSalesMVCContext _context;

        public SalerRecordServices(WebSalesMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue && maxDate.HasValue)
            {
                var result = _context.SalesRecord.Where(x => x.Date >= minDate && x.Date <= maxDate);
                return await result
                    .Include(x => x.Seller)
                    .Include(x => x.Seller.Department)
                    .OrderByDescending(x => x.Date)
                    .ToListAsync();
            }
            else
            {
                throw new NotFoundException("Date not found");
            }
            
        }
    }
}
