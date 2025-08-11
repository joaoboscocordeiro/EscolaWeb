using EscolaWeb.Services.Historico;
using EscolaWeb.Services.Materia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaWeb.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly IHistoricoInterface _historicoInterface;
        private readonly IMateriaInterface _materiaInterface;

        public HistoricoController(IHistoricoInterface historicoInterface, IMateriaInterface materiaInterface)
        {
            _historicoInterface = historicoInterface;
            _materiaInterface = materiaInterface;
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

        [HttpGet]
        public IActionResult LancarNotas()
        {
            var notas = _historicoInterface.BuscarNotas();
            BuscarMateria();
            return View(notas);
        }

        private void BuscarMateria()
        {
            var materias = _materiaInterface.BuscarMateria();
            var listaMateria = new SelectList(materias, "Id", "Descricao");

            ViewBag.Materias = listaMateria;
        }
    }
}
