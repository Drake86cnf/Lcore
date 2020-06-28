using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lcore.Data;
using Lcore.Models;

namespace Lcore.Controllers
{
    public class SituacionTributariaController : Controller
    {
        private readonly LCoreContext _context;

        public SituacionTributariaController(LCoreContext context)
        {
            _context = context;
        }

        // GET: SituacionTributaria
        public async Task<IActionResult> Index()
        {
            var lCoreContext = _context.SituacionTributaria.Include(s => s.Localidad);
            return View(await lCoreContext.ToListAsync());
        }

        // GET: SituacionTributaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacionTributaria = await _context.SituacionTributaria
                .Include(s => s.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (situacionTributaria == null)
            {
                return NotFound();
            }

            return View(situacionTributaria);
        }

        // GET: SituacionTributaria/Create
        public IActionResult Create()
        {
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre");
            return View();
        }

        // POST: SituacionTributaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocalidadId,Nombre,NombreAbreviado,Acronimo,FechaCreado,FechaEditado,Nota,Activo")] SituacionTributaria situacionTributaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(situacionTributaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", situacionTributaria.LocalidadId);
            return View(situacionTributaria);
        }

        // GET: SituacionTributaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacionTributaria = await _context.SituacionTributaria.FindAsync(id);
            if (situacionTributaria == null)
            {
                return NotFound();
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", situacionTributaria.LocalidadId);
            return View(situacionTributaria);
        }

        // POST: SituacionTributaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocalidadId,Nombre,NombreAbreviado,Acronimo,FechaCreado,FechaEditado,Nota,Activo")] SituacionTributaria situacionTributaria)
        {
            if (id != situacionTributaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(situacionTributaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SituacionTributariaExists(situacionTributaria.Id))
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
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", situacionTributaria.LocalidadId);
            return View(situacionTributaria);
        }

        // GET: SituacionTributaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacionTributaria = await _context.SituacionTributaria
                .Include(s => s.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (situacionTributaria == null)
            {
                return NotFound();
            }

            return View(situacionTributaria);
        }

        // POST: SituacionTributaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var situacionTributaria = await _context.SituacionTributaria.FindAsync(id);
            _context.SituacionTributaria.Remove(situacionTributaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SituacionTributariaExists(int id)
        {
            return _context.SituacionTributaria.Any(e => e.Id == id);
        }
    }
}
