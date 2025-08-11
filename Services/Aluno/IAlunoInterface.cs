using EscolaWeb.Models;

namespace EscolaWeb.Services.Aluno
{
    public interface IAlunoInterface
    {
        List<AlunoModel> BuscarAlunosPorTurma(int idTurma);
        List<AlunoModel> BuscarAlunos();
        AlunoModel CadastrarAluno(AlunoModel alunoModel);
        AlunoModel BuscarAlunoPorMatricula(int matricula);
    }
}
