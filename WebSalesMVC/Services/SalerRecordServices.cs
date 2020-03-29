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


        public async Task InsertAsync(SalesRecord obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
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

        public async Task<List<IGrouping<Department, SalesRecord>>>
            FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
