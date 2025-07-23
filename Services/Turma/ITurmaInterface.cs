using EscolaWeb.Models;

namespace EscolaWeb.Services.Turma
{
    public interface ITurmaInterface
    {
        List<TurmaModel> BuscarTurmas();
        TurmaModel CadastrarTurma(TurmaModel turmaModel);
    }
}
