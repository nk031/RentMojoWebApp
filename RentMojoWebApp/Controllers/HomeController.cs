using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentMojoWebApp.Data;
using RentMojoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RentMojoWebApp.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RentTypes.OrderBy(x => x.TypeName).ToListAsync());
        }

        public async Task<IActionResult> ViewSubTypeByType(int? id)
        {
            var rentType = await _context.RentTypes.FindAsync(id);
            ViewData["TypeName"] = "None";
            if (rentType != null)
            {
                ViewData["TypeName"] = rentType.TypeName;
            }
            var applicationDbContext = _context.RentSubTypes.
                Include(m => m.RentType)
                .Where(m => m.TypeID == id);
            return View(await applicationDbContext.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewProductBySubTypeID(int? id)
        {
            var rentSubType = await _context.RentSubTypes.FindAsync(id);
            ViewData["SubTypeName"] = "None";
            if (rentSubType != null)
            {
                ViewData["SubTypeName"] = rentSubType.SubTypeName;
            }
            var applicationDbContext = _context.Products.
                Include(m => m.RentSubType)
                .Where(m => m.SubTypeID == id);
            return View(await applicationDbContext.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> AllProducts()
        {
            var applicationDbContext = _context.Products.
                Include(m => m.RentSubType);
            return View(await applicationDbContext.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.
                Include(m => m.RentSubType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize]
        public IActionResult ProcessCheckOut(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .FirstOrDefault(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["ProductID"] = product.ProductID;
            ViewData["Name"] = product.Name;
            ViewData["Deposit"] = product.Deposit;
            ViewData["MonthlyRent"] = product.MonthlyRent;
            ViewData["TagLine"] = product.TagLine;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessCheckOut([Bind("OrderID,Address,ProductID")] Order order)
        {
            ModelState.Remove("Deposit");
            ModelState.Remove("MonthlyRent");
            ModelState.Remove("UserID");
            ModelState.Remove("OrderDate");
            if (ModelState.IsValid)
            {
                order.UserID = _userManager.GetUserName(this.User);
                order.OrderDate = DateTime.Now;
                var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == order.ProductID);
                if (product != null)
                {
                    order.Deposit = product.Deposit;
                    order.MonthlyRent = product.MonthlyRent;
                }
                _context.Add(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyOrders));
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            string userid = _userManager.GetUserName(this.User);
            var orders = _context.Orders
                .Include(m => m.Product)
                .Where(m => m.UserID == userid);
            return View(await orders.OrderByDescending(m => m.OrderID).ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
