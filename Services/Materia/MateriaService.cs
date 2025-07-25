using EscolaWeb.Data;
using EscolaWeb.Models;

namespace EscolaWeb.Services.Materia
{
    public class MateriaService : IMateriaInterface
    {
        private readonly AppDbContext _context;

        public MateriaService(AppDbContext context)
        {
            _context = context;
        }

        public List<MateriaModel> BuscarMateria()
        {
            try
            {
                var materias = _context.Materias.ToList();
                return materias;
            }
            catch
            {
                return null;
            }
        }
    }
}
