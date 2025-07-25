using EscolaWeb.Dtos.Professor;
using EscolaWeb.Models;

namespace EscolaWeb.Services.Professor
{
    public interface IProfessorInterface
    {
        List<ProfessorModel> BuscarProfessores();
        ProfessorModel ObterProfessorComTurmasEAlunos(int id);
        ProfessorModel CadastrarProfessor(ProfessorCriacaoDto professorCriacaoDto);
    }
}
