using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
