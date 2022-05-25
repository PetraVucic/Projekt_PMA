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
    public class VlasniksController : Controller
    {
        private readonly ShipContext _context;

        public VlasniksController(ShipContext context)
        {
            _context = context;
        }

        // GET: Vlasniks
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vlasnici.ToListAsync());
        }

        

        // GET: Vlasniks/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Vlasnik());
            else
                return View(_context.Vlasnici.Find(id));
        }

        // POST: Vlasniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("VlasnikId,ImeVlasnika,PrezimeVlasnika,OibVlasnika")] Vlasnik vlasnik)
        {
            if (ModelState.IsValid)
            {
                if (vlasnik.VlasnikId == 0)
                    _context.Add(vlasnik);
                else
                    _context.Update(vlasnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vlasnik);
        }

        
        // GET: Vlasniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vlasnik = await _context.Vlasnici.FindAsync(id);
            _context.Vlasnici.Remove(vlasnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
