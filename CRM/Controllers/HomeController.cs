using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using CRM.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        

        const string SessionName = "_Name";
        const string SessionAge = "_Age";

        private readonly CRMContext _context;

        
        public HomeController(CRMContext context)
        {
            _context = context;
        }

        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            var user = await _context.User.FindAsync(1);
            HttpContext.Session.SetString(SessionName, "Adam!");
            
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            return View(user);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
