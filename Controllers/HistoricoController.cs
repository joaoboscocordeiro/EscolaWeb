using EscolaWeb.Services.Historico;
using Microsoft.AspNetCore.Mvc;

namespace EscolaWeb.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly IHistoricoInterface _historicoInterface;

        public HistoricoController(IHistoricoInterface historicoInterface)
        {
            _historicoInterface = historicoInterface;
        }

        [HttpGet("{idAluno}")]
        [Route("/Historico/GerarHistorico/{idAluno}")]
        public IActionResult GerarHistorico(int idAluno)
        {
            var historicos = _historicoInterface.GerarHistorico(idAluno);
            
            if (historicos.Count() == 0)
            {
                TempData["MensagemErro"] = "Não existem notas lançadas para esse aluno!";
                return RedirectToAction("ListarAlunos", "Aluno");
            }

            if (historicos == null)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                return RedirectToAction("ListarAlunos", "Aluno");
            }

            return View(historicos);
        }
    }
}
