﻿using EscolaWeb.Data;
using EscolaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaWeb.Services.Aluno
{
    public class AlunoService : IAlunoInterface
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public List<AlunoModel> BuscarAlunos()
        {
            try
            {
                var alunos = _context.Alunos.Include(t => t.Turma).ToList();
                return alunos;
            }
            catch
            {
                return null;
            }
        }

        public List<AlunoModel> BuscarAlunosPorTurma(int idTurma)
        {
            try
            {
                var alunos = _context.Alunos.Where(a => a.TurmaId == idTurma).ToList();
                return alunos;
            }
            catch
            {
                return null;
            }
        }

        public AlunoModel CadastrarAluno(AlunoModel alunoModel)
        {
            try
            {
                alunoModel.Matricula = GerarMatricula();
                alunoModel.Email = $"{alunoModel.Nome.Replace(" ", "").Trim() + alunoModel.Matricula}@gmail.com";

                _context.Alunos.Add(alunoModel);
                _context.SaveChanges();
                return alunoModel;
            }
            catch
            {
                return null;
            }
        }

        private int GerarMatricula()
        {
            Random random = new Random();
            return random.Next(1000, 99999);
        }
    }
}
