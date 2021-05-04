using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentMojoWebApp.Data;
using RentMojoWebApp.Models;

namespace RentMojoWebApp.Controllers 
{
    [Authorize(Roles ="admin")]
    public class RentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public RentTypesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: RentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentTypes.ToListAsync());
        }

        // GET: RentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentType = await _context.RentTypes
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (rentType == null)
            {
                return NotFound();
            }

            return View(rentType);
        }

        // GET: RentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeID,TypeName,File")] RentType rentType)
        {
            using (var memoryStream = new MemoryStream())
            {
                await rentType.File.FormFile.CopyToAsync(memoryStream);

                string photoname = rentType.File.FormFile.FileName;
                rentType.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(rentType.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(rentType);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "images/types");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = rentType.TypeID + rentType.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await rentType.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rentType);
        }

        // GET: RentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentType = await _context.RentTypes.FindAsync(id);
            if (rentType == null)
            {
                return NotFound();
            }
            return View(rentType);
        }

        // POST: RentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeID,TypeName,Extension")] RentType rentType)
        {
            if (id != rentType.TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentTypeExists(rentType.TypeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rentType);
        }

        // GET: RentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentType = await _context.RentTypes
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (rentType == null)
            {
                return NotFound();
            }

            return View(rentType);
        }

        // POST: RentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentType = await _context.RentTypes.FindAsync(id);
            _context.RentTypes.Remove(rentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentTypeExists(int id)
        {
            return _context.RentTypes.Any(e => e.TypeID == id);
        }
    }
}
