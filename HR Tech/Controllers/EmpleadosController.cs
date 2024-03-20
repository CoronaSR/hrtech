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
    public class EmpleadosController : Controller
    {
        private readonly HRContextDB _context;
      
        public EmpleadosController(HRContextDB context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Empleados-Solicitudes
        public async Task<IActionResult> Solicitudes (int? id)
        {
   
            //nombre = "Enrique";
            if (id == null)
            {
                return NotFound();
            }
            var solicitud = (from s in _context.Solicitud.Where(x => x.IdEmpleado == id)
                             from e in _context.Empleados.Where(x => x.IdEmpleado == s.IdEmpleado)
                             .DefaultIfEmpty()
                             select new SolicitudViewModel
                             {
                                 Descripcion = s.Descripcion,
                                 Nombre = e.Nombre,
                                 DiasSolicitados = s.DiasSolicitados,
                                 Departamento = e.Departamento
                             }).ToList();
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);

            //return View(await _context.Empleados.ToListAsync());
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,Nombre,Apellido,Puesto,Departamento,DiasDeVacaciones")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Apellido,Puesto,Departamento,DiasDeVacaciones")] Empleados empleados)
        {
            if (id != empleados.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.IdEmpleado))
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
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados != null)
            {
                _context.Empleados.Remove(empleados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }

        // GET: Usuarios/Login
        public IActionResult Login() {
            return View();
        }

        // POST: Empleados/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModelE model)
        {
            if (ModelState.IsValid)
            {
                var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Nombre == model.Nombre && e.Departamento == model.Departamento);

                if (empleado != null)
                {
                    // Aquí puedes implementar la lógica de autenticación
                    // Por ejemplo, establecer cookies de autenticación

                    return RedirectToAction("Solicitudes", "Empleados", new {id = empleado.IdEmpleado}); // Redirigir a la página de la vista de solicitudes de empleados
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Datos Incorrectos");
                    return View(model);
                }
            }

            return View(model);
        }
    }
}
