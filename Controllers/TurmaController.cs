using EscolaWeb.Services.Turma;
using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaInterface _turmaInterface;

        public TurmaController(ITurmaInterface turmaInterface)
        {
            _turmaInterface = turmaInterface;
        }

        public IActionResult BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();
            return View(turmas);
        }
    }
}
