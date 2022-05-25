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
    public class SvojstvaBrodasController : Controller
    {
        private readonly ShipContext _context;

        public SvojstvaBrodasController(ShipContext context)
        {
            _context = context;
        }

        // GET: SvojstvaBrodas
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SvojstvaBrodova.ToListAsync());
        }



        // GET: SvojstvaBrodas/Create
        
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new SvojstvaBroda());
            else
                return View(_context.SvojstvaBrodova.Find(id));
        }

        // POST: SvojstvaBrodas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("SvojstvaBrodaId,MarkaBroda,ModelBroda,Boja")] SvojstvaBroda svojstvaBroda)
        {
            if (ModelState.IsValid)
            {
                if (svojstvaBroda.SvojstvaBrodaId == 0)
                    _context.Add(svojstvaBroda);
                else
                    _context.Update(svojstvaBroda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(svojstvaBroda);
        }


        // GET: SvojstvaBrodas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var svojstvo = await _context.SvojstvaBrodova.FindAsync(id);
            _context.SvojstvaBrodova.Remove(svojstvo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
