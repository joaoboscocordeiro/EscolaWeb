using EscolaWeb.Services.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoInterface _alunoInterface;

        public AlunoController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

        [HttpGet]
        public IActionResult ListarAlunos()
        {
            var alunos = _alunoInterface.BuscarAlunos();
            return View(alunos);
        }

        [HttpGet]
        [Route("/Aluno/AlunosDaTurma/{idTurma}")]
        public IActionResult AlunosDaTurma(int idTurma)
        {
            var alunos = _alunoInterface.BuscarAlunosPorTurma(idTurma);
            return Json(new {dados = alunos});
        }
    }
}
