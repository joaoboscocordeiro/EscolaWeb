using System.Text.Json.Serialization;

namespace EscolaWeb.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DataContratacao { get; set; }
        public int MateriaId { get; set; }
        public MateriaModel Materia { get; set; }
        [JsonIgnore]
        public List<TurmaModel> Turmas { get; set; }
    }
}
