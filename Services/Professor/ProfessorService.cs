using EscolaWeb.Data;
using EscolaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaWeb.Services.Professor
{
    public class ProfessorService : IProfessorInterface
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            try
            {
                var professores = _context.Professores.Include(t => t.Turmas).Include(m => m.Materia).ToList();
                return professores;
            }
            catch 
            {
                return null;
            }
        }

        public ProfessorModel ObterProfessorComTurmasEAlunos(int id)
        {
            try
            {
                var professorTurmasAlunos = _context.Professores
                    .Where(p => p.Id == id)
                    .Include(t => t.Turmas)
                    .ThenInclude(a => a.Alunos)
                    .FirstOrDefault();

                return professorTurmasAlunos;
            }
            catch
            {
                return null;
            }
        }
    }
}
