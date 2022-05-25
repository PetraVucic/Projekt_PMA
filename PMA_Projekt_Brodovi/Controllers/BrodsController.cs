using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMA_Projekt_Brodovi.Models;

namespace PMA_Projekt_Brodovi.Controllers
{
    public class BrodsController : Controller
    {
        private readonly ShipContext _context;

        public BrodsController(ShipContext context)
        {
            _context = context;
        }

        // GET: Brods
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var shipContext = _context.Brodovi.Include(b => b.SvojstvaBroda).Include(b => b.Vlasnik);
            return View(await shipContext.ToListAsync());
        }

        

        // GET: Brods/Create
        public IActionResult AddOrEdit(int id=0)
        {

            ViewData["SvojstvaBrodaId"] = new SelectList(_context.SvojstvaBrodova, "SvojstvaBrodaId", "SvojstvaBrodaId");
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnici, "VlasnikId", "VlasnikId");
            if (id==0)
                return View(new Brod());
            else
                return View(_context.Brodovi.Find(id));
        }

        // POST: Brods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("BrodId,SvojstvaBrodaId,VlasnikId,ImeBroda,RegistracijskeOznake")] Brod brod)
        {
            if (ModelState.IsValid)
            {
                if(brod.BrodId==0)
                    _context.Add(brod);
                else
                    _context.Update(brod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SvojstvaBrodaId"] = new SelectList(_context.SvojstvaBrodova, "SvojstvaBrodaId", "SvojstvaBrodaId", brod.SvojstvaBrodaId);
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnici, "VlasnikId", "VlasnikId", brod.VlasnikId);
            return View(brod);
        }

        
        // GET: Brods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var brod = await _context.Brodovi.FindAsync(id);
            _context.Brodovi.Remove(brod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
