﻿using EscolaWeb.Data;
using EscolaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaWeb.Services.Historico
{
    public class HistoricoService : IHistoricoInterface
    {
        private readonly AppDbContext _context;

        public HistoricoService(AppDbContext context)
        {
            _context = context;
        }

        public HistoricoModel AtualizarNota(int idHistorico, string campo, string valor)
        {
            try
            {
                var historico = _context.Historicos
                    .Include(m => m.Materia)
                    .Include(a => a.Aluno)
                    .Where(h => h.Id == idHistorico)
                    .FirstOrDefault();

                if (historico == null) return null;

                switch (campo)
                {
                    case "Nota1": historico.Nota1 = Double.Parse(valor); break;
                    case "Nota2": historico.Nota2 = Double.Parse(valor); break;
                    case "Nota3": historico.Nota3 = Double.Parse(valor); break;
                    case "Nota4": historico.Nota4 = Double.Parse(valor); break;
                }

                historico.Media = (historico.Nota1 + historico.Nota2 + historico.Nota3 + historico.Nota4) / 4;

                _context.SaveChanges();

                return historico;
            }
            catch 
            {
                return null;
            }
        }

        public List<HistoricoModel> BuscarNotas()
        {
            try
            {
                var historicos = _context.Historicos.Include(a => a.Aluno).Include(m => m.Materia).ToList();
                return historicos;
            }
            catch 
            {
                return null;
            }
        }

        public List<HistoricoModel> GerarHistorico(int idAluno)
        {
            try
            {
                var historicos = _context.Historicos
                    .Include(m => m.Materia)
                    .Include(a => a.Aluno)
                    .ThenInclude(t => t.Turma)
                    .Where(h => h.AlunoId == idAluno)
                    .ToList();

                return historicos;
            }
            catch
            {
                return null;
            }
        }
    }
}
