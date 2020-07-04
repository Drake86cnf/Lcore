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
    public class EntidadFiscalController : Controller
    {
        private readonly LCoreContext _context;

        public EntidadFiscalController(LCoreContext context)
        {
            _context = context;
        }

        // GET: EntidadFiscal
        public async Task<IActionResult> Index()
        {
            var lCoreContext = _context.EntidadFiscal.Include(e => e.Localidad).Include(e => e.SituacionTributaria).Include(e => e.TipoIdentificacion);
            return View(await lCoreContext.ToListAsync());
        }

        // GET: EntidadFiscal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadFiscal = await _context.EntidadFiscal
                .Include(e => e.Localidad)
                .Include(e => e.SituacionTributaria)
                .Include(e => e.TipoIdentificacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidadFiscal == null)
            {
                return NotFound();
            }

            return View(entidadFiscal);
        }

        // GET: EntidadFiscal/Create
        public IActionResult Create()
        {
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre");
            ViewData["SituacionTributariaId"] = new SelectList(_context.SituacionTributaria, "Id", "Acronimo");
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo");
            return View();
        }

        // POST: EntidadFiscal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroIdentificacionFiscal,TipoIdentificacionId,SituacionTributariaId,Domicilio,Comprobante,LocalidadId,FechaCreado,FechaEditado,Nota,Activo,RazonSocial,NombreFantasia")] EntidadFiscal entidadFiscal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidadFiscal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", entidadFiscal.LocalidadId);
            ViewData["SituacionTributariaId"] = new SelectList(_context.SituacionTributaria, "Id", "Acronimo", entidadFiscal.SituacionTributariaId);
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo", entidadFiscal.TipoIdentificacionId);
            return View(entidadFiscal);
        }

        // GET: EntidadFiscal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadFiscal = await _context.EntidadFiscal.FindAsync(id);
            if (entidadFiscal == null)
            {
                return NotFound();
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", entidadFiscal.LocalidadId);
            ViewData["SituacionTributariaId"] = new SelectList(_context.SituacionTributaria, "Id", "Acronimo", entidadFiscal.SituacionTributariaId);
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo", entidadFiscal.TipoIdentificacionId);
            return View(entidadFiscal);
        }

        // POST: EntidadFiscal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroIdentificacionFiscal,TipoIdentificacionId,SituacionTributariaId,Domicilio,Comprobante,LocalidadId,FechaCreado,FechaEditado,Nota,Activo,RazonSocial,NombreFantasia")] EntidadFiscal entidadFiscal)
        {
            if (id != entidadFiscal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidadFiscal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadFiscalExists(entidadFiscal.Id))
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
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", entidadFiscal.LocalidadId);
            ViewData["SituacionTributariaId"] = new SelectList(_context.SituacionTributaria, "Id", "Acronimo", entidadFiscal.SituacionTributariaId);
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo", entidadFiscal.TipoIdentificacionId);
            return View(entidadFiscal);
        }

        // GET: EntidadFiscal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadFiscal = await _context.EntidadFiscal
                .Include(e => e.Localidad)
                .Include(e => e.SituacionTributaria)
                .Include(e => e.TipoIdentificacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidadFiscal == null)
            {
                return NotFound();
            }

            return View(entidadFiscal);
        }

        // POST: EntidadFiscal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entidadFiscal = await _context.EntidadFiscal.FindAsync(id);
            _context.EntidadFiscal.Remove(entidadFiscal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadFiscalExists(int id)
        {
            return _context.EntidadFiscal.Any(e => e.Id == id);
        }
    }
}
