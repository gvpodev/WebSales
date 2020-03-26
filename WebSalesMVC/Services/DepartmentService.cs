using System;
using WebSalesMVC.Models;
using System.Linq;
using System.Collections.Generic;
namespace WebSalesMVC.Services
{
    public class DepartmentService
    {
        private readonly WebSalesMVCContext _context;

        public DepartmentService(WebSalesMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
