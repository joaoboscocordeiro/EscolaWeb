using System.ComponentModel.DataAnnotations;

namespace EscolaWeb.Dtos.Professor
{
    public class ProfessorCriacaoDto
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Data da contratação é obrigatório!")]
        public DateTime? DataContratacao { get; set; }
        [Required(ErrorMessage = "Selecione uma matéria!")]
        public int? MateriaId { get; set; }
        [Required(ErrorMessage = "Selecione uma turma!")]
        public List<int>? TurmasId { get; set; }
    }
}
