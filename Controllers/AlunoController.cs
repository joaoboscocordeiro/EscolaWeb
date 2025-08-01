using EscolaWeb.Models;
using EscolaWeb.Services.Aluno;
using EscolaWeb.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoInterface _alunoInterface;
        private readonly ITurmaInterface _turmaInterface;

        public AlunoController(IAlunoInterface alunoInterface, ITurmaInterface turmaInterface)
        {
            _alunoInterface = alunoInterface;
            _turmaInterface = turmaInterface;
        }

        [HttpGet]
        public IActionResult ListarAlunos()
        {
            var alunos = _alunoInterface.BuscarAlunos();
            return View(alunos);
        }

        [HttpGet]
        public IActionResult CadastrarAluno()
        {
            BuscarTurmas();
            return View();
        }

        [HttpGet]
        [Route("/Aluno/AlunosDaTurma/{idTurma}")]
        public IActionResult AlunosDaTurma(int idTurma)
        {
            var alunos = _alunoInterface.BuscarAlunosPorTurma(idTurma);
            return Json(new {dados = alunos});
        }

        [HttpPost]
        public IActionResult CadastrarAluno(AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = _alunoInterface.CadastrarAluno(alunoModel);

                if (aluno == null)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                    BuscarTurmas();
                    return View(alunoModel);
                }

                TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso!";
                return RedirectToAction("ListarAlunos");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios não foram preenchidos!";
                BuscarTurmas();
                return View(alunoModel);
            }
        }

        private void BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();
            var listaTurma = new SelectList(turmas, "Id", "Descricao");

            ViewBag.Turmas = listaTurma;
        }
    }
}
