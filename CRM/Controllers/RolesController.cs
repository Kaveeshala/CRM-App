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
    public class RolesController : Controller
    {
        private readonly CRMContext _context;

        public RolesController(CRMContext context)
        {
            _context = context;
        }

        // GET: Roles
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Role.ToListAsync());
        }

        // GET: Roles/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.Id == id);
            //var user = await _context.User.ToListAsync(m => m.IdRole == role.Id);
            var user = await _context.User.Where(m => m.RoleId == role.Id).ToListAsync();
            var loggedUser = await _context.User.FirstOrDefaultAsync(m => m.Login == User.FindFirst("user").Value);
            ViewBag.userId = loggedUser.Id;
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.Message = role.Name + "s";
            return View(user);
        }

    }
}
