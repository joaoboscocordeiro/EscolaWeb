using EscolaWeb.Models;

namespace EscolaWeb.Services.Professor
{
    public interface IProfessorInterface
    {
        List<ProfessorModel> BuscarProfessores();
    }
}
