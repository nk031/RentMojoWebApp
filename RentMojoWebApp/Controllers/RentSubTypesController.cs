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
    [Authorize(Roles = "admin")]
    public class RentSubTypesController : Controller 
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public RentSubTypesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: RentSubTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentSubTypes.Include(r => r.RentType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentSubTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentSubType = await _context.RentSubTypes
                .Include(r => r.RentType)
                .FirstOrDefaultAsync(m => m.SubTypeID == id);
            if (rentSubType == null)
            {
                return NotFound();
            }

            return View(rentSubType);
        }

        // GET: RentSubTypes/Create
        public IActionResult Create()
        {
            ViewData["TypeID"] = new SelectList(_context.RentTypes, "TypeID", "TypeName");
            return View();
        }

        // POST: RentSubTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubTypeID,SubTypeName,File,TypeID")] RentSubType rentSubType)
        {
            using (var memoryStream = new MemoryStream())
            {
                await rentSubType.File.FormFile.CopyToAsync(memoryStream);

                string photoname = rentSubType.File.FormFile.FileName;
                rentSubType.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(rentSubType.Extension.ToLower()))
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
                _context.Add(rentSubType);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "images/subtypes");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = rentSubType.SubTypeID + rentSubType.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await rentSubType.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeID"] = new SelectList(_context.RentTypes, "TypeID", "TypeName", rentSubType.TypeID);
            return View(rentSubType);
        }

        // GET: RentSubTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentSubType = await _context.RentSubTypes.FindAsync(id);
            if (rentSubType == null)
            {
                return NotFound();
            }
            ViewData["TypeID"] = new SelectList(_context.RentTypes, "TypeID", "TypeName", rentSubType.TypeID);
            return View(rentSubType);
        }

        // POST: RentSubTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubTypeID,SubTypeName,Extension,TypeID")] RentSubType rentSubType)
        {
            if (id != rentSubType.SubTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentSubType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentSubTypeExists(rentSubType.SubTypeID))
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
            ViewData["TypeID"] = new SelectList(_context.RentTypes, "TypeID", "TypeName", rentSubType.TypeID);
            return View(rentSubType);
        }

        // GET: RentSubTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentSubType = await _context.RentSubTypes
                .Include(r => r.RentType)
                .FirstOrDefaultAsync(m => m.SubTypeID == id);
            if (rentSubType == null)
            {
                return NotFound();
            }

            return View(rentSubType);
        }

        // POST: RentSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentSubType = await _context.RentSubTypes.FindAsync(id);
            _context.RentSubTypes.Remove(rentSubType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentSubTypeExists(int id)
        {
            return _context.RentSubTypes.Any(e => e.SubTypeID == id);
        }
    }
}
