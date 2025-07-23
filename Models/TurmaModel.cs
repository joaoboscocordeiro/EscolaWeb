using System.ComponentModel.DataAnnotations;

namespace EscolaWeb.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string Descricao { get; set; } = string.Empty;
        public string Modalidade { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;

        public List<ProfessorModel>? Professores { get; set; }
        public List<AlunoModel>? Alunos { get; set; }
    }
}
