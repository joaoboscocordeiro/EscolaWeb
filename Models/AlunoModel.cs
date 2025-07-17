using System.Text.Json.Serialization;

namespace EscolaWeb.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public int TurmaId { get; set; }
        [JsonIgnore]
        public TurmaModel? Turma { get; set; }
    }
}
