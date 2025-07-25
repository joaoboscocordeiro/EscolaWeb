using EscolaWeb.Dtos.Professor;
using EscolaWeb.Services.Materia;
using EscolaWeb.Services.Professor;
using EscolaWeb.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaWeb.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;
        private readonly ITurmaInterface _turmaInterface;
        private readonly IMateriaInterface _materiaInterface;

        public ProfessorController(
            IProfessorInterface professorInterface, 
            ITurmaInterface turmaInterface, 
            IMateriaInterface materiaInterface)
        {
            _professorInterface = professorInterface;
            _turmaInterface = turmaInterface;
            _materiaInterface = materiaInterface;
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

        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            BuscarTurmas();
            BuscarMaterias();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {
            if (ModelState.IsValid)
            {
                var professorModel = _professorInterface.CadastrarProfessor(professorCriacaoDto);

                if (professorModel == null)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                    BuscarTurmas();
                    BuscarMaterias();
                    return View(professorCriacaoDto);
                }

                TempData["MensagemSucesso"] = "Professor cadastrado com sucesso!";

                return RedirectToAction("ListarProfessor");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios não foram preenchidos!";
                BuscarTurmas();
                BuscarMaterias();
                return View(professorCriacaoDto);
            }

            return View();
        }

        private void BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();
            var listaTurma = new SelectList(turmas, "Id", "Descricao");

            ViewBag.Turmas = listaTurma;
        }

        private void BuscarMaterias()
        {
            var materias = _materiaInterface.BuscarMateria();
            var listaMaterias = new SelectList(materias, "Id", "Descricao");

            ViewBag.Materias = listaMaterias;
        }
    }
}
