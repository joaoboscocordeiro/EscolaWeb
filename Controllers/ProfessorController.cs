using EscolaWeb.Services.Professor;
using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;

        public ProfessorController(IProfessorInterface professorInterface)
        {
            _professorInterface = professorInterface;
        }

        public IActionResult ListarProfessor()
        {
            var professores = _professorInterface.BuscarProfessores();
            return View(professores);
        }
    }
}
