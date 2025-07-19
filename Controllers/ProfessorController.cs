using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
