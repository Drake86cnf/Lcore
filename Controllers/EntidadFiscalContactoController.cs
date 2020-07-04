using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LCore.Data;
using LCore.Models;

namespace LCore.Controllers
{
    public class EntidadFiscalContactoController : Controller
    {
        private readonly LCoreContext _context;

        public EntidadFiscalContactoController(LCoreContext context)
        {
            _context = context;
        }

        // GET: EntidadFiscalContacto
        public async Task<IActionResult> Index()
        {
            var lCoreContext = _context.EntidadFiscalContacto.Include(e => e.Contacto).Include(e => e.EntidadFiscal);
            return View(await lCoreContext.ToListAsync());
        }

        // GET: EntidadFiscalContacto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadFiscalContacto = await _context.EntidadFiscalContacto
                .Include(e => e.Contacto)
                .Include(e => e.EntidadFiscal)
                .FirstOrDefaultAsync(m => m.EntidadFiscalId == id);
            if (entidadFiscalContacto == null)
            {
                return NotFound();
            }

            return View(entidadFiscalContacto);
        }

        // GET: EntidadFiscalContacto/Create
        public IActionResult Create()
        {
            ViewData["ContactoId"] = new SelectList(_context.Contacto, "Id", "Apellidos");
            ViewData["EntidadFiscalId"] = new SelectList(_context.EntidadFiscal, "Id", "Domicilio");
            return View();
        }

        // POST: EntidadFiscalContacto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadFiscalId,ContactoId")] EntidadFiscalContacto entidadFiscalContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidadFiscalContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactoId"] = new SelectList(_context.Contacto, "Id", "Apellidos", entidadFiscalContacto.ContactoId);
            ViewData["EntidadFiscalId"] = new SelectList(_context.EntidadFiscal, "Id", "Domicilio", entidadFiscalContacto.EntidadFiscalId);
            return View(entidadFiscalContacto);
        }

        // GET: EntidadFiscalContacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadFiscalContacto = await _context.EntidadFiscalContacto.FindAsync(id);
            if (entidadFiscalContacto == null)
            {
                return NotFound();
            }
            ViewData["ContactoId"] = new SelectList(_context.Contacto, "Id", "Apellidos", entidadFiscalContacto.ContactoId);
            ViewData["EntidadFiscalId"] = new SelectList(_context.EntidadFiscal, "Id", "Domicilio", entidadFiscalContacto.EntidadFiscalId);
            return View(entidadFiscalContacto);
        }

        // POST: EntidadFiscalContacto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntidadFiscalId,ContactoId")] EntidadFiscalContacto entidadFiscalContacto)
        {
            if (id != entidadFiscalContacto.EntidadFiscalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidadFiscalContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadFiscalContactoExists(entidadFiscalContacto.EntidadFiscalId))
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
            ViewData["ContactoId"] = new SelectList(_context.Contacto, "Id", "Apellidos", entidadFiscalContacto.ContactoId);
            ViewData["EntidadFiscalId"] = new SelectList(_context.EntidadFiscal, "Id", "Domicilio", entidadFiscalContacto.EntidadFiscalId);
            return View(entidadFiscalContacto);
        }

        // GET: EntidadFiscalContacto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadFiscalContacto = await _context.EntidadFiscalContacto
                .Include(e => e.Contacto)
                .Include(e => e.EntidadFiscal)
                .FirstOrDefaultAsync(m => m.EntidadFiscalId == id);
            if (entidadFiscalContacto == null)
            {
                return NotFound();
            }

            return View(entidadFiscalContacto);
        }

        // POST: EntidadFiscalContacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entidadFiscalContacto = await _context.EntidadFiscalContacto.FindAsync(id);
            _context.EntidadFiscalContacto.Remove(entidadFiscalContacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadFiscalContactoExists(int id)
        {
            return _context.EntidadFiscalContacto.Any(e => e.EntidadFiscalId == id);
        }
    }
}
