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

        [HttpGet]
        public IActionResult ListarProfessor()
        {
            var professores = _professorInterface.BuscarProfessores();
            return View(professores);
        }

        [HttpGet("id")]
        public IActionResult DetalhesProfessor(int id)
        {
            var professores = _professorInterface.ObterProfessorComTurmasEAlunos(id);
            return View(professores);
        }

        [HttpPost]
        public IActionResult CadastrarProfessor()
        {
            return View();
        }
    }
}
