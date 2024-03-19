using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Tech.Data;
using HR_Tech.Models;

namespace HR_Tech.Controllers
{
    public class Solicitudes : Controller
    {
        private readonly HRContextDB _context;

        public Solicitudes(HRContextDB context)
        {
            _context = context;
        }

        // GET: Solisitudes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Solicitud.ToListAsync());
        }

        // GET: Solisitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solisitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solisitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSolicitud,IdEmpleado,Descripcion,DiasSolicitados,FechaSolicitud")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

        // GET: Solisitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        // POST: Solisitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSolicitud,IdEmpleado,Descripcion,DiasSolicitados,FechaSolicitud")] Solicitud solicitud)
        {
            if (id != solicitud.IdSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.IdSolicitud))
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
            return View(solicitud);
        }

        // GET: Solisitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solisitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud != null)
            {
                _context.Solicitud.Remove(solicitud);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Solisitudes/Delete/5
        [HttpPost, ActionName("Rechazar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RechazarConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud != null)
            {
                solicitud.Estatus = EstatusSolicitud.RECHAZADA; // Cambia el estado a "Rechazada"
                _context.Solicitud.Update(solicitud);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Solisitudes/Delete/5
        [HttpPost, ActionName("Aprobar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AprobarConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud != null) {
                solicitud.Estatus = EstatusSolicitud.APROBADA; // Cambia el estado a "Aprobada"
                _context.Solicitud.Update(solicitud);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Aprobar(int? id) {
            if (id == null) {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitud == null) {
                return NotFound();
            }

            return View(solicitud);
        }

        public async Task<IActionResult> Rechazar(int? id) {
            if (id == null) {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitud == null) {
                return NotFound();
            }

            return View(solicitud);
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.IdSolicitud == id);
        }
    }
}
