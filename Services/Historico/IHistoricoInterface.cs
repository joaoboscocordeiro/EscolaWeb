using EscolaWeb.Models;

namespace EscolaWeb.Services.Historico
{
    public interface IHistoricoInterface
    {
        List<HistoricoModel> GerarHistorico(int idAluno);
    }
}
