using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRM.Controllers
{
    public class BusinessController : Controller
    {
        private readonly CRMContext _context;

        public BusinessController(CRMContext context)
        {
            _context = context;
        }

        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Business.ToListAsync());
        }

       
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .FirstOrDefaultAsync(m => m.Id == id);
            //var user = await _context.User.ToListAsync(m => m.IdRole == role.Id);
            var company = await _context.Company.Where(m => m.BusinessId == business.Id).ToListAsync();
            if (business == null)
            {
                return NotFound();
            }
            ViewBag.Message = business.Name + " Companies";
            return View(company);
        }

    }
}
