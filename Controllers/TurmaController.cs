using EscolaWeb.Models;
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

        [HttpGet]
        public IActionResult BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();
            return View(turmas);
        }

        [HttpGet]
        public IActionResult CadastrarTurma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarTurma(TurmaModel turmaModel)
        {
            if (ModelState.IsValid) 
            {
                var turma = _turmaInterface.CadastrarTurma(turmaModel);

                if (turma == null) 
                {
                    TempData["MensagemErro"] = "Nome de turma repetido ou problema no servidor!";
                    return View(turmaModel);
                }

                TempData["MensagemSucesso"] = "Cadastro de turma realizado com sucesso!";
                return RedirectToAction("BuscarTurmas");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios NÃO foram preenchidos!";
                return View(turmaModel);
            }
        }
    }
}
