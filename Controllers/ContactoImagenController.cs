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
    public class ContactoImagenController : Controller
    {
        private readonly LCoreContext _context;

        public ContactoImagenController(LCoreContext context)
        {
            _context = context;
        }

        // GET: ContactoImagen
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactoImagen.ToListAsync());
        }

        // GET: ContactoImagen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoImagen = await _context.ContactoImagen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactoImagen == null)
            {
                return NotFound();
            }

            return View(contactoImagen);
        }

        // GET: ContactoImagen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactoImagen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imagen,FechaCreado,FechaEditado,Nota,Activo")] ContactoImagen contactoImagen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactoImagen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactoImagen);
        }

        // GET: ContactoImagen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoImagen = await _context.ContactoImagen.FindAsync(id);
            if (contactoImagen == null)
            {
                return NotFound();
            }
            return View(contactoImagen);
        }

        // POST: ContactoImagen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagen,FechaCreado,FechaEditado,Nota,Activo")] ContactoImagen contactoImagen)
        {
            if (id != contactoImagen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactoImagen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoImagenExists(contactoImagen.Id))
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
            return View(contactoImagen);
        }

        // GET: ContactoImagen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoImagen = await _context.ContactoImagen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactoImagen == null)
            {
                return NotFound();
            }

            return View(contactoImagen);
        }

        // POST: ContactoImagen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactoImagen = await _context.ContactoImagen.FindAsync(id);
            _context.ContactoImagen.Remove(contactoImagen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoImagenExists(int id)
        {
            return _context.ContactoImagen.Any(e => e.Id == id);
        }
    }
}
