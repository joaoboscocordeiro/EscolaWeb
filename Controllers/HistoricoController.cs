using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class HistoricoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
