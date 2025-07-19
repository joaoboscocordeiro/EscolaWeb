using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
