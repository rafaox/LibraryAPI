using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryApi.Services.ViewModels
{
    public class UpdateBookViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O resumo é obrigatório.")]
        [StringLength(2000, ErrorMessage = "O resumo deve ter no máximo 2000 caracteres.")]
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "O autor é obrigatória.")]
        [StringLength(100, ErrorMessage = "O autor deve ter no máximo 100 caracteres.")]
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        [StringLength(13, ErrorMessage = "O ISBN deve ter no máximo 13 caracteres.")]
        [JsonPropertyName("isbn")]
        public string Isbn { get; set; }
    }
}