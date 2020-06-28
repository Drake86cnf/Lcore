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
    public class TipoIdentificacionController : Controller
    {
        private readonly LCoreContext _context;

        public TipoIdentificacionController(LCoreContext context)
        {
            _context = context;
        }

        // GET: TipoIdentificacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoIdentificacion.ToListAsync());
        }

        // GET: TipoIdentificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIdentificacion = await _context.TipoIdentificacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIdentificacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Acronimo,EsFiscal,FechaCreado,FechaEditado,Nota,Activo")] TipoIdentificacion tipoIdentificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIdentificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIdentificacion = await _context.TipoIdentificacion.FindAsync(id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }
            return View(tipoIdentificacion);
        }

        // POST: TipoIdentificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Acronimo,EsFiscal,FechaCreado,FechaEditado,Nota,Activo")] TipoIdentificacion tipoIdentificacion)
        {
            if (id != tipoIdentificacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIdentificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIdentificacionExists(tipoIdentificacion.Id))
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
            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIdentificacion = await _context.TipoIdentificacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            return View(tipoIdentificacion);
        }

        // POST: TipoIdentificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoIdentificacion = await _context.TipoIdentificacion.FindAsync(id);
            _context.TipoIdentificacion.Remove(tipoIdentificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIdentificacionExists(int id)
        {
            return _context.TipoIdentificacion.Any(e => e.Id == id);
        }
    }
}
