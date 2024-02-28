using Microsoft.AspNetCore.Mvc;

namespace HR_Tech.Controllers {
    public class Dashboard : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
