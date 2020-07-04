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
    public class ContactoController : Controller
    {
        private readonly LCoreContext _context;

        public ContactoController(LCoreContext context)
        {
            _context = context;
        }

        // GET: Contacto
        public async Task<IActionResult> Index()
        {
            var lCoreContext = _context.Contacto.Include(c => c.Imagen).Include(c => c.Localidad).Include(c => c.TipoIdentificacion);
            return View(await lCoreContext.ToListAsync());
        }

        // GET: Contacto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .Include(c => c.Imagen)
                .Include(c => c.Localidad)
                .Include(c => c.TipoIdentificacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contacto/Create
        public IActionResult Create()
        {
            ViewData["ImagenId"] = new SelectList(_context.ContactoImagen, "Id", "Id");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre");
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo");
            return View();
        }

        // POST: Contacto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroIdentificacion,Nombres,Apellidos,FechaNacimiento,Genero,TipoIdentificacionId,LocalidadId,ImagenId,FechaCreado,FechaEditado,Nota,Activo")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImagenId"] = new SelectList(_context.ContactoImagen, "Id", "Id", contacto.ImagenId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", contacto.LocalidadId);
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo", contacto.TipoIdentificacionId);
            return View(contacto);
        }

        // GET: Contacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            ViewData["ImagenId"] = new SelectList(_context.ContactoImagen, "Id", "Id", contacto.ImagenId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", contacto.LocalidadId);
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo", contacto.TipoIdentificacionId);
            return View(contacto);
        }

        // POST: Contacto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroIdentificacion,Nombres,Apellidos,FechaNacimiento,Genero,TipoIdentificacionId,LocalidadId,ImagenId,FechaCreado,FechaEditado,Nota,Activo")] Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Id))
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
            ViewData["ImagenId"] = new SelectList(_context.ContactoImagen, "Id", "Id", contacto.ImagenId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", contacto.LocalidadId);
            ViewData["TipoIdentificacionId"] = new SelectList(_context.TipoIdentificacion, "Id", "Acronimo", contacto.TipoIdentificacionId);
            return View(contacto);
        }

        // GET: Contacto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .Include(c => c.Imagen)
                .Include(c => c.Localidad)
                .Include(c => c.TipoIdentificacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.Id == id);
        }
    }
}
