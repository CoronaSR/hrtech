using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Tech.Controllers
{
    public class Ubicacion : Controller
    {
        // GET: Ubicacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ubicacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ubicacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ubicacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ubicacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ubicacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ubicacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ubicacion/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       
        public class UbicacionController : Controller
        {
            public IActionResult Solicitudes()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Index(double latitud, double longitud)
            {
                // Aquí puedes hacer lo que desees con la latitud y longitud recibidas
                ViewBag.Latitud = latitud;
                ViewBag.Longitud = longitud;
                return View();
            }
        }
    }

}

